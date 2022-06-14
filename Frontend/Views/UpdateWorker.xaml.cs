using ServiceLayer.Interfaces;
using ServiceLayer.Models;
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
    /// Interaction logic for UpdateWorker.xaml
    /// </summary>
    public partial class UpdateWorker : Window
    {
        private static UpdateWorker updateWorkerInstance;
        private IWorker workerService;
        public static RadnikModel LoadedRadnik;

        public UpdateWorker()
        {
            InitializeComponent();
            workerService = new WorkerService();
            cbPosition.ItemsSource = Constants.WorkerPositions;
        }

        public UpdateWorker(RadnikModel radnik)
        {
            InitializeComponent();
            workerService = new WorkerService();
            LoadedRadnik = radnik;
            lblCaption.Content = radnik.Ime + " " + radnik.Prezime;

            cbPosition.ItemsSource = Constants.WorkerPositions;

            tbName.Text = radnik.Ime;
            tbLastName.Text = radnik.Prezime;
            tbId.Text = radnik.Brlk;
            if (radnik.Pozicija == "Prodavac")
                cbPosition.SelectedIndex = 0;
            else if (radnik.Pozicija == "Tehničar")
                cbPosition.SelectedIndex = 1;
            else
                cbPosition.SelectedIndex = 2;
            tbWorkingYears.Text = radnik.RadniStaz.ToString();
            tbSalary.Text = radnik.Plata.ToString();
        }

        public static UpdateWorker UpdateWorkerInstance(RadnikModel radnik)
        {
            if (updateWorkerInstance == null)
                updateWorkerInstance = new UpdateWorker(radnik);
            return updateWorkerInstance;
        }

        public static UpdateWorker UpdateWorkerInstanceProp
        {
            get
            {
                if (updateWorkerInstance == null)
                    updateWorkerInstance = new UpdateWorker();
                return updateWorkerInstance;
            }
        }

        private bool Validate()
        {
            bool valid = true;
            double someDoouble = 0;
            int someInt = 0;

            if (tbName.Text == String.Empty)
            {
                valid = false;
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbName.Text == String.Empty)
            {
                valid = false;
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbLastName.Text == String.Empty)
            {
                valid = false;
                tbLastName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbId.Text == String.Empty)
            {
                valid = false;
                tbId.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbSalary.Text == String.Empty || !Double.TryParse(tbSalary.Text, out someDoouble))
            {
                if (someDoouble == 0)
                {
                    valid = false;
                    tbSalary.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            if (tbWorkingYears.Text == String.Empty || !Int32.TryParse(tbWorkingYears.Text, out someInt))
            {
                if (someInt == 0)
                {
                    valid = false;
                    tbWorkingYears.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            if (cbPosition.SelectedItem == null)
            {
                valid = false;
                cbPosition.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            return valid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            RadnikModel radnikModel = new RadnikModel(tbId.Text, tbName.Text, tbLastName.Text, cbPosition.Text, Double.Parse(tbSalary.Text), Int32.Parse(tbWorkingYears.Text));
            radnikModel.Id = LoadedRadnik.Id;
            workerService.UpdateWorker(radnikModel);

            WorkerView.WorkerViewInstance.dgWorkers.ItemsSource = workerService.GetAllWorkers();

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            updateWorkerInstance = null;
        }
    }
}
