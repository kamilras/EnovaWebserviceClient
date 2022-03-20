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
            WprowadzWartosci();
        }

        public EventHandler<FakturaEventArgs> FakturaAddChanged;
        public string Faktura { get; set; }
        public FakturaAdd FakturaAdd { get; set; }

        private void Load(string request)
        {
            FakturaAdd = Serializer.Deserialize<FakturaAdd>(request);
        }

        private void WprowadzWartosci()
        {
            UmowaBruttoTxtBox.Text = FakturaAdd.Brutto.ToString();
            UmowaNettoTxtBox.Text = FakturaAdd.Netto.ToString();
            UmowaVATTxtBox.Text = FakturaAdd.VAT.ToString();
            UmowaDataRozliczeniaDatePkr.SelectedDate = FakturaAdd.DataRozliczenia;
            UmowaDoDatePkr.SelectedDate = FakturaAdd.UmowaDo;
            UmowaOdDatePkr.SelectedDate = FakturaAdd.UmowaOd;
            UmowaNrKontaGlownegoTxtBox.Text = FakturaAdd.NumerKontaGlownego;

            FakturaProwizjaTxtBox.Text = FakturaAdd.Faktura.Prowizja.ToString();
            FakturaCzyZaplaconaChkBox.IsChecked = FakturaAdd.Faktura.CzyZaplacona;
            FakturaDoDatePkr.SelectedDate = FakturaAdd.Faktura.Do;
            FakturaOdDatePkr.SelectedDate = FakturaAdd.Faktura.Od;
            FakturaOpisTxtBox.Text = FakturaAdd.Faktura.Opis;
            FakturaTerminPlatnosciDatePkr.SelectedDate = FakturaAdd.Faktura.TerminPlatnosci;
            FakturaNrTxtBox.Text = FakturaAdd.Faktura.NumerFaktury;

            PozycjaBruttoTxtBox.Text = FakturaAdd.Faktura.Pozycje[0].Brutto.ToString();
            PozycjaNettoTxtBox.Text = FakturaAdd.Faktura.Pozycje[0].Netto.ToString();
            PozycjaVATTxtBox.Text = FakturaAdd.Faktura.Pozycje[0].VAT.ToString();
            PozycjaNazwaSkladnikaTxtBox.Text = FakturaAdd.Faktura.Pozycje[0].NazwaSkladnika;
            PozycjaOpisTxtBox.Text = FakturaAdd.Faktura.Pozycje[0].Opis;
        }

        public bool LoadProperty()
        {
            string error = string.Empty;
            decimal pozycjaBrutto = SprawdzWartosc(PozycjaBruttoTxtBox, ref error);
            decimal pozycjaNetto = SprawdzWartosc(PozycjaNettoTxtBox, ref error);
            decimal pozycjaVAT = SprawdzWartosc(PozycjaVATTxtBox, ref error);

            decimal fakturaProwiza = SprawdzWartosc(FakturaProwizjaTxtBox, ref error);

            decimal umowaBrutto = SprawdzWartosc(UmowaBruttoTxtBox, ref error);
            decimal umowaNetto = SprawdzWartosc(UmowaNettoTxtBox, ref error);
            decimal umowaVAT = SprawdzWartosc(UmowaVATTxtBox, ref error);

            FakturaAdd.Brutto = umowaBrutto;
            FakturaAdd.VAT = umowaVAT;
            FakturaAdd.Netto = umowaNetto;
            FakturaAdd.NumerKontaGlownego = UmowaNrKontaGlownegoTxtBox.Text;
            FakturaAdd.UmowaOd = (DateTime)UmowaOdDatePkr.SelectedDate;
            FakturaAdd.UmowaDo = (DateTime)UmowaDoDatePkr.SelectedDate;
            FakturaAdd.DataRozliczenia = (DateTime)UmowaDataRozliczeniaDatePkr.SelectedDate;

            FakturaAdd.Faktura = new Faktura()
            {
                CzyZaplacona = (bool)FakturaCzyZaplaconaChkBox.IsChecked,
                Do = FakturaDoDatePkr.SelectedDate,
                Od = FakturaOdDatePkr.SelectedDate,
                NumerFaktury = FakturaNrTxtBox.Text,
                Opis = FakturaOpisTxtBox.Text,
                Prowizja = fakturaProwiza,
                TerminPlatnosci = FakturaTerminPlatnosciDatePkr.SelectedDate
            };

            FakturaAdd.Faktura.Pozycje = new FakturaPozycja[]
            {
                new FakturaPozycja()
                {
                    Brutto = pozycjaBrutto,
                    Netto = pozycjaNetto,
                    NazwaSkladnika = PozycjaNazwaSkladnikaTxtBox.Text,
                    Opis = PozycjaOpisTxtBox.Text,
                    VAT = pozycjaVAT
                }
            };

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Błędy:\n\n" + error);
                return false;
            }
            return true;
        }

        private decimal SprawdzWartosc(TextBox textBox, ref string error)
        {
            decimal result;
            if (!decimal.TryParse(textBox.Text, out result))
            {
                error = $"{textBox.Text} nie jest prawidłową wartością. Ustawiono wartość {decimal.Zero}\n";
                textBox.Text = decimal.Zero.ToString();
                textBox.Focus();

                return decimal.Zero;
            }
            return result;
        }

        private void ZapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            bool closeWindow = LoadProperty();
            OnFakturaAddChanged(new FakturaEventArgs(FakturaAdd));

            if (closeWindow)
                Close();
        }

        protected virtual void OnFakturaAddChanged(FakturaEventArgs e)
        {
            FakturaAddChanged?.Invoke(this, e);
        }
    }

    public class FakturaEventArgs : EventArgs
    {
        public FakturaAdd FakturaAdd { get; set; }
        public FakturaEventArgs(FakturaAdd fakturaAdd)
        {
            FakturaAdd = fakturaAdd;
        }
    }
}
