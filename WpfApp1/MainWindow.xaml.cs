using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ResearcherRAP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("\ntest_initmainwindow\n");
            ResearcherBriefController controller_brief = new ResearcherBriefController();
            List<ResearcherBrief> testValues = ResearcherBriefController.loadResearchers();

            /*foreach (ResearcherBrief x in testValues)
            {
                Debug.WriteLine(x.ToString());
                researcherList.ItemsSource = x.nameGiven;
            }*/

            if (testValues != null)
            {
                researcherList.ItemsSource = testValues;
                Debug.WriteLine(testValues[0].nameGiven);
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }
    }
}
