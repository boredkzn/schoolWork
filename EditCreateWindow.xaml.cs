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
    /// Логика взаимодействия для EditCreateWindow.xaml
    /// </summary>
    public partial class EditCreateWindow : Window
    {
        schoolEntities db = new schoolEntities();

        Service _service;

        bool _isEdit;

        private string _imagePath;

        public EditCreateWindow(Service service, bool isEdit)
        {
            InitializeComponent();

            _service = service;
            _isEdit = isEdit;
            EditCreateItem.DataContext = service;

            if (isEdit)
                IdLabel.Content = "ID: " + service.Id;
            else
                AddOtherPhotoButton.Visibility = Visibility.Hidden;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(MinutesTextBox.Text) < 2400 || int.Parse(MinutesTextBox.Text) > 0)
            {
                if (_isEdit)
                {
                    if (db.Service.ToList().Find(x => x.Name == _service.Name) == null)
                    {
                        var editItem = db.Service.ToList().Find(x => x.Id == _service.Id);
                        editItem.Name = _service.Name;
                        editItem.FullDescription = _service.FullDescription;
                        editItem.Cost = _service.Cost;
                        editItem.Sale = _service.Sale;

                        _service.Countinios = int.Parse(MinutesTextBox.Text);
                        if (_imagePath.Any())
                            editItem.MainPhoto = _imagePath;

                        db.SaveChanges();
                        MessageBox.Show("Успешно сохранено");
                    }
                }
                else
                {
                    if (db.Service.ToList().Find(x => x.Name == _service.Name) == null)
                    {
                        _service.Id = db.Service.ToList().Select(f=>f.Id).Max() + 1;
                        _service.MainPhoto = _imagePath;
                        _service.Name = NameTextBox.Text;
                        _service.FullDescription = DescriptionTextBox.Text;
                        _service.Cost = int.Parse(CostTextBox.Text);
                        _service.Countinios = int.Parse(MinutesTextBox.Text);
                        _service.Sale = int.Parse(SaleTextBox.Text);
                        db.Service.Add(_service);
                        db.SaveChanges();

                        _isEdit = true;
                        AddOtherPhotoButton.Visibility = Visibility.Visible;
                        IdLabel.Content = "ID: " + _service.Id;
                        MessageBox.Show("Успешно создано!");
                    }
                    else
                        MessageBox.Show("Такое имя уже есть, попробуйте другое");
                }
            }
            else
                MessageBox.Show("Время истекло");
        }

        private void EditPhotoButton_Click(object sender, RoutedEventArgs e)
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
                Photo.Source = bi;
                var pr = db.Service.ToList().Find(f => f.Id == _service.Id);
                if (pr == null)
                    _imagePath = opFD.SafeFileName;
                else
                {
                    pr.MainPhoto = opFD.SafeFileName;
                    db.SaveChanges();
                }

                EditCreateItem.DataContext = pr;
            }
            catch (Exception ex)
            {

            }
        }

        private void AddOtherPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new ServiceOtherPhotoWindow(_service.Id).Show();
        }
    }
}
