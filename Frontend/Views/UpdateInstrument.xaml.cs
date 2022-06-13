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
    /// Interaction logic for UpdateInstrument.xaml
    /// </summary>
    public partial class UpdateInstrument : Window
    {
        private static UpdateInstrument updateInstrumentWindowInstance;
        public static InstrumentModel LoadedInstrument;

        private IInstrument instrumentService;

        public UpdateInstrument()
        {
            InitializeComponent();

            instrumentService = new InstrumentService();

            cbInstrumentType.ItemsSource = Constants.InstrumentTypes;
            cbGuitarType.ItemsSource = Constants.GuitarTypes;
            cbPianoType.ItemsSource = Constants.PianoTypes;
            cbKeyboardType.ItemsSource = Constants.KeyboardTypes;
            cbDrumsType.ItemsSource = Constants.DrumTypes;
        }

        public UpdateInstrument(InstrumentModel instrument)
        {
            InitializeComponent();

            instrumentService = new InstrumentService();

            cbInstrumentType.ItemsSource = Constants.InstrumentTypes;
            cbGuitarType.ItemsSource = Constants.GuitarTypes;
            cbPianoType.ItemsSource = Constants.PianoTypes;
            cbKeyboardType.ItemsSource = Constants.KeyboardTypes;
            cbDrumsType.ItemsSource = Constants.DrumTypes;
            LoadedInstrument = instrument;

            tbName.Text = instrument.Naziv;
            tbCreator.Text = instrument.Proizvodjac;
            tbDescription.Text = instrument.Opis;
            tbPrice.Text = instrument.Cena.ToString();

            switch (instrument.TipInstrumenta)
            {
                case "Gitara":
                    gbGuitar.Visibility = Visibility.Visible;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    cbInstrumentType.SelectedIndex = 0;
                    tbBodyMaterial.Text = ((GitaraModel)instrument).MaterijalTrupa;
                    tbHeadMaterial.Text = ((GitaraModel)instrument).MaterijalGlave;
                    tbNeckMaterial.Text = ((GitaraModel)instrument).MaterijalVrata;
                    tbFretCount.Text = ((GitaraModel)instrument).BrojPragova.ToString();
                    string vrstaGitare = ((GitaraModel)instrument).VrstaGitare;
                    if (vrstaGitare == "Klasicna")
                    {
                        cbGuitarType.SelectedIndex = 0;
                    }
                    else if (vrstaGitare == "Akusticna")
                    {
                        cbGuitarType.SelectedIndex = 1;
                    }
                    else if (vrstaGitare == "Elektricna")
                    {
                        cbGuitarType.SelectedIndex = 2;
                    }
                    else
                    {
                        cbGuitarType.SelectedIndex = 3;
                    }

                    break;
                case "Klavir":
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Visible;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    cbInstrumentType.SelectedIndex = 1;
                    tbPianoWidth.Text = ((KlavirModel)instrument).Sirina.ToString();
                    tbPianoHeight.Text = ((KlavirModel)instrument).Visina.ToString();
                    tbPianoDepth.Text = ((KlavirModel)instrument).Dubina.ToString();
                    tbPianoMass.Text = ((KlavirModel)instrument).Masa.ToString();
                    tbPianoToneCount.Text = ((KlavirModel)instrument).BrojTonova.ToString();
                    string vrstaKlavira = ((KlavirModel)instrument).VrstaKlavira;
                    if (vrstaKlavira == "Elektricni")
                    {
                        cbPianoType.SelectedIndex = 0;
                    }
                    else if (vrstaKlavira == "Pianino")
                    {
                        cbPianoType.SelectedIndex = 1;
                    }
                    else
                    {
                        cbPianoType.SelectedIndex = 2;
                    }
                    break;
                case "Klavijatura":
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Visible;
                    gbDrums.Visibility = Visibility.Hidden;
                    cbInstrumentType.SelectedIndex = 2;
                    tbKeyboardWidth.Text = ((KlavijaturaModel)instrument).Sirina.ToString();
                    tbKeyboardLength.Text = ((KlavijaturaModel)instrument).Duzina.ToString();
                    tbKeyboardDepth.Text = ((KlavijaturaModel)instrument).Dubina.ToString();
                    tbKeyboardMass.Text = ((KlavijaturaModel)instrument).Masa.ToString();
                    tbKeyboardToneCount.Text = ((KlavijaturaModel)instrument).BrojTonova.ToString();
                    string vrstaKlavijature = ((KlavijaturaModel)instrument).VrstaKlavijature;
                    if (vrstaKlavijature == "Skolska")
                    {
                        cbKeyboardType.SelectedIndex = 0;
                    }
                    else
                    {
                        cbKeyboardType.SelectedIndex = 1;
                    }
                    break;
                case "Bubanj":
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Visible;
                    cbInstrumentType.SelectedIndex = 3;
                    string vrstaBubnja = ((BubanjModel)instrument).VrstaBubnja;
                    if (vrstaBubnja == "Akusticni")
                    {
                        cbDrumsType.SelectedIndex = 0;
                    }
                    else
                    {
                        cbDrumsType.SelectedIndex = 1;
                    }
                    break;
            }

        }

        public static UpdateInstrument UpdateInstrumentWindowInstance(InstrumentModel instrument)
        {
            if (updateInstrumentWindowInstance == null)
                updateInstrumentWindowInstance = new UpdateInstrument(instrument);
            return updateInstrumentWindowInstance;
        }

        public static UpdateInstrument UpdateInstrumentWindowInstanceProp
        {
            get
            {
                return updateInstrumentWindowInstance;
            }
            
        }


        private bool Validate()
        {
            bool valid = true;
            double price = 0;

            if (tbName.Text == String.Empty)
            {
                valid = false;
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbCreator.Text == String.Empty)
            {
                valid = false;
                tbCreator.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbDescription.Text == String.Empty)
            {
                valid = false;
                tbDescription.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (cbInstrumentType.SelectedItem == null)
            {
                valid = false;
                cbInstrumentType.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbPrice.Text == String.Empty || !Double.TryParse(tbPrice.Text, out price))
            {
                if (price == 0)
                {
                    valid = false;
                    tbPrice.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }


            int someInt = 0;
            switch (cbInstrumentType.SelectedIndex)
            {
                case 0:
                    if (tbBodyMaterial.Text == String.Empty)
                    {
                        valid = false;
                        tbBodyMaterial.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    if (tbNeckMaterial.Text == String.Empty)
                    {
                        valid = false;
                        tbNeckMaterial.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    if (tbHeadMaterial.Text == String.Empty)
                    {
                        valid = false;
                        tbHeadMaterial.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    if (tbFretCount.Text == String.Empty || !Int32.TryParse(tbFretCount.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbFretCount.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (cbGuitarType.SelectedItem == null)
                    {
                        valid = false;
                        cbGuitarType.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    break;
                case 1:
                    if (tbPianoWidth.Text == String.Empty || !Int32.TryParse(tbPianoWidth.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbPianoWidth.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbPianoHeight.Text == String.Empty || !Int32.TryParse(tbPianoHeight.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbPianoHeight.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbPianoDepth.Text == String.Empty || !Int32.TryParse(tbPianoDepth.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbPianoDepth.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbPianoToneCount.Text == String.Empty || !Int32.TryParse(tbPianoToneCount.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbPianoToneCount.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbPianoMass.Text == String.Empty || !Int32.TryParse(tbPianoMass.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbPianoMass.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (cbPianoType.SelectedItem == null)
                    {
                        valid = false;
                        cbPianoType.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    break;
                case 2:
                    if (tbKeyboardWidth.Text == String.Empty || !Int32.TryParse(tbKeyboardWidth.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbKeyboardWidth.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbKeyboardLength.Text == String.Empty || !Int32.TryParse(tbKeyboardLength.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbKeyboardLength.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbKeyboardDepth.Text == String.Empty || !Int32.TryParse(tbKeyboardDepth.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbKeyboardDepth.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbKeyboardToneCount.Text == String.Empty || !Int32.TryParse(tbKeyboardToneCount.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbKeyboardToneCount.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (tbKeyboardMass.Text == String.Empty || !Int32.TryParse(tbKeyboardMass.Text, out someInt))
                    {
                        if (someInt == 0)
                        {
                            valid = false;
                            tbKeyboardMass.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    if (cbKeyboardType.SelectedItem == null)
                    {
                        valid = false;
                        cbKeyboardType.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    break;
                case 3:
                    if (cbDrumsType.SelectedItem == null)
                    {
                        valid = false;
                        cbDrumsType.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    break;
                default:
                    valid = false;
                    cbInstrumentType.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;

            }

            return valid;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            updateInstrumentWindowInstance = null;
        }

        private void cbInstrumentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbInstrumentType.SelectedIndex)
            {
                case 0:
                    gbGuitar.Visibility = Visibility.Visible;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Visible;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Visible;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Visible;
                    break;
                default:
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;

            }
        }

        private void btdUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            InstrumentModel model;

            switch (cbInstrumentType.SelectedIndex)
            {
                case 0:
                    model = new GitaraModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Gitara",
                        Double.Parse(tbPrice.Text), tbHeadMaterial.Text, tbBodyMaterial.Text, tbNeckMaterial.Text, Int32.Parse(tbFretCount.Text),
                        cbGuitarType.SelectedItem.ToString());
                    model.Id = LoadedInstrument.Id;
                    break;
                case 1:
                    model = new KlavirModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavir",
                        Double.Parse(tbPrice.Text), Int32.Parse(tbPianoWidth.Text), Int32.Parse(tbPianoHeight.Text), Int32.Parse(tbPianoDepth.Text),
                        Int32.Parse(tbPianoMass.Text), Int32.Parse(tbPianoToneCount.Text), cbPianoType.SelectedItem.ToString());
                    model.Id = LoadedInstrument.Id;
                    break;
                case 2:
                    model = new KlavijaturaModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavijatura",
                        Double.Parse(tbPrice.Text), Int32.Parse(tbKeyboardWidth.Text), Int32.Parse(tbKeyboardLength.Text), Int32.Parse(tbKeyboardDepth.Text),
                        Int32.Parse(tbKeyboardMass.Text), Int32.Parse(tbKeyboardToneCount.Text), cbKeyboardType.SelectedItem.ToString());
                    model.Id = LoadedInstrument.Id;
                    break;
                case 3:
                    model = new BubanjModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavijatura",
                        Double.Parse(tbPrice.Text), cbDrumsType.SelectedItem.ToString());
                    model.Id = LoadedInstrument.Id;
                    break;
                default:
                    return;

            }

            instrumentService.UpdateInstrument(model);

            MainWindow.MainWindowInstance.dgTable.ItemsSource = instrumentService.GetAllInstruments();

            this.Close();

        }

        private void btnPrice_Click(object sender, RoutedEventArgs e)
        {
            InstrumentModel instrument = instrumentService.GetInstrument(LoadedInstrument);
            List<CenaModel> cene = instrumentService.GetPricesForInstrument(instrument.Id);

            Prices pricesWindow = Prices.PricesWindowInstance(cene);
            pricesWindow.Show();
        }
    }
}
