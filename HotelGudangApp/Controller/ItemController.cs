using System.Collections.Generic;
using System.Linq;
using HotelGudangApp.California;

namespace HotelGudangApp.Controller
{
    public class ItemController
    {
        private HotelClient client = new HotelClient();

        public List<Item> GetItem()
        {
            return client.SelectAllItems().ToList();
        }

        public List<Item> GetItemByCategory(int id)
        {
            return client.SelectAllItems().Where(x => x.ItemCategory.id == id).ToList();
        }

        
    }
}
