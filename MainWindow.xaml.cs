using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Diagnostics;

namespace PraxiTasks
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<AufgabenModel> tasks = new List<AufgabenModel>();
        public List<AufgabenModel> detailtask = new List<AufgabenModel>();

        public int activeItem = 0;
        public MainWindow()
        {
            InitializeComponent();
            tasks = SqliteDataAccess.LoadTasks();

            Aufgaben.ItemsSource = null;
            Aufgaben.ItemsSource = tasks;
        }

        private void ConfirmDone(object sender, RoutedEventArgs e)
        {
            if (activeItem != 0)
            {
                MessageBox.Show("Dein Logeintrag für die ID " + activeItem.ToString() + " wird geschrieben.");
            }
            else
            {
                MessageBox.Show("Zuerst ein Aufgabe auswählen du Tschooli!");
            }
        }

        private void viewDetails(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tasks.Count!=0)
            {
                detailtask = SqliteDataAccess.LoadTask(Aufgaben.SelectedValue.ToString());
                if (detailtask != null)
                {
                    activeItem = detailtask[0].Id;
                    lab_Category.Content = detailtask[0].CategoryString;
                    lab_Title.Content = detailtask[0].Title;
                    lab_Mainuser.Content = detailtask[0].Mainuser;
                    lab_Subuser.Content = detailtask[0].Subuser;
                    lab_Subsubuser.Content = detailtask[0].Subsubuser;
                    TimeSpan t = TimeSpan.FromSeconds(detailtask[0].Frequency);
                    lab_Frequency.Content = t.ToString(@"hh\:mm\:ss\:fff");
                    lab_Description.Text = detailtask[0].Description;
                }
                else
                {
                    MessageBox.Show("Der gewählte Eintrag existiert nicht mehr. Daten werden neu geladen", "Fehler beim Abrufen des Datenbankeintrags");
                    SqliteDataAccess.LoadTasks();
                }
            }
        }


        private void btn_newtask(object sender, RoutedEventArgs e)
        {
            NewTask sw_newtask = new NewTask();
            sw_newtask.Show();
        }

        private void Aufgaben_Loaded(object sender, RoutedEventArgs e)
        {
            if (Aufgaben.Items.Count != 0)
            {
                (Aufgaben.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem).IsSelected = true;
                (Aufgaben.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem).Focus();

            }
        }

        private void btn_alltasks(object sender, RoutedEventArgs e)
        {
            AllTasks sw_alltask = new AllTasks();
            sw_alltask.Show();
        }
    }
}

