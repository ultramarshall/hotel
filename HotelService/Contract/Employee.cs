using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public Division Division { get; set; }

        [DataMember]
        public EmployeeBiodata EmployeeBiodata { get; set; }

        [DataMember]
        public Outlet Outlet { get; set; }

    }
}
