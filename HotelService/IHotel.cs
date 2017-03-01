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
        [OperationContract]
        List<Vendor> findByID(int id);
    }
}
