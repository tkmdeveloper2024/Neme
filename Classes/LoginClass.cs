using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
    public  class LoginClass
    {
    }

    public class Login
    {

        public Model_Login Results { get; set; }
    }

    public class Model_Login
    {

        string _refresh = "";
        string _access = "";
        string _status = "";
        string _user_id = "";


        public string access_token { get { return _access; } set { if (value == null) _access = " "; else _access = value; } }
        public string refresh_token { get { return _refresh; } set { if (value == null) _refresh = " "; else _refresh = value; } }
        public string status { get { return _status; } set { if (value == null) _status = " "; else _status = value; } }
        public string user_id { get { return _user_id; } set { if (value == null) _user_id = " "; else _user_id = value; } }
    }
}
