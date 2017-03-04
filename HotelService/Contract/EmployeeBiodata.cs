using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contract
{
    [DataContract]
    public class EmployeeBiodata
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string employee_name { get; set; }

        [DataMember]
        public string employee_address { get; set; }

    }
}
