using HotelService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelService
{
    [ServiceContract]
    public interface IHotel
    {
        // vendor
        [OperationContract]
        List<Vendor> FindVendors();

        // category item
        [OperationContract]
        List<ItemCategory> FindCategory();

        [OperationContract]
        List<ItemCategory> FindItemCategory();

        // item
        [OperationContract]
        List<Item> SelectAllItems();



    }
}
