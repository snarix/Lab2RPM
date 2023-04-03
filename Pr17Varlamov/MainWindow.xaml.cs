using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using static Pr17Varlamov.Edit;

namespace Pr17Varlamov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }

        ObuvvEntities db = ObuvvEntities.GetContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Obuvv.Load();
            Grid1.ItemsSource = db.Obuvv.Local.ToBindingList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.ShowDialog();
            Grid1.Focus();

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            int indexRow = Grid1.SelectedIndex;
            if (indexRow != -1)
            {
                Obuvv row = (Obuvv)Grid1.Items[indexRow];
                Data.Id = row.id;
                Edit f = new Edit();
                f.ShowDialog();
                Grid1.Items.Refresh();
                Grid1.Focus();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                         MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Obuvv row = (Obuvv)Grid1.SelectedItems[0];
                    db.Obuvv.Remove(row);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

       
        private void Exit(object sender, RoutedEventArgs e)
        {

        }

        private void Search(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Grid1.Items.Count; i++)
            {
                var row = (Obuvv)Grid1.Items[i];
                string findContent = row.NaimObuv;
                try
                {
                    if (findContent != null && findContent.Contains(Poisk.Text))
                    {
                        object item = Grid1.Items[i];
                        Grid1.SelectedItem = item;
                        Grid1.ScrollIntoView(item);
                        Grid1.Focus();
                        break;
                    }
                }
                catch { }
            }
        }
    }
}
