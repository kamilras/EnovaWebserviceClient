using System;
using System.Collections.Generic;
using System.Linq;
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

        public T Invoke<T>(string methodName)
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
            var serviceResult = proxy.InvokeServiceMethod(_params);
            if (string.IsNullOrEmpty(serviceResult.ExceptionMessage) == false)
                throw new Exception(serviceResult.ExceptionMessage);
            return Serializer.Deserialize<T>(serviceResult.ResultInstance.ToString());
        }
    }
}
