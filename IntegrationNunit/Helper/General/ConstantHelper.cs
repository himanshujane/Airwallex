using System.Reflection;

namespace NunitTests.Helper.General
{
    public class ConstantHelper
    {
        public const string HeaderKeyAuth = "Authorization";

        public const string HeaderInvalidAuthToken =
            "Bearer eyJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIxNDhjYjE4Mi0wNjYxLTQyYzAtYWZjMC02MWQ0ODdkYjg5NjgiLCJzdWIiOiIyODk2ZWJmZC03YjM5LTRjYjktYTE2My00ZGM5NTkyOGI3MzUiLCJpYXQiOjE2NDc2ODgwNTAsImV4cCI6MTY0NzcwMDA1MCwiYWNjb3VudF9pZCI6IjIyNTQ4MzkyLTM4Y2MtNDFiNy04YjFiLWM1YWNjZDAzNzJhOCIsImRhdGFfY2VudGVyX3JlZ2lvbiI6IkhLIiwidHlwZSI6ImNsaWVudCIsImRjIjoiSEsiLCJpc3NkYyI6IlVTIn0.3dfRvsOlN3tYhbvx7Ucbi4OGYsuvHuFsCRjiSN35n1A";

        public const string HeaderInvalidBasicAuth = "Basic VGVzdDpwYXNzd29yZA== ";
        public const string ErrorUnauthorized = "unauthorized";
        public const string ErrorAccessDenied = "Access denied, authentication failed";
        public const string HeaderKeyXClientId = "x-client-id";
        public const string HeaderKeyXApi = "x-api-key";


        public void ReplaceProperty(dynamic requestBody, string property, dynamic value)
        {
            var prop = requestBody.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
                prop.SetValue(requestBody, value, null);

            var subs = property.Split('.');
            switch (subs[0])
            {
                case "Address":
                {
                    var prop2 = requestBody.Address.GetType()
                        .GetProperty(subs[1], BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop2 && prop2.CanWrite)
                        prop2.SetValue(requestBody.Address, value, null);
                    break;
                }
            }
        }
        
        // foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(rawContent))
        // {
        //     var key = descriptor.Name;
        //     if (!key.StartsWith("xyz") || key == "abc") continue;
        //     var value = descriptor.GetValue(rawContent);
        //     content += value;
        // }
        
        //Create MD5 Hash
        // MD5 md5 = MD5.Create();
        // byte[] inputBytes = Encoding.UTF8.GetBytes(content);
        // byte[] hashBytes = md5.ComputeHash(inputBytes);
        // StringBuilder hash = new StringBuilder();
        //     foreach (var t in hashBytes) hash.Append(t.ToString("x2"));
        //
        // return hash.ToString();
        
        protected static Dictionary<string, string> ConvertToDictionary(dynamic obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public void PrintObject(dynamic obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                _output.WriteLine("{0} = {1}", name, value);
            }
        }
    }
}