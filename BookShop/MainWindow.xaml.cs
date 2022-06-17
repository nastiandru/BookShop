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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Order> orderedBooks = new ObservableCollection<Order>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_Books.ItemsSource = App._books;
        }

        private void Btn_add(object sender, RoutedEventArgs e)
        {
            int maxID = 0;
            foreach (var item in App._books)
            {
                maxID = maxID + 1;
            }

            var newBook = new Book
            {
                title = "Add your title",
                timePeriod = 0000,
                author = " Your Author",
                edition = "Book edition",
                Id = maxID + 1,
                Summary = "Your Book information here"
            };
            App._books.Add(newBook);
            Lbx_Books.SelectedItem = newBook;
            Lbx_Books.ScrollIntoView(newBook);
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Books.SelectedItem as Book;

            Inventory.WriteXML<ObservableCollection<Book>>(App._books, "BookInventory.xml");
        }

        private void Btn_Borrow(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Books.SelectedItem as Book;

            if (itm == null)
            {
                MessageBox.Show("Please select an item to be borrowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                foreach (var item in App._finalOrders)
                {
                    if (item.BookID == itm.Id)
                    {
                        MessageBox.Show("This book is already borrowed", "We are Sorry", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    //else if(item.BookID != itm.Id)
                    //{
                    //    BorrowBook(Lbx_Books, Lbx_borrowBook);

                    //}

                }
                foreach (var item in App._finalOrders)
                {
                    if (item.BookID != itm.Id)
                    {
                        BorrowBook(Lbx_Books, Lbx_borrowBook);
                        break;
                    }
                }

            }



            //BorrowBook(Lbx_Books, Lbx_borrowBook);

        }

        private void BorrowBook(ListBox lbx_Books, ListBox lbx_borrowBook)
        {
            var selectedBooks = lbx_Books.SelectedItems;
            foreach (var item in selectedBooks)
            {
                lbx_borrowBook.Items.Add(item);

            }

        }

        private void Btn_clear(object sender, RoutedEventArgs e)
        {
            var item = Lbx_borrowBook.SelectedItem as Book;
            if (item == null)
            {
                MessageBoxResult res;
                res = MessageBox.Show("Select an item to Delete", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult res2;
                res2 = MessageBox.Show("Are you sure you want to clear selection?", "Careful", MessageBoxButton.YesNo);
                if (res2 == MessageBoxResult.Yes)
                {
                    Lbx_borrowBook.Items.Remove(Lbx_borrowBook.SelectedItem);

                }
            }

        }

        private void Btn_OrderPage(object sender, RoutedEventArgs e)
        {
            var listBoxItems = Lbx_borrowBook.Items;

            if (listBoxItems.Count > 0)
            {

                foreach (var item in listBoxItems)
                {

                    orderedBooks.Add(new Order
                    {
                        title = (item as Book).title,
                        ID = (item as Book).Id
                    });
                    var newOrder = new FinalOrder { Title = (item as Book).title, BookID = (item as Book).Id };
                    App._finalOrders.Add(newOrder);


                }


                var win = new OrderManagement();
                win.ShowDialog();
                win.Owner = this;
                //loop list and add to Orders.xml

                //var doc = XDocument.Load("Orders.xml");

                //var selectedBooks = Lbx_borrowBook.Items;
                //foreach (var item in selectedBooks)
                //{
                //    var newElement = new XElement("title");
                //}

            }
            else
            {
                MessageBox.Show("Please select an item to be borrowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            // when you navigate to a new screen it opens by centering itself to the owner,
            // in this case Wpf demo is owner to anotherLbx

            //var finalBooks = Lbx_borrowBook.Items;
            //foreach (var item in finalBooks)
            //{
            //    //Lbx_Order.Items.Add(item);
            //    OrderManagement order = new OrderManagement();

            //    order.Show();
            //}
            //order.Show();

            //var win = new OrderManagement();
            //win.ShowDialog();
            //win.Owner = this;
        }

        private void Tbx_Filter_textchanged(object sender, TextChangedEventArgs e)
        {
            var lst = from m in App._books where m.title.ToLower().Contains(Tbx_Filter.Text.ToLower()) select m;
            Lbx_Books.ItemsSource = lst;
        }

        private void Btn_return(object sender, RoutedEventArgs e)
        {
            var win = new OrderManagement();
            win.ShowDialog();
            win.Owner = this;
        }
    }
}
