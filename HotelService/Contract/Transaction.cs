using System;
using System.Runtime.Serialization;

namespace HotelService.Contract
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public Item Item { get; set; }

        [DataMember]
        public Outlet Outlet { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        [DataMember]
        public DateTime transaction_date { get; set; }

    }
}
