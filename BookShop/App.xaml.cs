using BookShop.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Book> _books;
        public static ObservableCollection<FinalOrder> _finalOrders;
        //public static List<Order> _orders;
        //public static ObservableCollection<Order> _orders;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //_orders = Inventory.ReadXML<ObservableCollection<Order>>("Orders.xml");

            _finalOrders = Inventory.ReadXML<ObservableCollection<FinalOrder>>("FinalOrders.xml");
            _books = Inventory.ReadXML<ObservableCollection<Book>>("BookInventory.xml");

            if (_finalOrders == null)
            {
                _finalOrders = new ObservableCollection<FinalOrder>();
            }
        }
    }
}
