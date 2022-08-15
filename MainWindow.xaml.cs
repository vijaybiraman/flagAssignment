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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlagLibraryDemo;
using System.Configuration;
namespace WpfflagDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       Dataprovider dataprovider = null;
      static int count=0;
        public MainWindow()
        {
            InitializeComponent();
            dataprovider = new Dataprovider(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtcountry.Text;
             string id=null;
            List<Continent>list=dataprovider.getCountryflag(name);
            foreach(var i in list)
            {
                txtcapital.Text = i.capital;
                id = i.countryId;
                getflag.DataContext = i.flag;
            }
            List<Continent> list2 = dataprovider.getState(id);
            if (count == 0)
            {
                foreach (var i in list2)
                {
                    txtcity.Items.Add(i.statename);
                }
                count++;
            }
             string nm = dataprovider.getcapital(txtcity.Text);
            txtcapital1.Text = nm;
        }
        private void Mainlayout_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
