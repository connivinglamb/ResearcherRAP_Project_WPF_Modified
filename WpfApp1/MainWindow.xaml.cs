using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (e.AddedItems.Count > 0)
            {
                string pulledResearcher = e.AddedItems[0].ToString();
                GlobalVariables.GlobalResearcherID = int.Parse(pulledResearcher.Substring(pulledResearcher.Length - 6));
                ResearcherDetailsController.loadResearcherDetails(GlobalVariables.GlobalResearcherID);
                ResearcherDetailsView.DataContext = ResearcherDetailsController.GetResearcherDetails();
                PublicationListView.DataContext = ResearcherDetailsController.GetResearcherDetails();
                //MessageBox.Show(GlobalVariables.GlobalResearcherID.ToString());

                var photo = new Image();

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri (ResearcherDetailsController.GetResearcherDetails().photo);
                bitmap.EndInit();
                ImageSource imageSource = bitmap;
                ResearcherPhoto.Source = imageSource;
            }
        }

        private void LoadPublicationDetails(object Sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string pulledPublication = e.AddedItems[0].ToString();
                int doiIndex = pulledPublication.IndexOf("@");
                if (doiIndex >= 0)
                {
                    pulledPublication = pulledPublication.Substring(doiIndex + 1);
                    PublicationDetailsView.DataContext = PublicationDetailsController.loadPublication(pulledPublication);
                }
            }
                //MessageBox.Show(pulledPublication);
        }

        private void listFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResearcherBriefController.filterName = listFilter.Text;
            ResearcherBriefController.applyFilters(ResearcherBriefController.researcherDetailsBriefCache, ResearcherBriefController.filterRange, ResearcherBriefController.filterName);
        }

        private void EmploymentLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string employmentLevel = e.AddedItems[0].ToString().Remove(0, 38);

            if (e.AddedItems[0] != null)
            {
                if (employmentLevel.StartsWith("A"))
                {
                    ResearcherBriefController.filterRange = 0;
                }
                else if (employmentLevel.StartsWith("S"))
                {
                    if (employmentLevel.Equals("Students Only"))
                    {
                        ResearcherBriefController.filterRange = 1;
                    } else
                    {
                        ResearcherBriefController.filterRange = 2;
                    }    
                } else if (employmentLevel.StartsWith("Level"))
                {
                    switch (employmentLevel[6])
                    {
                        default:
                            ResearcherBriefController.filterRange = 0;
                            break;
                        case 'A':
                            ResearcherBriefController.filterRange = 3;
                            break;
                        case 'B':
                            ResearcherBriefController.filterRange = 4;
                            break;
                        case 'C':
                            ResearcherBriefController.filterRange = 5;
                            break;
                        case 'D':
                            ResearcherBriefController.filterRange = 6;
                            break;
                        case 'E':
                            ResearcherBriefController.filterRange = 7;
                            break;
                    }
                }

                ResearcherBriefController.applyFilters(ResearcherBriefController.researcherDetailsBriefCache, ResearcherBriefController.filterRange, ResearcherBriefController.filterName);
            }
        }

        private void ShowNames_Click(object sender, RoutedEventArgs e)
        {
            var researcher = ResearcherDetailsController.GetResearcherDetails();
            if (researcher != null)
            {
                if (researcher.supervisionsCount > 0)
                {
                    string names = "";
                    foreach (var student in researcher.supervisions)
                    {
                        names += student.name;
                        names += "\n";
                    }
                    MessageBox.Show(names);
                }

            }

        }
    }
}
