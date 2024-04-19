using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
    public class UsersClass
    {
        public string Id { get; set; }
        public string Name_Surname { get; set; }
        public string Degishli_Mudirligi { get; set; }
        public string Logini{ get; set; }
        public string Ulgamda { get; set; }

        public string Uid { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserSurname { get; set; }
        public string UserUsername { get; set; }
        public int? UserMudirlikid { get; set; }
        public string Usermudirliklername { get; set; }
        public int? UserBolumlerid { get; set; }
        public string UserBolumlername { get; set; }
        public int? UserBolumchelerid { get; set; }
        public string UserBolumchelername { get; set; }
        public int? UserToparid { get; set; }
        public string UserToparlarname { get; set; }
        public int? UserWezipelerid { get; set; }
        public string UserWezipelername { get; set; }
        public string UserPhoto { get; set; }
        public string UserCreatedDate { get; set; }
        public string UserOpenedDate { get; set; }
    }



    public class Models_Get_All_User
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_All_User> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
 
    public class Get_All_User
    {

        string _name = "";
        string _lastname = "";
        string _surname = "";
        string _username = "";
        string _mudirliklername = "";
        string _bolumlername = "";
        string _bolumchelername = "";
        string _toparlarname = "";
        string _wezipelername = "";
        string _photo = "";
        string _createddate = "";
        string _updateddate = "";


        public string Id { get; set; }
        public string Name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }

        public string Lastname { get { return _lastname; } set { if (value == null) _lastname = " "; else _lastname = value; } }
        public string Surname { get { return _surname; } set { if (value == null) _surname = " "; else _surname = value; } }

        public string Username { get { return _username; } set { if (value == null) _username = " "; else _username = value; } }
        public int? mudirlikler_id { get; set; }

        public string mudirlikler_name { get { return _mudirliklername; } set { if (value == null) _mudirliklername = " "; else _mudirliklername = value; } }
        public int? bolumid { get; set; }

        public string bolumlername { get { return _bolumlername; } set { if (value == null) _bolumlername = " "; else _bolumlername = value; } }
        public int? bolumcheler_id { get; set; }
        public string bolumcheler_name { get { return _bolumchelername; } set { if (value == null) bolumcheler_name = " "; else _bolumchelername = value; } }

        public int? toparlar_id { get; set; }
        public string toparlar_name { get { return _toparlarname; } set { if (value == null) _toparlarname = " "; else _toparlarname = value; } }

        public int? wezipeler_id { get; set; }
        public string wezipeler_name { get { return _wezipelername; } set { if (value == null) _wezipelername = " "; else _wezipelername = value; } }
        public string photo { get { return _photo; } set { if (value == null) _photo = " "; else _photo = value; } }
        public string created_date { get { return _createddate; } set { if (value == null) _createddate = " "; else _createddate = value; } }

        public string updated_date{ get { return _updateddate; } set { if (value == null) _updateddate = " "; else _updateddate = value; } }
      


    }
}
