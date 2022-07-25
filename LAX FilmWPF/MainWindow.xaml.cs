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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace LAX_FilmWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Make a new object for the database
        DatabaseLAX _db = new DatabaseLAX();
        //Make a datagrid
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            //We give our datagrid its items from the database
            myDataGrid.ItemsSource = _db.Movie.ToList();
            //The datagrid is equal to the datagridview
            datagrid = myDataGrid;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            //Here we create and open our window
            Opret Opretelse = new Opret();
            Opretelse.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Here we get the id of the movie that is selected
            int id = (myDataGrid.SelectedItem as Movie).Id;
            //Here we create a variable which is equals to the id
            var deleteMovie = _db.Movie.Where(m => m.Id == id).Single();
            //Here we remove the selected item
            _db.Movie.Remove(deleteMovie);
            //Here we save the changes to the database
            _db.SaveChanges();
            //Here we upload the new changes
            myDataGrid.ItemsSource = _db.Movie.ToList();
        }
        private void redigerBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Movie).Id;
            Rediger Upage = new Rediger(id);
            Upage.ShowDialog();
        }
    }
    internal class MyItem
    {
        public string Årstal { get; set; }
        public string Title { get; set; }
        public string Instruktør { get; set; }
    }
}
