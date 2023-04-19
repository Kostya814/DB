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
    /// Логика взаимодействия для PlanTraining.xaml
    /// </summary>
    public partial class PlanTraining : Window
    {
        SportMasterEntities db;
        
        public PlanTraining(SportMasterEntities db)
        {
            InitializeComponent();
            this.db = db;
            Update();
        }
        private void Update()
        {
            
            planList.DataContext = db.TypeOfTraining.ToList();
        }

        private void planList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (planList.SelectedItem == null) return;
            TypeOfTraining typeOfTraining = planList.SelectedItem as TypeOfTraining;
            if (typeOfTraining == null) return;
            stepsPlanRichBox.DataContext = typeOfTraining.TrainingPlan;
            
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void stepsPlanRichBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            save.Visibility = Visibility.Visible;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
