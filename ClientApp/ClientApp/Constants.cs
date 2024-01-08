using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp;

static class Constants
{
    public static class Urls
    {
        public const string AuthServiceUrl = "http://localhost:5268";
        public const string Login = AuthServiceUrl + "/login";
        public const string Register = AuthServiceUrl + "/register";
    }
}
