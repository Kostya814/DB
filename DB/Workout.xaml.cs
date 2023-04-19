﻿using System;
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
    /// Логика взаимодействия для Workout.xaml
    /// </summary>
    public partial class Workout : Window
    {
        SportMasterEntities db;
        
        public Workout(SportMasterEntities db)
        {
            this.db = db;
            InitializeComponent();
            
        }
    }
}
