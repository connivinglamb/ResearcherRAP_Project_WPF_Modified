using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace ResearcherRAP_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class MainView : Application //please for the love of god this is where the program starts, do not forget!
    {
        public void newClass1() //used for debugging purposes
        {
            Debug.WriteLine("test1");
        }
        MainView()
        {
            newClass1();
        }
    }
}
