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
using Xceed.Wpf.Toolkit;

namespace PraxiTasks
{
    /// <summary>
    /// Interaktionslogik für AllTasks.xaml
    /// </summary>
    public partial class AllTasks : Window
    {
        public List<AufgabenModel> tasks = new List<AufgabenModel>();
        public List<KategorieModel> cats = new List<KategorieModel>();
        public List<BenutzerModel> users = new List<BenutzerModel>();
        public AllTasks()
        {
            InitializeComponent();
            tasks = SqliteDataAccess.LoadTasks();
            dg_tasks.ItemsSource = tasks;
            cats = SqliteDataAccess.LoadCategories();
            dgcbc.ItemsSource = cats;
            users = SqliteDataAccess.LoadPeople();
            dgverantwortlich.ItemsSource = users;
            dgsub.ItemsSource = users;
            dgsubsub.ItemsSource = users;
        }
    }
}
