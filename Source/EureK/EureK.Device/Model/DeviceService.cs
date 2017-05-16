using EureK.Device.Repo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EureK.Device.Model
{
    public class DeviceService
    {
        public static async Task<DeviceFull> GetDeviceInfo(string id, string district)
        {
            initColData();
            return await DocumentDBRepository<DeviceFull>.GetDocumentAsync(q => q.ID == id, district);
        }

        public static async Task<DeviceState> GetLastDeviceStateAsync(string id)
        {
            initColState();
            DeviceState result = await DocumentDBRepository<DeviceState>.GetLastDocumentByDateAsync(id);
            return result;
        }

        public static async Task<bool> CreateDeviceStateAsync(DeviceState item)
        {
            initColState();
            return await DocumentDBRepository<DeviceState>.CreateItemAsync(item);
        }

        private static void initColData()
        {
            DocumentDBRepository<DeviceFull>.DataBaseID = "Eurek_DB";
            DocumentDBRepository<DeviceFull>.CollectionID ="Eurek_Col";

        }

        private static void initColState()
        {
            DocumentDBRepository<DeviceState>.DataBaseID = "Eurek_DB";
            DocumentDBRepository<DeviceState>.CollectionID = "Eurek_State";

        }
    }
}
