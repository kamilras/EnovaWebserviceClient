using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
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
using WebserviceClient.Enova365Webservice;
using WebserviceClient.Utils;
using System.IO;
using System.Security.Principal;
using CWI.PKOL.Webservice;

namespace WebserviceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfiguration();
        }

        public string Request { get; set; }
        public string Response { get; set; }

        private void LoadConfiguration()
        {
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = Path.Combine(
                  AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                  ConfigurationManager.AppSettings["ConfigFile"]
            );

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            AppSettingsSection appSettings = config.GetSection("appSettings") as AppSettingsSection;

            List<string> listaMetod = new List<string>()
            {
                "NieobecnosciGet",
                "FakturaAdd",
                "PodstawoweDaneGet",
                "ZajeciaKomorniczeGet",
                "KalendarzSwiatGet",
            };

            MethodNameTxtBox.ItemsSource = listaMetod;

            IdentityCmbBox.ItemsSource = Enum.GetValues(typeof(ItemChoiceType)).Cast<ItemChoiceType>();
            IdentityCmbBox.SelectedItem = (ItemChoiceType)IdentityCmbBox.ItemsSource.Cast<ItemChoiceType>().FirstOrDefault();

            HostTxtBox.Text = appSettings.Settings["Host"].Value;
            UserTxtBox.Text = appSettings.Settings["User"].Value;
            PasswordTxtBox.Text = appSettings.Settings["Password"].Value;
            DatabaseTxtBox.Text = appSettings.Settings["Database"].Value;
            NamespaceTxtBox.Text = appSettings.Settings["Namespace"].Value;
            MethodNameTxtBox.Text = appSettings.Settings["MethodName"].Value;

            RequestRadioBtn.IsChecked = true;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            Request = PanelTxtBox.Text;

            var args = new Dictionary<string, object>(){
                        { "XmlContent", Request}
                   };

            var serviceClient = new CreateService(databaseHandle: DatabaseTxtBox.Text,
                                    @operator: UserTxtBox.Text,
                                    password: PasswordTxtBox.Text,
                                    methodArgs: args,
                                    endPointAdress: HostTxtBox.Text,
                                    serviceName: NamespaceTxtBox.Text);

            switch ((string)MethodNameTxtBox.SelectedItem)
            {
                case "NieobecnosciGet":
                    Response = serviceClient.Invoke<NieobecnosciZastepstwaGetResponse>("NieobecnosciGet").Serialize();
                    break;
                case "FakturaAdd":
                    Response = serviceClient.Invoke<FakturaAddResponse>("FakturaAdd").Serialize();
                    break;
                case "ZajeciaKomorniczeGet":
                    Response = serviceClient.Invoke<ZajeciaKomorniczePlatnosciGetResponse>("ZajeciaKomorniczeGet").Serialize();
                    break;
                case "PodstawoweDaneGet":
                    Response = serviceClient.Invoke<PodstawoweDaneGetResponse>("PodstawoweDaneGet").Serialize();
                    break;
                default:
                    Response = "Nie znaleziono metody";
                    break;
            }

            ResponseRadioBtn.IsChecked = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = Path.Combine(
                  AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                  ConfigurationManager.AppSettings["ConfigFile"]
            );

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            AppSettingsSection appSettings = config.GetSection("appSettings") as AppSettingsSection;

            appSettings.Settings["Host"].Value = HostTxtBox.Text;
            appSettings.Settings["User"].Value = UserTxtBox.Text;
            appSettings.Settings["Password"].Value = PasswordTxtBox.Text;
            appSettings.Settings["Database"].Value = DatabaseTxtBox.Text;
            appSettings.Settings["Namespace"].Value = NamespaceTxtBox.Text;
            appSettings.Settings["MethodName"].Value = (string)MethodNameTxtBox.SelectedItem;

            config.Save(ConfigurationSaveMode.Modified);
        }

        public string Reqest_NieobecnoscGet(ItemChoiceType itemChoiceType, string identity, params DateTime?[] daty)
        {
            NieobecnosciZastepstwaGet nieobecnoscGet = new NieobecnosciZastepstwaGet();
            nieobecnoscGet.Pracownik = new Identifier() { Item = identity, ItemElementName = itemChoiceType };

            if (daty.Count() >= 1)
                nieobecnoscGet.Od = daty[0] == null ? DateTime.MinValue : (DateTime)daty[0];

            if(daty.Count() == 2)
                nieobecnoscGet.Do = daty[1] == null ? DateTime.MaxValue : (DateTime)daty[1];

            return nieobecnoscGet.Serialize();
        }

        public string Reqest_ZajeciaKomorniczeGet(ItemChoiceType itemChoiceType, string identity)
        {
            ZajeciaKomorniczePlatnosciGet zajeciaKomorniczeGet = new ZajeciaKomorniczePlatnosciGet();
            zajeciaKomorniczeGet.Pracownik = new Identifier() { Item = identity, ItemElementName = itemChoiceType };

            return zajeciaKomorniczeGet.Serialize();
        }

        private string Reqest_PodstawoweDaneGet(ItemChoiceType itemChoiceType, string identity)
        {
            PodstawoweDaneGet podstawoweDaneGet = new PodstawoweDaneGet();
            podstawoweDaneGet.Pracownik = new Identifier() { Item = identity, ItemElementName = itemChoiceType };

            return podstawoweDaneGet.Serialize();
        }

        public string Reqest_FakturaAdd()
        {
            FakturaAdd fakturaAdd = new FakturaAdd();
            fakturaAdd.Pracownik = new PracownikPKOL();

            fakturaAdd.Faktura = new Faktura()
            {
                Pozycje = new FakturaPozycja[]
                {
                    new FakturaPozycja()
                    {
                        Brutto = 100,
                        Netto = 80,
                        NazwaSkladnika = "skladnik",
                        Opis = "opis",
                        VAT = 20
                    }
                }
            };

            return fakturaAdd.Serialize();
        }

        private void MethodNameTxtBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string metoda = MethodNameTxtBox?.SelectedItem?.ToString();

            switch (metoda)
            {
                case "NieobecnosciGet":
                    Request = Reqest_NieobecnoscGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???");
                    break;
                case "FakturaAdd":
                    Request = Reqest_FakturaAdd();
                    break;
                case "ZajeciaKomorniczeGet":
                    Request = Reqest_ZajeciaKomorniczeGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???");
                    break;
                case "PodstawoweDaneGet":
                    Request = Reqest_PodstawoweDaneGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???");
                    break;
                default:
                    Request = "Nie znaleziono metody";
                    break;
            }

            PanelTxtBox.Text = Request;
            RequestRadioBtn.IsChecked = true;
            Response = string.Empty;
        }

        private void RequestBtn_Checked(object sender, RoutedEventArgs e)
        {
            PanelTxtBox.Text = Request;
        }

        private void ResponseBtn_Checked(object sender, RoutedEventArgs e)
        {
            PanelTxtBox.Text = Response;
        }

        private void DateFromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string metoda = MethodNameTxtBox?.SelectedItem?.ToString();

            DateTime?[] dates = new DateTime?[] { DateFromDatePicker.SelectedDate, DateToDatePicker.SelectedDate};

            switch (metoda)
            {
                case "NieobecnosciGet":
                    Request = Reqest_NieobecnoscGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???", dates);
                    break;
            }

            PanelTxtBox.Text = Request;
            RequestRadioBtn.IsChecked = true;
            Response = string.Empty;
        }

        private void DateToDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string metoda = MethodNameTxtBox?.SelectedItem?.ToString();

            DateTime?[] dates = new DateTime?[] { DateFromDatePicker.SelectedDate, DateToDatePicker.SelectedDate };

            switch (metoda)
            {
                case "NieobecnosciGet":
                    Request = Reqest_NieobecnoscGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???", dates);
                    break;
            }

            PanelTxtBox.Text = Request;
            RequestRadioBtn.IsChecked = true;
            Response = string.Empty;
        }
    }
}