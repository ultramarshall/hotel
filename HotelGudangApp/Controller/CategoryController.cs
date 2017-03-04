using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using HotelGudangApp.California;

namespace HotelGudangApp.Controller
{
    public class CategoryController
    {
        private readonly HotelClient client = new HotelClient();

        public List<ItemCategory> GetCategories()
        {
            return client.FindCategory().ToList();
        }

        public int FindIdCategory(ComboBoxEdit data)
        {
            try
            {
                var _category = client.FindCategory()
                                    .FirstOrDefault( x => x.category_name == data.SelectedItem.ToString());
                return _category.id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ItemCategory> GetMasterData()
        {
            return client.FindItemCategory().ToList();
        }  
    }
}
