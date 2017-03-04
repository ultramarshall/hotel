using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string item_code { get; set; }

        [DataMember]
        public string item_name { get; set; }

        [DataMember]
        public decimal item_prize { get; set; }

        [DataMember]
        public DateTime? added_by_date { get; set; }

        [DataMember]
        public DateTime? edit_by_date { get; set; }

        [DataMember]
        public DateTime? create_by_date { get; set; }

        [DataMember]
        public Vendor Vendor { get; set; }

        [DataMember]
        public ItemCategory ItemCategory { get; set; }
    }
}
