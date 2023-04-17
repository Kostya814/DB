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
    /// Логика взаимодействия для DataEntry.xaml
    /// </summary>
    public partial class DataEntry : Window
    {
        SportMasterEntities db;
        public Client Client { get; private set; }
        public DataEntry(SportMasterEntities db, Client client)
        {
            InitializeComponent();
            this.db = db;
            genderBox.ItemsSource = db.Gender.ToList();
            Client = client;
            DataContext = Client;
            Client.Gender1 = genderBox.SelectedItem as Gender;
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
