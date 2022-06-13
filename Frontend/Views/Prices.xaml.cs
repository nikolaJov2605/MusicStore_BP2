using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Prices.xaml
    /// </summary>
    public partial class Prices : Window
    {
        private static Prices pricesWindowInstance;
        private List<CenaModel> LoadedList;

        IPrice priceService;
        IInstrument instrumentService;

        public Prices()
        {
            InitializeComponent();
            priceService = new PriceService();
            instrumentService = new InstrumentService();
        }

        private Prices(List<CenaModel> cene)
        {
            InitializeComponent();

            priceService = new PriceService();
            instrumentService = new InstrumentService();

            LoadedList = cene;
            dgPrices.ItemsSource = LoadedList;
            lblCaption.Content = UpdateInstrument.LoadedInstrument.Naziv;
        }

        public static Prices PricesWindowInstance(List<CenaModel> cene)
        {
            if (pricesWindowInstance == null)
                pricesWindowInstance = new Prices(cene);
            return pricesWindowInstance;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            pricesWindowInstance = null;
        }

        private void btnAddPrice_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbAmmount.Text) || String.IsNullOrEmpty(dpDateStart.Text) || String.IsNullOrEmpty(dpDateEnd.Text))
                return;

            double ammount;
            Double.TryParse(tbAmmount.Text, out ammount);
            if (ammount == 0)
                return;

            CenaModel cenaModel = new CenaModel(ammount, dpDateStart.Text, dpDateEnd.Text);

            List<CenaModel> prices = instrumentService.GetPricesForInstrument(UpdateInstrument.LoadedInstrument.Id);

            if (DateTime.Parse(cenaModel.DatumPocetka) > DateTime.Parse(cenaModel.DatumZavrsetka))
            {
                MessageBox.Show("Nevalidan unos!");
                return;
            }

            if (prices.Find(x => DateTime.Parse(x.DatumZavrsetka) > DateTime.Parse(cenaModel.DatumPocetka)) != null)
            {
                MessageBox.Show("Već postoji cena za uneti vremenski opseg");
                return;
            }

            priceService.AddNewPrice(cenaModel, UpdateInstrument.LoadedInstrument);

            dgPrices.ItemsSource = instrumentService.GetPricesForInstrument(UpdateInstrument.LoadedInstrument.Id);

            List<CenaModel> listaCena = instrumentService.GetPricesForInstrument(UpdateInstrument.LoadedInstrument.Id);

        }
    }
}
