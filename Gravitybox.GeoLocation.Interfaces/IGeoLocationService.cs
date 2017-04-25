using System.Collections.Generic;
using System.ServiceModel;

namespace Gravitybox.GeoLocation.Interfaces
{
    [ServiceContract]
    public interface IGeoLocationService
    {
        [OperationContract]
        ZipInfo GetZip(string zipCode);

        [OperationContract]
        ZipInfo GetZipFromCoordinates(double latitude, double longitude, bool isExact = true);

        [OperationContract]
        ZipInfo GetZipFromCityState(string city, string state);

        [OperationContract]
        bool IsZipValid(string zipCode);

        [OperationContract]
        StateInfo GetStateInfo(string name);

        [OperationContract]
        List<StateInfo> GetStateList();

        [OperationContract]
        List<string> GetLookup(string term);
    }
}