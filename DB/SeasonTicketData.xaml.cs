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
        public SeasonTicketData(SportMasterEntities db)
        {
            InitializeComponent();
            DataContext = db.SeasonTicket.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
