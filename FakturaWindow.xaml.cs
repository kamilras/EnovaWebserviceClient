using CWI.PKOL.Webservice;
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
using WebserviceClient.Utils;

namespace WebserviceClient
{
    /// <summary>
    /// Interaction logic for FakturaWindow.xaml
    /// </summary>
    public partial class FakturaWindow : Window
    {
        public FakturaWindow(string request)
        {
            InitializeComponent();
            Load(request);
        }

        public static string Faktura { get; set; }
        public FakturaAdd FakturaAdd { get; set; }

        private void Load(string request)
        {
            FakturaAdd = Serializer.Deserialize<FakturaAdd>(request);
        }

        public static string Reqest_FakturaAdd()
        {
            FakturaAdd fakturaAdd = new FakturaAdd();
            fakturaAdd.Pracownik = new Identifier();

            fakturaAdd.Faktura = new Faktura()
            {
                Pozycje = new FakturaPozycja[]
                {
                    new FakturaPozycja()
                    {
                        Brutto = 100,
                        Netto = 80,
                        NazwaSkladnika = "skladnik",
                        Opis = "Opis",
                        VAT = 20
                    }
                }
            };

            return fakturaAdd.Serialize();
        }
    }
}
