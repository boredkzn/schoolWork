using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace schoolWork
{
    /// <summary>
    /// Логика взаимодействия для ServiceOtherPhotoWindow.xaml
    /// </summary>
    public partial class ServiceOtherPhotoWindow : Window
    {
        schoolEntities db = new schoolEntities();

        int _parentId;

        public ServiceOtherPhotoWindow(int parentId)
        {
            InitializeComponent();
            _parentId = parentId;
            PhotosList.ItemsSource = db.ServiceOtherPhoto.ToList().FindAll(x => x.IdService == parentId);
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opFD = new OpenFileDialog();
                opFD.ShowDialog();
                var imag = opFD.FileName;
                string dest = "C:\\Users\\User\\source\\repos\\schoolWork\\schoolWork\\schoolWork\\Photos\\" + System.IO.Path.GetFileName(imag);
                File.Copy(imag, dest);
                Image image = new Image();
                var bi = new BitmapImage(new Uri(dest));
                var newItem = new ServiceOtherPhoto();
                newItem.Id = db.ServiceOtherPhoto.ToList().Count + 1;
                newItem.IdService = _parentId;
                newItem.Photo = opFD.SafeFileName;
                db.ServiceOtherPhoto.Add(newItem);
                db.SaveChanges();


                PhotosList.ItemsSource = db.ServiceOtherPhoto.ToList().FindAll(x => x.IdService == _parentId);
            }
            catch (Exception ex)
            {

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EditCreateWindow(db.Service.ToList().Find(x => x.Id == _parentId), true).Show();
        }
    }
}
