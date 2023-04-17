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
            DataContext =  db.Coach.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            DataEntry win = new DataEntry(db, new Coach());
            if (win.ShowDialog() == true)
            {
                Coach client = win.Coach;
                db.Coach.Add(client);
                db.SaveChanges();

            }
            DataContext = db.Coach.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Coach client = usersList.SelectedItem as Coach;
            if (client == null) return;
            try
            {
                db.Coach.Remove(client);
                db.SaveChanges();
            }
            catch { }
            DataContext = db.Coach.ToList();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Client client = usersList.SelectedItem as Client;
            if (client == null) return;
            DataEntry entry = new DataEntry(db, new Client
            {
                id = client.id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MidleName = client.MidleName,
                Gender1 = client.Gender1,
                Number = client.Number,
            });
            if (entry.ShowDialog() == true)
            {
                client = db.Client.Find(entry.Coach.id);
                if (client != null)
                {
                    client.FirstName = entry.Coach.FirstName;
                    client.LastName = entry.Coach.LastName;
                    client.MidleName = entry.Coach.MidleName;
                    client.Gender1 = entry.Coach.Gender1;
                    client.Number = entry.Coach.Number;
                    db.SaveChanges();
                    usersList.Items.Refresh();
                }

            }
            DataContext = db.Coach.ToList();

        }
    }
}
