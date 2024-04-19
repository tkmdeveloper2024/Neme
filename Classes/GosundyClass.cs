using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
    public class GosundyClass
    {
        public int? Gosundy_ID { get; set; }
        public int? Goshundy_UID { get; set; }
        public string Gosundy_Number { get; set; }
        public string Gosundy_Subject { get; set; }
    
    }

 

    public class Models_Get_Gosundy
    {
        [JsonProperty("currentPage:")]
        public int? currentPage { get; set; }

        public List<Get_Gosundy> data { get; set; }

        [JsonProperty("lastPage:")]
        public int? lastPage { get; set; }

        [JsonProperty("total:")]
        public int? total { get; set; }
    }

    public class Get_Gosundy   {
        
        string _gosundy_number = "";
        string _gosundy_subject = "";

        public int? Id { get; set; }
        public string Name { get { return _gosundy_number; } set { if (value == null) _gosundy_number = " "; else _gosundy_number = value; } }
      
        public string Text { get { return _gosundy_subject; } set { if (value == null) _gosundy_subject = " "; else _gosundy_subject = value; } }
      
    }
}
