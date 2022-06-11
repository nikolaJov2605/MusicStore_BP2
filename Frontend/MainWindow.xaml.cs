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
        private static List<string> Categories = new List<string>() { "Gitare", "\tKlasične gitare", "\tAkustične gitare", "\tElektrične gitare", "\tBas gitare",
                                                                    "Klaviri", "\tElektrični klaviri", "\tPianino", "\tKoncertni klaviri",
                                                                    "Klavijature", "\tŠkolske klavijature", "\tAranžerske klavijature", 
                                                                    "Bubnjevi", "\tAkustični bubnjevi", "\tElektronski bubnjevi" };
        IInstrument instrumentService;

        public MainWindow()
        {
            InitializeComponent();
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
    }
}
