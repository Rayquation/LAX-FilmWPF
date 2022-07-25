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
using System.Data.SqlClient;
using LAX_FilmWPF;
using System.ComponentModel;

namespace LAX_FilmWPF
{
    /// <summary>
    /// Interaction logic for Opret.xaml
    /// </summary>
    public partial class Opret : Window
    {
        DatabaseLAX _db = new DatabaseLAX();
        internal Opret()
        {
            InitializeComponent();
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Here we clear the boxes
            TitleBox.Clear();
            InstruktørBox.Clear();
            ÅrstalBox.Clear();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //Creating a new movie object
            Movie newMovie = new Movie()
            {
                Title = TitleBox.Text,
                Instruktør = InstruktørBox.Text,
                Årstal = Convert.ToInt32(ÅrstalBox.Text)
        };
            //Add the new movie to the table
            _db.Movie.Add(newMovie);
            _db.SaveChanges();
            //Add the new changes to the mainwindow grid
            MainWindow.datagrid.ItemsSource = _db.Movie.ToList();
            TitleBox.Clear();
            InstruktørBox.Clear();
            ÅrstalBox.Clear();
        }
    }
}
