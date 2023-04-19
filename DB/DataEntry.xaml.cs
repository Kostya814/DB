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
        public Coach Coach { get; private set; }
        public DataEntry(SportMasterEntities db, object client)
        {
            InitializeComponent();
            this.db = db;
            genderBox.ItemsSource = db.Gender.ToList();
            var a =  client as Client;
            if (a is Client) 
            {
                Client = a;
                genderBox.SelectedItem = Client.Gender1;
                DataContext = Client;
                
                
            }
            var b = client as Coach;
            if (b is Coach)
            {
                Coach = b;
                genderBox.SelectedItem = Coach.Gender1;
                DataContext = Coach;
                
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Client != null) Client.Gender1 = genderBox.SelectedItem as Gender;
            if (Coach != null) Coach.Gender1 = genderBox.SelectedItem as Gender;

            DialogResult = true;
        }
    }
}
