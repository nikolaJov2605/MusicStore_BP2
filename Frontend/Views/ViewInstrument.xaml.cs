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

namespace Frontend.Views
{
    /// <summary>
    /// Interaction logic for ViewInstrument.xaml
    /// </summary>
    public partial class ViewInstrument : Window
    {
        private static ViewInstrument viewInstrumentWindowInstance;
        public static InstrumentModel LoadedInstrument;

        private IInstrument instrumentService;
        public ViewInstrument()
        {
            InitializeComponent();

            instrumentService = new InstrumentService();
        }

        public ViewInstrument(InstrumentModel instrument)
        {
            InitializeComponent();

            instrumentService = new InstrumentService();

            LoadedInstrument = instrument;

            lblCaption.Content = instrument.Naziv;
            labelName.Content = instrument.Naziv;
            labelCreator.Content = instrument.Proizvodjac;
            labelDescription.Content = instrument.Opis;
            labelPrice.Content = instrument.Cena.ToString();

            switch (instrument.TipInstrumenta)
            {
                case "Gitara":
                    guitarDetails.Visibility = Visibility.Visible;
                    pianoDetails.Visibility = Visibility.Hidden;
                    keyboardDetails.Visibility = Visibility.Hidden;
                    drumDetails.Visibility = Visibility.Hidden;
                    labelInstrumentType.Content = "Gitara";
                    lblBody.Content = ((GitaraModel)instrument).MaterijalTrupa;
                    lblHead.Content = ((GitaraModel)instrument).MaterijalGlave;
                    lblNeck.Content = ((GitaraModel)instrument).MaterijalVrata;
                    lblFretCnt.Content = ((GitaraModel)instrument).BrojPragova.ToString();
                    string vrstaGitare = ((GitaraModel)instrument).VrstaGitare;
                    if (vrstaGitare == "Klasicna")
                    {
                        lblGuitarT.Content = "Klasična";
                    }
                    else if (vrstaGitare == "Akusticna")
                    {
                        lblGuitarT.Content = "Akustična";
                    }
                    else if (vrstaGitare == "Elektricna")
                    {
                        lblGuitarT.Content = "Električna";
                    }
                    else
                    {
                        lblGuitarT.Content = "Bas";
                    }

                    break;
                case "Klavir":
                    guitarDetails.Visibility = Visibility.Hidden;
                    pianoDetails.Visibility = Visibility.Visible;
                    keyboardDetails.Visibility = Visibility.Hidden;
                    drumDetails.Visibility = Visibility.Hidden;
                    labelInstrumentType.Content = "Klavir";
                    lblPWidth.Content = ((KlavirModel)instrument).Sirina.ToString();
                    lblPHeight.Content = ((KlavirModel)instrument).Visina.ToString();
                    lblPDepth.Content = ((KlavirModel)instrument).Dubina.ToString();
                    lblPMass.Content = ((KlavirModel)instrument).Masa.ToString();
                    lblPToneCount.Content = ((KlavirModel)instrument).BrojTonova.ToString();
                    string vrstaKlavira = ((KlavirModel)instrument).VrstaKlavira;
                    if (vrstaKlavira == "Elektricni")
                    {
                        lblPType.Content = "Električni";
                    }
                    else if (vrstaKlavira == "Pianino")
                    {
                        lblPType.Content = "Pianino";
                    }
                    else
                    {
                        lblPType.Content = "Koncertni";
                    }
                    break;
                case "Klavijatura":
                    guitarDetails.Visibility = Visibility.Hidden;
                    pianoDetails.Visibility = Visibility.Hidden;
                    keyboardDetails.Visibility = Visibility.Visible;
                    drumDetails.Visibility = Visibility.Hidden;
                    labelInstrumentType.Content = "Klavijatura";
                    lblKWidth.Content = ((KlavijaturaModel)instrument).Sirina.ToString();
                    lblKLength.Content = ((KlavijaturaModel)instrument).Duzina.ToString();
                    lblKDepth.Content = ((KlavijaturaModel)instrument).Dubina.ToString();
                    lblKMass.Content = ((KlavijaturaModel)instrument).Masa.ToString();
                    lblKToneCount.Content = ((KlavijaturaModel)instrument).BrojTonova.ToString();
                    string vrstaKlavijature = ((KlavijaturaModel)instrument).VrstaKlavijature;
                    if (vrstaKlavijature == "Skolska")
                    {
                        lblKType.Content = "Školska";
                    }
                    else
                    {
                        lblKType.Content = "Aranžerska";
                    }
                    break;
                case "Bubanj":
                    guitarDetails.Visibility = Visibility.Hidden;
                    pianoDetails.Visibility = Visibility.Hidden;
                    keyboardDetails.Visibility = Visibility.Hidden;
                    drumDetails.Visibility = Visibility.Visible;
                    labelInstrumentType.Content = "Bubanj";
                    string vrstaBubnja = ((BubanjModel)instrument).VrstaBubnja;
                    if (vrstaBubnja == "Akusticni")
                    {
                        lblDType.Content = "Akustični";
                    }
                    else
                    {
                        lblDType.Content = "Elektronski";
                    }
                    break;
            }
        }


        public static ViewInstrument ViewInstrumentWindowInstance
        {
            get
            {
                if (viewInstrumentWindowInstance == null)
                    viewInstrumentWindowInstance = new ViewInstrument();
                return viewInstrumentWindowInstance;
            }
        }
    }
}
