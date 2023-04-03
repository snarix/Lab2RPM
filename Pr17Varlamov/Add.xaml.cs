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
using System.Windows.Shapes;

namespace Pr17Varlamov
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            this.Height += 25;
        }

        ObuvvEntities db = ObuvvEntities.GetContext();
        Obuvv p1 = new Obuvv();

        private void Add_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (articul.Text.Length < 0) errors.AppendLine("Введите артикул");
            if (naimObuv.Text.Length == 0) errors.AppendLine("Введите наименование обуви");
            if (!int.TryParse(kolPar.Text, out int x)) errors.AppendLine("Введите количество");
            if(!int.TryParse(stoimOnePara.Text, out int y)) errors.AppendLine("Введите количество");
            if(!int.TryParse(razmerNalich.Text, out int z)) errors.AppendLine("Введите количество");
            if (nameFabrika.Text.Length == 0) errors.AppendLine("Введите наименование обуви");
            if (srok.Text.Length == 0) errors.AppendLine("Введите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            p1.Articul = articul.Text;
            p1.NaimObuv = naimObuv.Text;
            p1.KolvoPar = kolPar.Text;
            p1.StoimostOdnoiPari = stoimOnePara.Text;
            p1.RazmerVNalichii = razmerNalich.Text;
            p1.NameFabrika = nameFabrika.Text;
            p1.SrokPostavkiObuviVMagazin = srok.SelectedDate;

            try
            {
                db.Obuvv.Add(p1);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
