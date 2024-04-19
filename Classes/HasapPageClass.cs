using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
    public class HasapPageClass
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Full_name { get; set; }

        public int? Yzygiderlik { get; set; }

        public int? Hukukid { get; set; }
        public string Hukuk_name { get; set; }
        public string Opened_date { get; set; }


        public int? BolumId { get; set; }
        public string BolumName { get; set; }
        public string BolumFull_name { get; set; }
        public int? BolumCodeId { get; set; }
        public int? BolumCode { get; set; }
        public int? BolumYzygiderlik { get; set; }
        public int? BolumHukukId { get; set; }
        public string BolumHukukName { get; set; }
        public int? BolumMudirlikid { get; set; }
        public string BolumMudirlikdName { get; set; }
        public string BolumOpenedDate { get; set; }
        public string BolumCreatedDate { get; set; }
      
    }
    public class Models_Get_Hukuk
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Hukuk> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Hukuk
    {

        string _hukuk = "";

        public int? Id { get; set; }
        public string Name { get { return _hukuk; } set { if (value == null) _hukuk = " "; else _hukuk = value; } }

       
    }
    public class Models_Get_Mudirlik
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Mudirlik> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Mudirlik
    {

        string _name = "";
        string _full_name = "";
        string _hukuk_name = "";       
        string _opened_date = "";

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }
        public string full_name { get { return _full_name; } set { if (value == null) _full_name = " "; else _full_name = value; } }
        public string yzygiderlik { get; set; }
        public string hukuk_id { get; set; }
        public string hukuk_name { get { return _hukuk_name; } set { if (value == null) _hukuk_name = " "; else _hukuk_name = value; } }
        public string opened_date { get { return _opened_date; } set { if (value == null) _opened_date = " "; else _opened_date = value; } }




    }


    public class Models_Get_Bolum
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Mudirlik> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Bolum
    {

        string _name = "";
        string _full_name = "";
        string _hukuk_name = "";
        string _mudirlikler_name = "";
        string _opened_date = "";
        string _created_date_of_buyruk = "";

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }
        public string fullName { get { return _full_name; } set { if (value == null) _full_name = " "; else _full_name = value; } }
        public int? bolum_code_id { get; set; }
        public int? bolum_code { get; set; }
        public int? yzygiderlik { get; set; }
        public int? hukuk_id { get; set; }
        public string hukuk_name { get { return _hukuk_name; } set { if (value == null) _hukuk_name = " "; else _hukuk_name = value; } }
        public int? mudirlikler_id { get; set; }
        public string mudirlikler_name{ get { return _mudirlikler_name; } set { if (value == null) _mudirlikler_name = " "; else _mudirlikler_name = value; } }
        public string opened_date { get { return _opened_date; } set { if (value == null) _opened_date = " "; else _opened_date = value; } }
        public string created_date_of_buyruk { get { return _created_date_of_buyruk; } set { if (value == null) _created_date_of_buyruk = " "; else _created_date_of_buyruk = value; } }




    }

    public class Models_Get_BolumCode
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Bolum_Code> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Bolum_Code
    {
               
        public int? Id { get; set; }
        public int? Code { get; set; }


    }


    public class Models_Get_Bolumce
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Bolumce> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Bolumce
    {

        string _name = "";
        string _full_name = "";       
        string _hukuk_name = "";
        string _mudirlikler_name = "";
        string _bolumler_name = "";
        string _opened_date = "";
        string _created_date_of_buyruk = "";

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }
        public string full_name { get { return _full_name; } set { if (value == null) _full_name = " "; else _full_name = value; } }

        public string hukuk_id { get; set; }
        public string hukuk_name { get { return _hukuk_name; } set { if (value == null) _hukuk_name = " "; else _hukuk_name = value; } }

        public string yzygiderlik { get; set; }
        public int? mudirlikler_id { get; set; }
        public string mudirlikler_name { get { return _mudirlikler_name; } set { if (value == null) _mudirlikler_name = " "; else _mudirlikler_name = value; } }

        public int? bolum_id { get; set; }
        public string bolumler_name { get { return _bolumler_name; } set { if (value == null) _bolumler_name = " "; else _bolumler_name = value; } }
        public string opened_date { get { return _opened_date; } set { if (value == null) _opened_date = " "; else _opened_date = value; } }
        public string created_date_of_buyruk { get { return _created_date_of_buyruk; } set { if (value == null) _created_date_of_buyruk = " "; else _created_date_of_buyruk = value; } }




    }


    public class Models_Get_Topar
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Topar> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Topar
    {

        string _name = "";
        string _full_name = "";
        string _hukuk_name = "";
        string _mudirlikler_name = "";
        string _bolumler_name = "";
        string _bolumcheler_name = ""; 
        string _opened_date = "";
        string _created_date_of_buyruk = "";

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }
        public string full_name { get { return _full_name; } set { if (value == null) _full_name = " "; else _full_name = value; } }

        public string hukuk_id { get; set; }
        public string hukuk_name { get { return _hukuk_name; } set { if (value == null) _hukuk_name = " "; else _hukuk_name = value; } }

        public string yzygiderlik { get; set; }
        public int? mudirlikler_id { get; set; }
        public string mudirlikler_name { get { return _mudirlikler_name; } set { if (value == null) _mudirlikler_name = " "; else _mudirlikler_name = value; } }

        public int? bolum_id { get; set; }
        public string bolumler_name { get { return _bolumler_name; } set { if (value == null) _bolumler_name = " "; else _bolumler_name = value; } }
        public string bolumcheler_id { get; set; }
        public string bolumcheler_name { get { return _bolumcheler_name; } set { if (value == null) _bolumcheler_name = " "; else _bolumcheler_name = value; } }
        public string opened_date { get { return _opened_date; } set { if (value == null) _opened_date = " "; else _opened_date = value; } }
        public string created_date_of_buyruk { get { return _created_date_of_buyruk; } set { if (value == null) _created_date_of_buyruk = " "; else _created_date_of_buyruk = value; } }




    }


    public class Models_Get_Wezipeler
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Wezipeler> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_Wezipeler
    {          
                      
           
              
        string _full_name = "";
        string _wezipe_gornush_id = "";
        string _wezipe_gornush_type = "";
        string _wezipe_goshundylar_id = "";
        string _wezipe_goshundylar_name = "";
        string _wezipe = "";
        string _wezipe_name = "";
        string _wezipe_cheshme_id = "";
        string _wezipe_cheshme_name = "";
        string _zvanye_gornush_id = "";
        string _zvanye_gornush_name = "";
        string _zvanye_id = "";
        string _zvanye_fullname = "";
        string _count = "";
        string _mudirlikler_id = "";
        string _mudirlikler_name = "";
        string _bolum_id = "";
        string _bolumler_name = "";
        string _bolumcheler_id = "";
        string _bolumcheler_name = "";
        string _toparlar_id = "";
        string _toparlar_name = "";
        string _yzygiderlik = "";
        string _archive = "";
        string _opened_date = "";
        string _created_number_of_buyruk = "";
        string _created_date_of_buyruk = "";

        public int? id { get; set; }
        public string full_name { get { return _full_name; } set { if (value == null) _full_name = " "; else _full_name = value; } }

       
        public string yzygiderlik { get; set; }
        public int? mudirlikler_id { get; set; }
        public string mudirlikler_name { get { return _mudirlikler_name; } set { if (value == null) _mudirlikler_name = " "; else _mudirlikler_name = value; } }

        public int? bolum_id { get; set; }
        public string bolumler_name { get { return _bolumler_name; } set { if (value == null) _bolumler_name = " "; else _bolumler_name = value; } }
        public string bolumcheler_id { get; set; }
        public string bolumcheler_name { get { return _bolumcheler_name; } set { if (value == null) _bolumcheler_name = " "; else _bolumcheler_name = value; } }
        public string opened_date { get { return _opened_date; } set { if (value == null) _opened_date = " "; else _opened_date = value; } }
        public string created_date_of_buyruk { get { return _created_date_of_buyruk; } set { if (value == null) _created_date_of_buyruk = " "; else _created_date_of_buyruk = value; } }




    }


    public class Models_Get_WezipeCesme
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_WezipeCesme> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }

    public class Get_WezipeCesme
    {

        string _name = "";
     

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }      


    }
}
