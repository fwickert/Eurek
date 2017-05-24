
# Eurek

Eurek est l'entreprise fictive utilisée pour le Tour de France Azure animé par Emilie Beau, Olivier Kajdan, Frédéric Wickert.

Vous y trouverez les présentations, les labs, le code source, et autres informations.

Les informations sont structurées comme suite :
- Dossier "Lab" : "Assets" nécessaires pour que vous puissiez appréhender les fonctionnalités illustrées dans le projet Eurek.
- Dossier "Presentation" : Présentation pptx sur les différentes technos utilisées
- Dossier "Source/EureK" : Source code de l'application Web, Function, Console.

## Qui est Eurek ?
Le métier d'oirgine d'Eurek est la vente de lampadaire aux collectivités. Pour différentes raisons, elle doit aborder une transformation numérique et changer de business model pour s'adapter aux nouveaux enjeux de notre société.
De ce fait, Eurek va proposer des nouveaux lampdaires, **des lampadaires intélligents** (ou lampadaires connectés).

De point de vu technique, nous allons aborder cette transformation en 3 parties (pour l'instant uniquement le Back-end) : 
- Back-End pour récupérer les messages venant des lampadaires (les devices)
- Back-end pour analyser ces données et les rendre intélligentes
- Back-end pour intégrer les données "legacy" de l'entreprise.

Nous allons utiliser **Microsoft Azure** pour mettre en oeuvre ces 3 parties. EN voici une liste : 
- Azure App Service : Web App https://docs.microsoft.com/fr-fr/azure/app-service-web/app-service-web-overview 
- Azure App Service : Function App https://docs.microsoft.com/fr-fr/azure/azure-functions/
- Azure IoT HUB https://docs.microsoft.com/fr-fr/azure/iot-hub/
- Azure CosmosDB https://docs.microsoft.com/fr-fr/azure/cosmos-db/
- Cortana Intelligence Suite https://azure.microsoft.com/fr-fr/services/?sort=&filter=suites
- Microsoft Cognitives Services https://docs.microsoft.com/fr-fr/azure/cognitive-services/
- Azure SQL Database https://docs.microsoft.com/fr-fr/azure/sql-database/
- Azure Data Factory https://docs.microsoft.com/fr-fr/azure/data-factory/
- Azure Analysis Services https://docs.microsoft.com/fr-fr/azure/analysis-services/
- Microsoft PowerBI https://powerbi.microsoft.com/fr-fr/

## Azure Iot Hub
- Presentation : Fichier : https://github.com/fwickert/Eurek/blob/master/Presentation/Tour%20de%20France%20Partie1.pptx (Slide 25-28)
- Lab : https://github.com/fwickert/Eurek/blob/master/Lab/Lab%201%20-%20Partie%201%20-%20IOTHUB.docx

## Azure App Service : Function App
- Presentation : Fichier : https://github.com/fwickert/Eurek/blob/master/Presentation/Tour%20de%20France%20Partie1.pptx (Slide 29-31)
- Lab : https://github.com/fwickert/Eurek/blob/master/Lab/Lab%201%20-%20Partie%202%20-%20FunctionApp.docx
- Projet "eurek-function/wwwroot" : Source de la solution https://github.com/fwickert/Eurek/blob/master/Source/EureK/EureK.sln

## Azure App Service : Web App
- Presentation : Fichier : https://github.com/fwickert/Eurek/blob/master/Presentation/Tour%20de%20France%20Partie1.pptx (Slide 14-24)
- Lab : https://github.com/fwickert/Eurek/blob/master/Lab/Lab%201%20-%20Partie%203%20-%20AppService.docx
- Projet "EureK.web" : Source de la solution https://github.com/fwickert/Eurek/blob/master/Source/EureK/EureK.sln

## Azure CosmosDB
- Presentation : Fichier : https://github.com/fwickert/Eurek/blob/master/Presentation/Tour%20de%20France%20Partie1.pptx (Slide 32-40)
Attention : Ces slides vont changer dans quelques jours (Depuis l'annonce de CosmosDB à la place de DocumentDB)
- Lab : https://github.com/fwickert/Eurek/blob/master/Lab/Lab%201%20-%20Partie%204%20-%20CosmosDB.docx

## Console App : Simulateur de Devices
- Lab : Voir la fin du lab CosmosDB
- Projet "TestDeviceSimulation" : Source de la solution https://github.com/fwickert/Eurek/blob/master/Source/EureK/EureK.sln

