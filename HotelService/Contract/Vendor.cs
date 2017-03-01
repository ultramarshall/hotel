using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class Vendor
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string vendor_name { get; set; }
        [DataMember]
        public string vendor_company { get; set; }
        [DataMember]
        public string vendor_address { get; set; }
        [DataMember]
        public string vendor_phone { get; set; }
        [DataMember]
        public DateTime join_date { get; set; }
    }

    
}
