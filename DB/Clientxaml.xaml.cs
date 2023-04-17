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
    /// Логика взаимодействия для Clientxaml.xaml
    /// </summary>
    public partial class Clientxaml : Window
    {
        SportMasterEntities db;
        public Clientxaml(SportMasterEntities db)
        {
            InitializeComponent();
            this.db = db;
            usersList.ItemsSource =  db.Coach.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
