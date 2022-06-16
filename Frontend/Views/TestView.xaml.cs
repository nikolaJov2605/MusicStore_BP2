using ServiceLayer.Interfaces;
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
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : Window
    {
        private static TestView testViewInstance;
        private ITest testService;

        public TestView()
        {
            InitializeComponent();
            testService = new TestService();

            dgTests.ItemsSource = testService.GetAllTests();
        }

        public static TestView TestViewInstance
        {
            get
            {
                if (testViewInstance == null)
                    testViewInstance = new TestView();
                return testViewInstance;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            testViewInstance = null;
        }
    }
}
