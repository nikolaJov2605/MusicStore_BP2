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
using System.Windows.Shapes;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for AddInstrument.xaml
    /// </summary>
    public partial class AddInstrument : Window
    {
        private static AddInstrument addInstrumentInstance;

        private AddInstrument()
        {
            InitializeComponent();
            cbInstrumentType.ItemsSource = Constants.InstrumentTypes;
            cbGuitarType.ItemsSource = Constants.GuitarTypes;
            cbPianoType.ItemsSource = Constants.PianoTypes;
            cbKeyboardType.ItemsSource = Constants.KeyboardTypes;
            cbDrumsType.ItemsSource = Constants.DrumTypes;
        }

        public static AddInstrument AddInstrumentInstance
        {
            get
            {
                if (addInstrumentInstance == null)
                    addInstrumentInstance = new AddInstrument();
                return addInstrumentInstance;
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
        private void cbInstrumentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbInstrumentType.SelectedIndex)
            {
                case 0:
                    lblAdvice.Visibility = Visibility.Hidden;
                    gbGuitar.Visibility = Visibility.Visible;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    lblAdvice.Visibility = Visibility.Hidden;
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Visible;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    lblAdvice.Visibility = Visibility.Hidden;
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Visible;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    lblAdvice.Visibility = Visibility.Hidden;
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Visible;
                    break;
                default:
                    lblAdvice.Visibility = Visibility.Visible;
                    gbGuitar.Visibility = Visibility.Hidden;
                    gbPiano.Visibility = Visibility.Hidden;
                    gbKeyboard.Visibility = Visibility.Hidden;
                    gbDrums.Visibility = Visibility.Hidden;
                    break;

            }
        }

        private void btdAdd_Click(object sender, RoutedEventArgs e)
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
                    break;
                case 1:
                    model = new KlavirModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavir",
                        Double.Parse(tbPrice.Text), Int32.Parse(tbPianoWidth.Text), Int32.Parse(tbPianoHeight.Text), Int32.Parse(tbPianoDepth.Text),
                        Int32.Parse(tbPianoMass.Text), Int32.Parse(tbPianoToneCount.Text), cbPianoType.SelectedItem.ToString());
                    break;
                case 2:
                    model = new KlavijaturaModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavijatura",
                        Double.Parse(tbPrice.Text), Int32.Parse(tbKeyboardWidth.Text), Int32.Parse(tbKeyboardLength.Text), Int32.Parse(tbKeyboardDepth.Text),
                        Int32.Parse(tbKeyboardMass.Text), Int32.Parse(tbKeyboardToneCount.Text), cbKeyboardType.SelectedItem.ToString());
                    break;
                case 3:
                    model = new BubanjModel(tbName.Text, tbCreator.Text, tbDescription.Text, "Klavijatura",
                        Double.Parse(tbPrice.Text), cbDrumsType.SelectedItem.ToString());
                    break;
                default:
                    return;

            }

            IInstrument instrumentService = new InstrumentService();
            instrumentService.AddInstrument(model);

            MainWindow.MainWindowInstance.dgTable.ItemsSource = instrumentService.GetAllInstruments();

            this.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            addInstrumentInstance = null;
        }
    }
}
