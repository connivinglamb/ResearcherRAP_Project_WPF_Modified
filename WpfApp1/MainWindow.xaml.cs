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
            
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }

        private void LoadResearcherDetails(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                string pulledResearcher = e.AddedItems[0].ToString();
                GlobalVariables.GlobalResearcherID = int.Parse(pulledResearcher.Substring(pulledResearcher.Length - 6));
                DBAdapter.researcherDetailedQuery(GlobalVariables.GlobalResearcherID);
                MessageBox.Show(GlobalVariables.GlobalResearcherID.ToString());

            }
        }
    }
}
