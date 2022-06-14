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
    /// Interaction logic for AddPurchase.xaml
    /// </summary>
    public partial class AddPurchase : Window
    {
        private static AddPurchase addPurchaseInstance;
        private IInstrument instrumentService;
        private IBuyer buyerService;
        private IWorker workerService;
        private IPurchase purchaseService;

        private InstrumentModel selectedInstrument;
        private RadnikModel selectedWorker;

        public AddPurchase()
        {
            InitializeComponent();
            instrumentService = new InstrumentService();
            buyerService = new BuyerService();
            workerService = new WorkerService();
            purchaseService = new PurchaseService();

            dgInstruments.ItemsSource = instrumentService.GetAllInstruments();
            dgBuyers.ItemsSource = buyerService.GetAllBuyers();
            dgWorkers.ItemsSource = workerService.GetSellers();
        }

        public static AddPurchase AddPurchaseInstance
        {
            get
            {
                if (addPurchaseInstance == null)
                    addPurchaseInstance = new AddPurchase();
                return addPurchaseInstance;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (dgInstruments.SelectedItem == null)
            {
                MessageBox.Show("Izaberite artikal za kupovinu!");
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



            PurchaseModel purchaseModel = new PurchaseModel(kupacModel.Id, kupacModel.Ime, kupacModel.Prezime, kupacModel.Jmbg, radnikModel.Id, radnikModel.Ime, radnikModel.Prezime,
                instrumentModel.Id, instrumentModel.Naziv, instrumentModel.Cena);

            purchaseService.AddPurchase(purchaseModel);

            this.Close();


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            addPurchaseInstance = null;
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
    }
}
