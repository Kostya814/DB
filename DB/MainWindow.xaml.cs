using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportMasterEntities db;
        public ObservableCollection<Client> Clients { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            db = new SportMasterEntities();
            Clients = new ObservableCollection<Client>(db.Client);
            usersList.ItemsSource = Clients;

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            DataEntry win = new DataEntry(db, new Client());
            if (win.ShowDialog() == true)
            {
                Client client = win.Client;
                db.Client.Add(client);
                try 
                { 
                    db.SaveChanges(); 
                }
                catch { }                             
                Update();

            }
            //DataContext = db.Client.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Client client = usersList.SelectedItem as Client;
            if (client == null) return;
            try
            {
                db.Client.Remove(client);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            DataContext = db.Client.ToList();
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
                client = db.Client.Find(entry.Client.id);
                if (client != null)
                {
                    client.FirstName = entry.Client.FirstName;
                    client.LastName = entry.Client.LastName;
                    client.MidleName = entry.Client.MidleName;
                    client.Gender1 = entry.Client.Gender1;
                    client.Number = entry.Client.Number;
                    db.SaveChanges();
                    usersList.Items.Refresh();
                }

            }
            DataContext = db.Client.ToList();

        }

        private void Update()
        {
            Clients = new ObservableCollection<Client>(db.Client);
            usersList.ItemsSource = Clients;
        }

        private void OpenCoach(object sender, RoutedEventArgs e)
        {
            Clientxaml clientxaml = new Clientxaml(db);
            clientxaml.Show();
        }

        private void OpenSeasonTicket(object sender, RoutedEventArgs e)
        {
            SeasonTicketData ticket = new SeasonTicketData(db);
            ticket.Show();
        }

        private void OpenTrainingPlan(object sender, RoutedEventArgs e)
        {
            PlanTraining planTraining = new PlanTraining(db);
            planTraining.Show();
        }

        private void OpenTypeOfTraining(object sender, RoutedEventArgs e)
        {

        }

        private void OpenWorkout(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, System.EventArgs e)
        {

        }
    }
}
