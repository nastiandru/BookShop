using BookShop.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookShop
{
    /// <summary>
    /// Логика взаимодействия для OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        public OrderManagement()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            Lbx_Orders.ItemsSource = App._finalOrders;
            //Lbx_summary.ItemsSource = App._finalOrders;


        }

        private void Btn_addOrder(object sender, RoutedEventArgs e)
        {

            var itm = Lbx_Orders.SelectedItem as FinalOrder;

            Inventory.WriteXML<ObservableCollection<FinalOrder>>(App._finalOrders, "FinalOrders.xml");

        }

        private void Btn_saveUser(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Orders.SelectedItem as FinalOrder;
            FinalOrder fBook = new FinalOrder();
            if (itm == null)
            {
                MessageBox.Show("Please select a book to enter dates", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                fBook.Title = (itm as FinalOrder).Title;
                fBook.firstName = Tbx_userName.Text;
                fBook.Email = Tbx_Email.Text;
                fBook.BookID = (itm as FinalOrder).BookID;
                fBook.From = (DateTime)Date_From.SelectedDate;
                fBook.To = (DateTime)Date_to.SelectedDate;

                //Lbx_Orders.ItemsSource = null;
                //Lbx_Orders.ItemsSource = fBook;

                Lbx_Orders.ScrollIntoView(fBook);
            }

        }

        private void Btn_returnOrder(object sender, RoutedEventArgs e)
        {

            var itemToRemove = Lbx_Orders.SelectedItem as FinalOrder;
            App._finalOrders.Remove(itemToRemove);


        }
    }
}
