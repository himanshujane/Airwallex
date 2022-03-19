namespace Tests.Helper.General
{
    public static class ConstantHelper
    {
        public const string HeaderKeyAuth = "Authorization";

        public const string HeaderInvalidAuthToken =
            "Bearer eyJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIxNDhjYjE4Mi0wNjYxLTQyYzAtYWZjMC02MWQ0ODdkYjg5NjgiLCJzdWIiOiIyODk2ZWJmZC03YjM5LTRjYjktYTE2My00ZGM5NTkyOGI3MzUiLCJpYXQiOjE2NDc2ODgwNTAsImV4cCI6MTY0NzcwMDA1MCwiYWNjb3VudF9pZCI6IjIyNTQ4MzkyLTM4Y2MtNDFiNy04YjFiLWM1YWNjZDAzNzJhOCIsImRhdGFfY2VudGVyX3JlZ2lvbiI6IkhLIiwidHlwZSI6ImNsaWVudCIsImRjIjoiSEsiLCJpc3NkYyI6IlVTIn0.3dfRvsOlN3tYhbvx7Ucbi4OGYsuvHuFsCRjiSN35n1A";

        public const string HeaderInvalidBasicAuth = "Basic VGVzdDpwYXNzd29yZA== ";
        public const string ErrorUnauthorized = "unauthorized";
        public const string ErrorAccessDenied = "Access denied, authentication failed";
        public const string HeaderKeyXClientId = "x-client-id";
        public const string HeaderKeyXApi = "x-api-key";
    }
}