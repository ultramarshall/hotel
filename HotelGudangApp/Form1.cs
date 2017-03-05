using System;
using System.Globalization;
using System.Linq;
using DevExpress.DashboardCommon;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using HotelGudangApp.Controller;

namespace HotelGudangApp
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Controller
        private readonly VendorController Vendors = new VendorController();
        private readonly CategoryController Category = new CategoryController();
        private readonly ItemController _item = new ItemController();

        // Culture ID
        private readonly CultureInfo _culture = new CultureInfo("id-ID");

        // Navigation
        private void Nav(NavigationFrame Frames, NavigationPage Pages)
        {
            Frames.SelectedPage = Pages;
        }
        
        





        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            try
            {
                // open wait form
                loading.ShowWaitForm();
                ComboboxUpdateVendor();
                ComboBoxUpdateCategory();

                // show item
                ShowItem();

                // close wait form
                loading.CloseWaitForm();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(error.ToString());
            }
            finally
            {
                // selected wait form
                NavPage.SelectedPage = MasterItem;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Nav(NavPage, AddItem);
        }

        private void ShowItem()
        {
            //var idCategory = Category.FindIdCategory(comboBoxEdit2);
            //var data = _item.GetItemByCategory(idCategory)
            //    .Select(x => new
            //    {
            //        Code = x.item_code,
            //        Item = x.item_name,
            //        Prize = string.Format(format: "{0}", arg0: x.item_prize.ToString("C", _culture)),
            //        AddByDate = string.Format(format: "{0}", arg0: x.added_by_date),
            //        EditByDate = string.Format(format: "{0}", arg0: x.edit_by_date),
            //    });

            var data = Category.GetMasterData().Select(x => new { x.category_name, x.Item.item_name });
            gridControl1.DataSource = data;
        }
        private void ComboBoxUpdateCategory()
        {
            // add vendor name
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.Properties.Items.AddRange(
                Category.GetCategories()
                    .Select(x => x.category_name)
                    .ToArray());
            comboBoxEdit2.SelectedIndex = 0;
        }
        private void ComboboxUpdateVendor()
        {
            //// add vendor name
            //comboBoxEdit1.Properties.Items.Clear();
            //comboBoxEdit1.Properties.Items.AddRange(
            //    _vendor.GetVendor()
            //        .Select(x => x.vendor_name)
            //        .ToArray());
            //comboBoxEdit1.SelectedIndex = 0;
        }
    }
 }