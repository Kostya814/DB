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

namespace DB
{
    /// <summary>
    /// Логика взаимодействия для SeasonTicketData.xaml
    /// </summary>
    public partial class SeasonTicketData : Window
    {
        SportMasterEntities db;
        public SeasonTicketData(SportMasterEntities db)
        {
            this.db = db;
            InitializeComponent();
            DataContext = db.SeasonTicket.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            SeasonTicket seasonTicket = usersList.SelectedItem as SeasonTicket;
            if (seasonTicket == null) return;
            
            try
            {
                db.SeasonTicket.Remove(seasonTicket);
                db.SaveChanges(); 
            }
            catch 
            { 
                MessageBox.Show("Ошибка удаления");
            }
            DataContext = db.SeasonTicket.ToList();

        }
    }
}
