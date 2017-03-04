using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class ItemCategory
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string category_code { get; set; }

        [DataMember]
        public string category_name { get; set; }

        [DataMember]
        public Item Item { get; set; }
    }
}
