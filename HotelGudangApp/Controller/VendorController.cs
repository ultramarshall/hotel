using System.Collections.Generic;
using System.Linq;
using HotelGudangApp.California;

namespace HotelGudangApp.Controller
{
    public class VendorController
    {
        private HotelClient client = new HotelClient();

        public List<Vendor> GetVendor()
        {
            return client.FindVendors().ToList();
        }

        public Vendor GetVendorByID(int id)
        {
            return client.FindVendors().FirstOrDefault(x => x.id == id);
        }
        
    }
}
