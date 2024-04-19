using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
    
   public static class Staticvars
    {
        public static string server_ip = "http://119.235.113.178:8008";
       // public static string server_ip = "http://192.168.50.60:8008";
      
        

       
        public static string refresh_token;
        public static string access_token;

        public static string user_id;
        public static string user_name;
        public static string user_surname;
        public static string username;
        public static string password;
        public static string status;

        //Goshundylar transfer pages data
        public static int? Uid;
        public static string Number;
        public static string Subject;

        //Wezipe gornush transfer pages data
        public static int? WezipegornushUID;
        public static string WezipegornushName;
        public static int? Wezipegornushid;
        public static string Wezipegornushtype;
        public static int? oklad;
        public static int? Wezipegoshundylarid;
        public static string Wezipegoshundylarname;
        public static int? yyl;

        public static int? mudirlikid;
        public static int? bolumid;
        public static int? bolumceid;
        public static int? toparid;
        public static string Userid;

        //All pages pagination
        public static int? current;
        public static int? last;
        public static int? total;


        public static string static_Get_All_User;
        public static string static_Get_Userbyid;

        

    }
}
