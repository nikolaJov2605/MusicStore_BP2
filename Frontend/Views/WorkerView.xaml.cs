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
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : Window
    {
        private static WorkerView workerViewInstance;
        private IWorker workerService;
        public WorkerView()
        {
            InitializeComponent();
            workerService = new WorkerService();
            dgWorkers.ItemsSource = workerService.GetAllWorkers();
        }

        public static WorkerView WorkerViewInstance
        {
            get
            {
                if (workerViewInstance == null)
                    workerViewInstance = new WorkerView();
                return workerViewInstance;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorker addWorkerWindow = AddWorker.AddWorkerInstance;
            addWorkerWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgWorkers.SelectedItem == null)
            {
                MessageBox.Show("Izaberite radnika za brisanje!");
                return;
            }

            RadnikModel model = workerService.GetWorker((RadnikModel)dgWorkers.SelectedItem);
            workerService.DeleteWorker(model);


            dgWorkers.ItemsSource = workerService.GetAllWorkers();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgWorkers.SelectedItem == null)
            {
                MessageBox.Show("Izaberite radnika za brisanje!");
                return;
            }

            RadnikModel model = workerService.GetWorker((RadnikModel)dgWorkers.SelectedItem);
            UpdateWorker updateWorkerWindow = UpdateWorker.UpdateWorkerInstance(model);
            updateWorkerWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            workerViewInstance = null;
        }
    }
}
