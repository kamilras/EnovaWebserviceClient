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
                "NieobecnoscGet",
                "FakturaAdd",
                "PracownikGet",
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
                case "NieobecnoscGet":
                    Response = serviceClient.Invoke<NieobecnoscGetResponse>("NieobecnoscGet").Serialize();
                    break;
                case "FakturaAdd":
                    Response = serviceClient.Invoke<FakturaAddResponse>("FakturaAdd").Serialize();
                    break;
                case "ZajeciaKomorniczeGet":
                    Response = serviceClient.Invoke<ZajeciaKomorniczeGetResponse>("ZajeciaKomorniczeGet").Serialize();
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

        public string Reqest_NieobecnoscGet(ItemChoiceType itemChoiceType, string identity)
        {
            NieobecnoscGet nieobecnoscGet = new NieobecnoscGet();
            nieobecnoscGet.Pracownik = new Identifier() { Item = identity, ItemElementName = itemChoiceType };

            return nieobecnoscGet.Serialize();
        }

        public string Reqest_ZajeciaKomorniczeGet(ItemChoiceType itemChoiceType, string identity)
        {
            ZajeciaKomorniczeGet zajeciaKomorniczeGet = new ZajeciaKomorniczeGet();
            zajeciaKomorniczeGet.Pracownik = new Identifier() { Item = identity, ItemElementName = itemChoiceType };

            return zajeciaKomorniczeGet.Serialize();
        }

        public string Reqest_FakturaAdd()
        {
            FakturaAdd fakturaAdd = new FakturaAdd();
            fakturaAdd.Pracownik = new PracownikPKOL();

            FakturaAddPozycja[] fakturaAddPozycje = new FakturaAddPozycja[]{
                new FakturaAddPozycja()
            };

            fakturaAdd.Faktura = new Faktura();

            return fakturaAdd.Serialize();
        }

        private void MethodNameTxtBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string metoda = MethodNameTxtBox?.SelectedItem?.ToString();

            switch (metoda)
            {
                case "NieobecnoscGet":
                    Request = Reqest_NieobecnoscGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???");
                    break;
                case "FakturaAdd":
                    Request = Reqest_FakturaAdd();
                    break;
                case "ZajeciaKomorniczeGet":
                    Request = Reqest_ZajeciaKomorniczeGet((ItemChoiceType)IdentityCmbBox.SelectedItem, "???");
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
    }
}