using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class Outlet
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string outlet_name { get; set; }

        [DataMember]
        public string outlet_address { get; set; }

        [DataMember]
        public string outlet_phone { get; set; }

    }
}
