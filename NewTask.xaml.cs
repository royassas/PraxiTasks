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

namespace PraxiTasks
{
    /// <summary>
    /// Interaktionslogik für NewTask.xaml
    /// </summary>
    /// 
    public partial class NewTask : Window
    {
        public List<KategorieModel> cats = new List<KategorieModel>();
        public List<BenutzerModel> users = new List<BenutzerModel>();
        public NewTask()
        {
            InitializeComponent();
            cats = SqliteDataAccess.LoadCategories();
            cb_categories.ItemsSource = cats;
            users = SqliteDataAccess.LoadPeople();
            cb_main.ItemsSource = users;
            cb_sub.ItemsSource = users;
            cb_subsub.ItemsSource = users;
        }
    }
}
