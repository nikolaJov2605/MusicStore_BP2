using ServiceLayer.Interfaces;
using ServiceLayer.Models;
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
using System.Windows.Shapes;

namespace Frontend.Views
{
    /// <summary>
    /// Interaction logic for AddTest.xaml
    /// </summary>
    public partial class AddTest : Window
    {
        private static AddTest addTestInstance;
        private IInstrument instrumentService;
        private IBuyer buyerService;
        private IWorker workerService;
        private ITest testService;


        public AddTest()
        {
            InitializeComponent();
            instrumentService = new InstrumentService();
            buyerService = new BuyerService();
            workerService = new WorkerService();
            testService = new TestService();

            dgInstruments.ItemsSource = instrumentService.GetAllInstruments();
            dgBuyers.ItemsSource = buyerService.GetAllBuyers();
            dgWorkers.ItemsSource = workerService.GetTechs();
        }

        public static AddTest AddTestInstance
        {
            get
            {
                if (addTestInstance == null)
                    addTestInstance = new AddTest();
                return addTestInstance;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (dgInstruments.SelectedItem == null)
            {
                MessageBox.Show("Izaberite artikal za kupovinu!");
                return;
            }
            if (dgWorkers.SelectedItem == null)
            {
                MessageBox.Show("Izaberite odgovornog prodavca");
                return;
            }
            KupacModel model = new KupacModel(tbJmbg.Text, tbBuyerName.Text, tbBuyerLastName.Text);

            InstrumentModel instrumentModel = instrumentService.GetInstrument((InstrumentModel)dgInstruments.SelectedItem);
            RadnikModel radnikModel = workerService.GetWorker((RadnikModel)dgWorkers.SelectedItem);

            KupacModel kupacModel = buyerService.GetBuyerByJMBG(model);
            if (kupacModel == null)
            {
                buyerService.AddBuyer(model);
                kupacModel = buyerService.GetBuyer(model);
            }

            TestModel testModel = new TestModel(instrumentModel.Id, instrumentModel.Naziv, 
                radnikModel.Id, radnikModel.Ime, radnikModel.Prezime, kupacModel.Id, kupacModel.Ime, kupacModel.Prezime, kupacModel.Jmbg);

            testService.AddTest(testModel);

            this.Close();

        }

        private void dgBuyers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBuyers.SelectedItem == null)
            {
                return;
            }

            KupacModel kupacModel = buyerService.GetBuyer((KupacModel)dgBuyers.SelectedItem);

            tbBuyerName.Text = kupacModel.Ime;
            tbBuyerLastName.Text = kupacModel.Prezime;
            tbJmbg.Text = kupacModel.Jmbg;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            addTestInstance = null;
        }
    }
}
