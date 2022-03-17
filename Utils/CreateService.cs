using CWI.PKOL.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebserviceClient.Enova365Webservice;

namespace WebserviceClient.Utils
{
    public class CreateService : ServiceMethodInvokerParams
    {
        private ServiceMethodInvokerParams _params;
        private string _endPointAdress;
        public CreateService(string databaseHandle, string @operator, string password
            , Dictionary<string, object> methodArgs, string endPointAdress, string serviceName)
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            _endPointAdress = endPointAdress;
            _params = new ServiceMethodInvokerParams()
            {
                DatabaseHandle = databaseHandle,
                Operator = @operator,
                Password = password,
                ServiceName = serviceName,
                MethodArgs = methodArgs
            };
        }



        public async Task<T> InvokeAsync<T>(string methodName)
            where T : class
        {
            var binding = new BasicHttpBinding()
            {
                Name = "BasicHttpBinding_IMethodInvokerService"
            };
            //binding.Security.Mode = BasicHttpsSecurityMode.Transport;
            _params.MethodName = methodName;
            var endPointAdress = new EndpointAddress(_endPointAdress);
            var proxy = new MethodInvokerServiceClient(binding, endPointAdress);
            var serviceResult = await proxy.InvokeServiceMethodAsync(_params);
            return Serializer.Deserialize<T>(serviceResult.ResultInstance.ToString());
        }

        //public T Invoke<T>(string methodName)
        //  where T : class
        //{
        //    var binding = new BasicHttpBinding()
        //    {
        //        Name = "BasicHttpBinding_IMethodInvokerService"
        //    };
        //    //binding.Security.Mode = BasicHttpsSecurityMode.Transport;
        //    _params.MethodName = methodName;
        //    var endPointAdress = new EndpointAddress(_endPointAdress);
        //    var proxy = new MethodInvokerServiceClient(binding, endPointAdress);
        //    var serviceResult = proxy.InvokeServiceMethod(_params);
        //    if (string.IsNullOrEmpty(serviceResult.ExceptionMessage) == false)
        //        throw new Exception(serviceResult.ExceptionMessage);
        //    return Serializer.Deserialize<T>(serviceResult.ResultInstance.ToString());
        //}

        public T Invoke<T>(string methodName)
        //where T : class
        {
            var binding = new BasicHttpsBinding()
            {
                Name = "BasicHttpBinding_IMethodInvokerService",
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxBufferPoolSize = 2147483647,
                SendTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0)
            };

            binding.Security.Mode = BasicHttpsSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;

            _params.MethodName = methodName;
            var endPointAdress = new EndpointAddress(_endPointAdress);
            var proxy = new MethodInvokerServiceClient(binding, endPointAdress);
            proxy.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.Root,
                X509FindType.FindByThumbprint,
                "495f825c2d9c8d950cf397a4f856e2ee03db2146");
            //$@"C:\Users\kamil.ras\Desktop\PKOL\IntegracjaAlfresco\Certyfikat\CertyfikatEnova.cer");

            //proxy.ClientCredentials.ClientCertificate.SetCertificate = new 
            IInfoKomunikat komunikat = null;

            var serviceResult = proxy.InvokeServiceMethod(_params);
            if (string.IsNullOrEmpty(serviceResult.ExceptionMessage) == false)
                //throw new Exception(serviceResult.ExceptionMessage);
                komunikat = Info(methodName, serviceResult.ExceptionMessage);
            else
                komunikat = (IInfoKomunikat)Serializer.Deserialize<T>(serviceResult.ResultInstance.ToString());
            return (T)komunikat;
        }

        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            if (cert.Subject.Contains("CN=DESKTOP-L0AFRCR.CWINF.local"))
            {
                result = true;
            }

            return result;
        }

        public static IInfoKomunikat Info(string metoda, string exceptionMessage)
        {
            IInfoKomunikat komunikat = null;
            switch (metoda)
            {
                case "NieobecnosciZastepstwaGet":
                    komunikat = new NieobecnosciZastepstwaGetResponse();
                    break;
                case "FakturaAdd":
                    komunikat = new FakturaAddResponse();
                    break;
                case "ZajeciaKomorniczePlatnosciGet":
                    komunikat = new ZajeciaKomorniczePlatnosciGetResponse();
                    break;
                case "PodstawoweDaneGet":
                    komunikat = new PodstawoweDaneGetResponse();
                    break;
                case "KalendarzSwiatGet":
                    komunikat = new KalendarzSwiatGetResponse();
                    break;
            }
            komunikat.Info = new Info();
            komunikat.Info.Komunikaty = new InfoKomunikat[]
            {
                new InfoKomunikat()
                {
                    Kod = "!!!!!!!!!!!!!! Inner Exception !!!!!!!!!!!!",
                    Opis = exceptionMessage,
                    Typ = TypKomunikatu.Błąd
                }
            };
            return komunikat;
        }
    }
}
