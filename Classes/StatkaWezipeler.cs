using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
   public class StatkaWezipeler
    {
        public int? Id { get; set; }
        public int? Uid { get; set; }
        public string Fullname { get; set; }
        public int? Wezipegornushid { get; set; }
        public string Wezipegornushtype { get; set; }       
        public int? Wezipegoshundylarid { get; set; }
        public string Wezipegoshundylarname { get; set; }
        public int? wezipeid { get; set; }
        public string wezipename { get; set; }
        public int? cesmeid { get; set; }
        public string cesmename { get; set; }
        public int? zwanyegornushid { get; set; }
        public string zwanyegornushname { get; set; }
        public int? zwanyeid { get; set; }
        public string zwanyename { get; set; }
        public int? count { get; set; }
        public int? mudirlikid { get; set; }
        public string mudirlikname { get; set; }
        public int? bolumid { get; set; }
        public string bolumname { get; set; }
        public int? bolumcheid { get; set; }
        public string bolumchename { get; set; }
        public int? toparid { get; set; }
        public string toparname { get; set; }
        public int? yzygiderlik { get; set; }
        public string archive { get; set; }
        public DateTime opened_date { get; set; }
        public string created_number_of_buyruk { get; set; }
        public DateTime closed_date { get; set; }
        public string closed_number_of_buyruk { get; set; }

    }

    public class Models_Get_StatkaWezipeler
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }
        public List<Get_StatkaWezipeler> data { get; set; }


        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }

    public class Get_StatkaWezipeler
    {
        string _fullname = "";
        string _wezipegornushtype = "";
        string _wezipegoshundylarname = "";
        string _wezipegname = "";
        string _cesmename = "";
        string _zwaynegornushname = "";
        string _zwanyename = "";
        string _mudirlikname = "";
        string _bolumname = "";
        string _bolumcename = "";
        string _toparname = "";
        string _created_number_of_buyruk = "";
        string _closed_number_of_buyruk = "";
        public int? id { get; set; }
        public string full_name { get { return _fullname; } set { if (value == null) _fullname = " "; else _fullname = value; } }
        public int? wezipe_gornush_id { get; set; }
        public string wezipe_gornush_type { get { return _wezipegornushtype; } set { if (value == null) _wezipegornushtype = " "; else _wezipegornushtype = value; } }
        public int? wezipe_goshundylar_id { get; set; }
        public string wezipe_goshundylar_name { get { return _wezipegname; } set { if (value == null) _wezipegname = " "; else _wezipegname = value; } }
        public int? wezipe { get; set; }
        public string wezipe_name { get { return _wezipegname; } set { if (value == null) _wezipegname = " "; else _wezipegname = value; } }
        public int? wezipe_cheshme_id { get; set; }
        public string wezipe_cheshme_name { get { return _cesmename; } set { if (value == null) _cesmename = " "; else _cesmename = value; } }
        public int? zvanye_gornush_id { get; set; }
        public string zvanye_gornush_name { get { return _zwaynegornushname; } set { if (value == null) _zwaynegornushname = " "; else _zwaynegornushname = value; } }
        public int? zvanye_id { get; set; }
        public string zvanye_fullname { get { return _zwanyename; } set { if (value == null) _zwanyename = " "; else _zwanyename = value; } }
        public int? count { get; set; }
       
        public int? mudirlikler_id { get; set; }
        public string mudirlikler_name { get { return _mudirlikname; } set { if (value == null) _mudirlikname = " "; else _mudirlikname = value; } }
        public int? bolum_id { get; set; }
        public string bolumler_name { get { return _bolumname; } set { if (value == null) _bolumname = " "; else _bolumname = value; } }
        public int? bolumcheler_id { get; set; }
        public string bolumcheler_name { get { return _bolumcename; } set { if (value == null) _bolumcename = " "; else _bolumcename = value; } }

        public int? toparlar_id { get; set; }
        public string toparlar_name { get { return _toparname; } set { if (value == null) _toparname = " "; else _toparname = value; } }
        public string yzygiderlik { get; set; }
        public string archive { get; set; }
        public string created_number_of_buyruk { get { return _created_number_of_buyruk; } set { if (value == null) _created_number_of_buyruk = " "; else _created_number_of_buyruk = value; } }
        public string closed_number_of_buyruk { get { return _closed_number_of_buyruk; } set { if (value == null) _closed_number_of_buyruk = " "; else _closed_number_of_buyruk = value; } }


    }

}
