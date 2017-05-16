using EureK.Device.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EureK.Device.Repo
{
    internal static class DocumentDBRepository<T> where T : class
    {
        #region Key
        private static string enpoint = "https://<Your CosmosDB Name>.documents.azure.com:443/";
        private static string authKey = "<Your CosmosDB KEY>";
        #endregion
        
        private static DocumentClient _client = new DocumentClient(new Uri(enpoint), authKey);

        public static string DataBaseID { get; set; }
        public static string CollectionID { get; set; }

        internal static async Task<IEnumerable<T>> GetDocumentsAsync(Expression<Func<T, bool>> predicate, string partitionKey = null)
        {
            FeedOptions opt = new FeedOptions()
            {
                EnableCrossPartitionQuery = (String.IsNullOrEmpty(partitionKey)) ? true : false,
                PartitionKey = (String.IsNullOrEmpty(partitionKey)) ? null : new PartitionKey(partitionKey),
                MaxItemCount = 100 // Replace by continuation
            };

            IDocumentQuery<T> query = _client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DataBaseID, CollectionID), opt)
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        internal static async Task<T> GetDocumentAsync(Expression<Func<T, bool>> predicate, string partitionKey)
        {
            return (await GetDocumentsAsync(predicate, partitionKey))
               .AsEnumerable()
               .FirstOrDefault();
        }

        internal static async Task<T> GetLastDocumentByDateAsync(string id)
        {

            FeedOptions opt = new FeedOptions()
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100 // Replace by continuation
            };

            IDocumentQuery<DeviceState> query = _client.CreateDocumentQuery<DeviceState>(
                UriFactory.CreateDocumentCollectionUri(DataBaseID, CollectionID), opt)
                .Where(q => q.DeviceID == id)
                .OrderByDescending(o=>o.StateDateTime)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results.FirstOrDefault();
        }

        internal static async Task<bool> CreateItemAsync(T item)
        {
            try
            {
                await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DataBaseID, CollectionID), item);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
