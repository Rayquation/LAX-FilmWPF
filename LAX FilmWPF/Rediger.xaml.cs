using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace LAX_FilmWPF
{
    /// <summary>
    /// Interaction logic for Rediger.xaml
    /// </summary>
    public partial class Rediger : Window
    {
        DatabaseLAX _db = new DatabaseLAX();
        int id;
        string title;
        string instruktør;
        int årstal;
        public Rediger(int movieId)
        {
            InitializeComponent();
            
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //Here we create a movie object wich has the id of the selected item
            Movie updateMovie = (from m in _db.Movie where m.Id == id select m).Single();
            updateMovie.Title = TitleBox.Text;
            updateMovie.Instruktør = InstruktørBox.Text;
            updateMovie.Årstal = Convert.ToInt32(ÅrstalBox.Text);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Movie.ToList();
            this.Hide();
        }
    }
}
