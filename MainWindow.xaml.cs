using System;
using System.Collections.Generic;
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

namespace schoolWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        schoolEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new schoolEntities();
            ListServices.ItemsSource = db.Service.ToList();
            order.ItemsSource = new List<string>()
            {
                "По возрастанию стоимости", "По убыванию стоимости"
            };
            percent.ItemsSource = new List<string>()
            {
                "0% - 5%", "5% - 15%", "15% - 30%", "30% - 70%", "70% - 100%"
            };
            var count = db.Service.ToList().Count();
            Counter.Content = $"{count} из {count}";
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByFilter();
        }

        private void order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetByFilter();
        }

        private void percent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetByFilter();
        }

        public void GetByFilter()
        {
            var allItems = db.Service.ToList();

            if (search.Text.Any())
            {
                allItems = allItems.FindAll(x => x.Name.Contains(search.Text) || x.FullDescription.Contains(search.Text));
            }

            switch (percent.SelectedIndex)
            {
                case 0:
                    allItems = allItems.ToList().FindAll(x => x.Sale < 5);
                    break;
                case 1:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 5 && x.Sale < 15);
                    break;
                case 2:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 15 && x.Sale < 30);
                    break;
                case 3:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 30 && x.Sale < 70);
                    break;
                case 4:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 70 && x.Sale < 100);
                    break;
            }

            switch (order.SelectedIndex)
            {
                case 0:
                    allItems = allItems.OrderBy(x => x.CostWithSale).ToList();
                    break;
                case 1:
                    allItems = allItems.OrderByDescending(x => x.CostWithSale).ToList();
                    break;
                
            }

            ListServices.ItemsSource = allItems;
            Counter.Content = allItems.Count + " из" + db.Service.ToList().Count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Service;
            new EditCreateWindow(item, true).Show();
            this.Hide();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int itemId = ((sender as Button).DataContext as Service).Id;
            var deleteItem = db.Service.ToList().Find(x => x.Id == itemId);
            db.Service.Remove(deleteItem);
            db.SaveChanges();
            ListServices.ItemsSource = db.Service.ToList();
            Counter.Content = db.Service.ToList().Count + " из " + db.Service.ToList().Count;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            new EditCreateWindow(new Service(), false).Show();
            this.Hide();
        }
    }
}
