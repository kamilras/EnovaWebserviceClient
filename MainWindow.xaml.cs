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
using WebserviceClient.Webservice;

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
            try
            {
                LoadConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Request { get; set; }
        public string Response { get; set; }
        public FakturaAdd FakturaAdd { get; set; }

        private void LoadConfiguration()
        {
            AppSettingsSection appSettings = GetSettings("WebserviceClient.config")
                                            .GetSection("appSettings") as AppSettingsSection;

            List<string> metodyLista = new List<string>()
            {
                "NieobecnosciZastepstwaGet",
                "FakturaAdd",
                "PodstawoweDaneGet",
                "ZajeciaKomorniczePlatnosciGet",
                "KalendarzSwiatGet",
            };

            MethodNameTxtBox.ItemsSource = metodyLista;

            IdentityCmbBox.ItemsSource = Enum.GetValues(typeof(ItemChoiceType)).Cast<ItemChoiceType>();
            IdentityCmbBox.SelectedItem = IdentityCmbBox.ItemsSource.Cast<ItemChoiceType>().FirstOrDefault();

            FormaWspolpracyCmbBox.ItemsSource = Enum.GetValues(typeof(FormaWspolpracy)).Cast<FormaWspolpracy>();
            FormaWspolpracyCmbBox.SelectedItem = FormaWspolpracyCmbBox.ItemsSource.Cast<FormaWspolpracy>().FirstOrDefault();

            HostTxtBox.Text = appSettings.Settings["Host"].Value;
            UserTxtBox.Text = appSettings.Settings["User"].Value;
            PasswordTxtBox.Text = appSettings.Settings["Password"].Value;
            DatabaseTxtBox.Text = appSettings.Settings["Database"].Value;
            NamespaceTxtBox.Text = appSettings.Settings["Namespace"].Value;
            IdentityCmbBox.Text = appSettings.Settings["Identity"].Value;
            PracownikTxtBox.Text = appSettings.Settings["Pracownik"].Value;
            DateFromDatePicker.Text = appSettings.Settings["Od"].Value;
            DateToDatePicker.Text = appSettings.Settings["Do"].Value;
            RokTxtBox.Text = appSettings.Settings["Rok"].Value;

            MethodNameTxtBox.SelectedItem = appSettings.Settings["MethodName"].Value;

            RequestRadioBtn.IsChecked = true;
        }

        private Configuration GetSettings(string name)
        {
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = Path.Combine(
                  AppDomain.CurrentDomain.BaseDirectory, name
            );
            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
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
                case "NieobecnosciZastepstwaGet":
                    Response = serviceClient.Invoke<NieobecnosciZastepstwaGetResponse>("NieobecnosciZastepstwaGet").Serialize();
                    break;
                case "FakturaAdd":
                    Response = serviceClient.Invoke<FakturaAddResponse>("FakturaAdd").Serialize();
                    break;
                case "ZajeciaKomorniczePlatnosciGet":
                    Response = serviceClient.Invoke<ZajeciaKomorniczePlatnosciGetResponse>("ZajeciaKomorniczePlatnosciGet").Serialize();
                    break;
                case "PodstawoweDaneGet":
                    Response = serviceClient.Invoke<PodstawoweDaneGetResponse>("PodstawoweDaneGet").Serialize();
                    break;
                case "KalendarzSwiatGet":
                    Response = serviceClient.Invoke<KalendarzSwiatGetResponse>("KalendarzSwiatGet").Serialize();
                    break;
                default:
                    Response = "Nie znaleziono metody";
                    break;
            }
            ResponseRadioBtn.IsChecked = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = GetSettings("WebserviceClient.config");
            AppSettingsSection appSettings = config.GetSection("appSettings") as AppSettingsSection;

            appSettings.Settings["Host"].Value = HostTxtBox.Text;
            appSettings.Settings["User"].Value = UserTxtBox.Text;
            appSettings.Settings["Password"].Value = PasswordTxtBox.Text;
            appSettings.Settings["Database"].Value = DatabaseTxtBox.Text;
            appSettings.Settings["Namespace"].Value = NamespaceTxtBox.Text;
            appSettings.Settings["MethodName"].Value = (string)MethodNameTxtBox.SelectedItem;
            appSettings.Settings["Identity"].Value = IdentityCmbBox.Text;
            appSettings.Settings["Pracownik"].Value = PracownikTxtBox.Text;
            appSettings.Settings["Od"].Value = DateFromDatePicker.Text;
            appSettings.Settings["Do"].Value = DateToDatePicker.Text;
            appSettings.Settings["Rok"].Value = RokTxtBox.Text;

            config.Save(ConfigurationSaveMode.Modified);
        }

        public string Reqest_KalendarzSwiatGet()
        {
            KalendarzSwiatGet kalendarzSwiatGet = new KalendarzSwiatGet();
            kalendarzSwiatGet.Rok = int.Parse(RokTxtBox.Text);
            return kalendarzSwiatGet.Serialize();
        }

        public string Reqest_NieobecnosciZastepstwaGet()
        {
            NieobecnosciZastepstwaGet nieobecnoscGet = new NieobecnosciZastepstwaGet();
            nieobecnoscGet.Pracownik = new Identifier() { Item = PracownikTxtBox.Text, ItemElementName = (ItemChoiceType)IdentityCmbBox.SelectedItem };
            nieobecnoscGet.Od = (DateTime)DateFromDatePicker.SelectedDate;
            nieobecnoscGet.Do = (DateTime)DateToDatePicker.SelectedDate;
            return nieobecnoscGet.Serialize();
        }

        public string Reqest_ZajeciaKomorniczePlatnosciGet()
        {
            ZajeciaKomorniczePlatnosciGet zajeciaKomorniczeGet = new ZajeciaKomorniczePlatnosciGet();
            zajeciaKomorniczeGet.Pracownik = new Identifier() { Item = PracownikTxtBox.Text, ItemElementName = (ItemChoiceType)IdentityCmbBox.SelectedItem };
            zajeciaKomorniczeGet.Od = (DateTime)DateFromDatePicker.SelectedDate;
            zajeciaKomorniczeGet.Do = (DateTime)DateToDatePicker.SelectedDate;
            return zajeciaKomorniczeGet.Serialize();
        }

        private string Reqest_PodstawoweDaneGet()
        {
            PodstawoweDaneGet podstawoweDaneGet = new PodstawoweDaneGet();
            podstawoweDaneGet.Pracownik = new Identifier() { Item = PracownikTxtBox.Text, ItemElementName = (ItemChoiceType)IdentityCmbBox.SelectedItem };
            podstawoweDaneGet.FormaWspolpracy = (FormaWspolpracy)FormaWspolpracyCmbBox.SelectedItem;
            return podstawoweDaneGet.Serialize();
        }

        private string Reqest_FakturaAdd()
        {
            if (FakturaAdd == null)
            {
                FakturaAdd = new FakturaAdd()
                {
                    UmowaOd = DateFromDatePicker.DisplayDate,
                    UmowaDo = DateToDatePicker.DisplayDate,
                    DataRozliczenia = DateToDatePicker.DisplayDate
                };
                FakturaAdd.Faktura = new Faktura();
                FakturaAdd.Faktura.Pozycje = new FakturaPozycja[] { new FakturaPozycja() };
            }
            FakturaAdd.Pracownik = new Identifier() { Item = PracownikTxtBox.Text, ItemElementName = (ItemChoiceType)IdentityCmbBox.SelectedItem };
            FakturaAdd.FormaWspolpracy = (FormaWspolpracy)FormaWspolpracyCmbBox.SelectedItem;
            return FakturaAdd.Serialize();
        }

        private void RequestBtn_Checked(object sender, RoutedEventArgs e)
        {
            PanelTxtBox.Text = Request;
        }

        private void ResponseBtn_Checked(object sender, RoutedEventArgs e)
        {
            PanelTxtBox.Text = Response;
        }

        private void MethodNameTxtBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void DateFromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void DateToDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void PracownikTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FormaWspolpracyCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void RokTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FakturaAddUpdate(object sender, FakturaEventArgs e)
        {
            FakturaAdd = e.FakturaAdd;
            Update();
        }

        public void Update()
        {
            string metoda = MethodNameTxtBox?.SelectedItem?.ToString();
            switch (metoda)
            {
                case "NieobecnosciZastepstwaGet":
                    Disable(RokTxtBox);
                    Request = Reqest_NieobecnosciZastepstwaGet();
                    break;
                case "PodstawoweDaneGet":
                    Disable(RokTxtBox);
                    Request = Reqest_PodstawoweDaneGet();
                    break;
                case "ZajeciaKomorniczePlatnosciGet":
                    Disable(RokTxtBox);
                    Request = Reqest_ZajeciaKomorniczePlatnosciGet();
                    break;
                case "FakturaAdd":
                    Disable(RokTxtBox, DateFromDatePicker, DateToDatePicker);
                    Request = Reqest_FakturaAdd();
                    break;
                case "KalendarzSwiatGet":
                    Disable(IdentityCmbBox, PracownikTxtBox, FormaWspolpracyCmbBox, DateFromDatePicker, DateToDatePicker);
                    Request = Reqest_KalendarzSwiatGet();
                    break;
            }

            PanelTxtBox.Text = Request;
            RequestRadioBtn.IsChecked = true;
            Response = string.Empty;
        }

        private void Disable(params Control[] elem)
        {
            List<Control> listaElementow = new List<Control>()
            {
                PracownikTxtBox, DateFromDatePicker, DateToDatePicker, RokTxtBox, IdentityCmbBox, FormaWspolpracyCmbBox
            };

            foreach (var el in elem)
            {
                el.IsEnabled = false;
                listaElementow.Remove(el);
            }

            foreach (var el in listaElementow)
                el.IsEnabled = true;
        }

        private void FakturaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MethodNameTxtBox?.SelectedItem?.ToString() != "FakturaAdd")
            {
                MessageBox.Show("Tylko dla metody \"FakturaAdd\"");
                return;
            }
            Request = PanelTxtBox.Text;

            FakturaWindow fakturaWindow = new FakturaWindow(Request);
            fakturaWindow.FakturaAddChanged += FakturaAddUpdate;
            fakturaWindow.Show();
        }
    }
}