using Frontend.Views;
using ServiceLayer.Interfaces;
using ServiceLayer.Models.Instruments;
using ServiceLayer.Services;
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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> Categories = new List<string>() {"Svi instrumenti", "Gitare", "\tKlasične gitare", "\tAkustične gitare", "\tElektrične gitare", "\tBas gitare",
                                                                    "Klaviri", "\tElektrični klaviri", "\tPianino", "\tKoncertni klaviri",
                                                                    "Klavijature", "\tŠkolske klavijature", "\tAranžerske klavijature", 
                                                                    "Bubnjevi", "\tAkustični bubnjevi", "\tElektronski bubnjevi" };
        IInstrument instrumentService;

        private static MainWindow mainWindowInstance;

        public static MainWindow MainWindowInstance
        {
            get
            {
                return mainWindowInstance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            mainWindowInstance = this;
            lbCategories.ItemsSource = Categories;
            instrumentService = new InstrumentService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<InstrumentModel> list = instrumentService.GetAllInstruments();
            dgTable.ItemsSource = list;
            /*foreach(var item in list)
            {
                dgTable.Items.Add(item);
            }*/
        }

        private void btnAddInstrument_Click(object sender, RoutedEventArgs e)
        {
            AddInstrument addInstrumentWindow = AddInstrument.AddInstrumentInstance;
            addInstrumentWindow.Show();
        }

        private void btnUpdateInstrument_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem == null)
            {
                MessageBox.Show("Izaberite artikal za izmenu!");
                return;
            }

            InstrumentModel model = instrumentService.GetInstrument((InstrumentModel)dgTable.SelectedItem);

            UpdateInstrument updateInstrumentWindow = UpdateInstrument.UpdateInstrumentWindowInstance(model);

            updateInstrumentWindow.Show();

        }

        private void btnDeleteInstrument_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem == null)
            {
                MessageBox.Show("Izaberite artikal za brisanje!");
                return;
            }

            InstrumentModel model = instrumentService.GetInstrument((InstrumentModel)dgTable.SelectedItem);
            instrumentService.DeleteInstrument(model);

            dgTable.ItemsSource = instrumentService.GetAllInstruments();
        }

        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string criteria = lbCategories.SelectedItem.ToString();

            dgTable.ItemsSource = instrumentService.FilterInstruments(criteria);
        }

        private void dgTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgTable.SelectedItem == null)
            {
                return;
            }
            InstrumentModel model = instrumentService.GetInstrument((InstrumentModel)dgTable.SelectedItem);

            ViewInstrument viewInstrumentWindow = new ViewInstrument(model);
            viewInstrumentWindow.Show();
        }
    }
}
