#load "Device.csx"
#load "DocumentDBRepository.csx"

using System.Threading.Tasks;

public class DeviceService
{

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

    private static void initColState()
    {
        DocumentDBRepository<DeviceState>.DataBaseID = "Eurek_DB";
        DocumentDBRepository<DeviceState>.CollectionID = "Eurek_State";

    }
}