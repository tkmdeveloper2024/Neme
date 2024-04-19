using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
   public class WezipeGornush
    {
        public int? Id { get; set; }
        public int? Uid { get; set; }
        public string Name { get; set; }
        public int? Wezipegornushid { get; set; }
        public string Wezipegornushtype { get; set; }
        
        public int? oklad { get; set; }
        public int? Wezipegoshundylarid { get; set; }
        public string Wezipegoshundylarname { get; set; }
        public string Buyruknumber { get; set; }
        public string Buyrukdate { get; set; }

        public int? yyl { get; set; }

    }
   
    public class Models_Get_WezipeGornush
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }
        public List<Get_WezipeGornush> data { get; set; }


        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Models_Get_Wezipe
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }
        public List<Get_Wezipe> data { get; set; }
        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }
    public class Get_WezipeGornush
    {
        string _type="";
        public int? Id { get; set; }
        public string Type { get { return _type; } set { if (value == null) _type = " "; else _type = value; } }
    }

    public class Get_Wezipe
    {

        string _name = "";
        string _wezipe_gornush_type = "";
        string _wezipe_goshundylar_name = "";
        string _buyruk_number = "";
        string _date_of_buyruk = "";

        public int? id { get; set; }
        public string name { get { return _name; } set { if (value == null) _name = " "; else _name = value; } }

        public int? wezipe_gornush_id { get; set; }
        public string wezipe_gornush_type { get { return _wezipe_gornush_type; } set { if (value == null) _wezipe_gornush_type = " "; else _wezipe_gornush_type = value; } }
        public int? oklad { get; set; }
        public int? wezipe_goshundylar_id { get; set; }
        public string wezipe_goshundylar_name { get { return _wezipe_goshundylar_name; } set { if (value == null) _wezipe_goshundylar_name = " "; else _wezipe_goshundylar_name = value; } }

        public string buyruk_number { get { return _buyruk_number; } set { if (value == null) _buyruk_number = " "; else _buyruk_number = value; } }
        public string date_of_buyruk { get { return _date_of_buyruk; } set { if (value == null) _date_of_buyruk = " "; else _date_of_buyruk = value; } }
        public int? yyl { get; set; }

    }






}
