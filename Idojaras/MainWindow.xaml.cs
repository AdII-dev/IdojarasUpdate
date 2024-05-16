using System.IO;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Idojaras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Varos> varosok = new();
        public List<string> adat { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //Alapértelmezett adatok felvitele
            varosok.Add(new("Miskolc", 15, 45, 39));
            varosok.Add(new("Budapest", 20, 42, 32));
            varosok.Add(new("Székesfehérvár", 12, 36, 37));
            //Új adatok felvitele

            
            Feltolt(varosok);

        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            varosok = new List<Varos>();
            var sr = new StreamReader("../../../src/cities.txt");
            _ = sr.ReadLine(); // skip 1st line
            while (!sr.EndOfStream) varosok.Add(new Varos(sr.ReadLine(), ";"));

        }
            
            private void Feltolt(List<Varos> varosok)
        {
            //Város adatok feltöltése
            Varosok.Items.Clear();
            foreach (var v in varosok)
            {
                ListBoxItem varos = new();
                varos.Content = v._nev;
                Varosok.Items.Add(varos);
            }
        }


        private void VarosAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            //Fókuszban kitörli az alapértelmezett szöveget
            if (VarosAdd.Text == "Város Neve")
            {
                VarosAdd.Text = string.Empty;
            }
        }


        private void homersekletAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            //Fókuszban kitörli az alapértelmezett szöveget
            if (homersekletAdd.Text == "Város Hőmérséklete")
            {
                homersekletAdd.Text = string.Empty;
            }

        }

        private void paraAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            //Fókuszban kitörli az alapértelmezett szöveget
            if (paraAdd.Text == "Város Páratartalma")
            {
                paraAdd.Text = string.Empty;
            }
        }

        private void szelsebessegAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            //Fókuszban kitörli az alapértelmezett szöveget
            if (szelsebessegAdd.Text == "Város Szélsebessége")
            {
                szelsebessegAdd.Text = string.Empty;
            }
        }



        private void AdatokBevitele_Click(object sender, RoutedEventArgs e)
        {
            //Eltárolja a beírt adatokat
            varosok.Add(new(VarosAdd.Text, Convert.ToInt32(homersekletAdd.Text), Convert.ToInt32(paraAdd.Text), Convert.ToInt32(szelsebessegAdd.Text)));
            Feltolt(varosok);

            //Visszaállítja az alapértelmezett szöveget
            VarosAdd.Text = "Város Neve";
            homersekletAdd.Text = "Város Hőmérséklete";
            paraAdd.Text = "Város Páratartalma";
            szelsebessegAdd.Text = "Város Szélsebessége";

        }


        private void Varosok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Varosok.SelectedItem != null)
            {
                string varos = ((ListBoxItem)Varosok.SelectedItem).Content.ToString();
                
                foreach (var v in varosok)
                {
                    if (v._nev == varos)
                    {
                        Adatok.Text = $"Páratartalom: {v._homerseklet.ToString()} g/m3 \n Hőméréklet: {v._paratartalom.ToString()} °C\n Szélsebesség: {v._szelsebesseg.ToString()} km/h";
                        
                    }
                }
               
            }
        }
    }
}
