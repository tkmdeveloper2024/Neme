using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Classes
{
   public static class URLs
    {
        public static string URL_Add_New_User = Staticvars.server_ip + "/api/admin/register/";
        public static string URL_Get_Byiduser = Staticvars.server_ip + "/api/admin/users/get/";
        public static string URL_Update_User = Staticvars.server_ip + "/api/admin/users/update/";
        public static string URL_Get_All_User = Staticvars.server_ip + "/api/admin/users/all/?limit=10";

        public static string URL_Details_ofcurrentuser = Staticvars.server_ip + "/api/admin/users/me/";
        public static string URL_Login = Staticvars.server_ip + "/api/admin/login/";
        public static string URL_Logout = Staticvars.server_ip + "/api/admin/logout/";
        public static string URL_Refresh_token = Staticvars.server_ip + "/api/admin/refreshtoken/";

        public static string URL_Delete_User = Staticvars.server_ip + "/api/admin/users/delete/";
        public static string URL_Update_passwordforuser = Staticvars.server_ip + "/api/admin/users/updatepassword/";
        public static string URL_Add_New_Role = Staticvars.server_ip + "/api/admin/role/add/";
        public static string URL_Get_All_Roles= Staticvars.server_ip + "/api/admin/role/all/";

        public static string URL_Add_New_WezipeGosundy = Staticvars.server_ip + "/api/zahmet/goshundy/add/";
        public static string URL_Get_Byid_WezipeGosundy = Staticvars.server_ip + "/api/zahmet/goshundy/get/1";
        public static string URL_Update_WezipeGosundy = Staticvars.server_ip + "/api/zahmet/goshundy/update/";
        public static string URL_All_WezipeGosundy = Staticvars.server_ip + "/api/zahmet/goshundy/all/";

        public static string URL_Add_New_WezipeGornush = Staticvars.server_ip + "/api/zahmet/wezipegornush/add/";
        public static string URL_Get_Byid_WezipeGornush = Staticvars.server_ip + "/api/zahmet/wezipegornush/get/1";
        public static string URL_Update_WezipeGornush = Staticvars.server_ip + "/api/zahmet/wezipegornush/update/1";
        public static string URL_All_WezipeGornush = Staticvars.server_ip + "/api/zahmet/wezipegornush/all/?search=&limit=&page=";

        public static string URL_Add_New_Wezipe = Staticvars.server_ip + "/api/zahmet/wezipe/add/";
        public static string URL_Get_Byid_Wezipe = Staticvars.server_ip + "/api/zahmet/wezipe/get/";
        public static string URL_Update_Wezipe = Staticvars.server_ip + "/api/zahmet/wezipe/update/";
        public static string URL_All_Wezipe = Staticvars.server_ip + "/api/zahmet/wezipe/all/";




        public static string URL_Add_Mudirlik = Staticvars.server_ip + "/api/zahmet/mudirlik/add/";
        public static string URL_Get_Byid_Mudirlik = Staticvars.server_ip + "/api/zahmet/mudirlik/get/";
        public static string URL_Update_Mudirlik = Staticvars.server_ip + "/api/zahmet/mudirlik/update/";
        public static string URL_Get_All_Mudirlik = Staticvars.server_ip + "/api/zahmet/mudirlik/all/?hukuk=&search=&sort=asc&limit=10&page=";
        //public static string URL_Get_All_Mudirlik = Staticvars.server_ip + "/api/zahmet/wezipeler/count/by-gornush";

        public static string URL_Get_All_Hukuk = Staticvars.server_ip + "/api/zahmet/hukuk/all/?search=&limit=10&page=";

        public static string URL_Add_Bolum = Staticvars.server_ip + "/api/zahmet/bolumler/add/";
        public static string URL_Get_Byid_Bolum = Staticvars.server_ip + "/api/zahmet/bolumler/get/";
        public static string URL_Update_Bolum = Staticvars.server_ip + "/api/zahmet/bolumler/update/";
        public static string URL_Get_All_Bolum = Staticvars.server_ip + "/api/zahmet/bolumler/all/";

        public static string URL_Get_BolumCode = Staticvars.server_ip + "/api/zahmet/bolumcode/all/?search=&limit=10&page=";

        public static string URL_Add_Bolumce = Staticvars.server_ip + "/api/zahmet/bolumche/add/";
        public static string URL_Get_Byid_Bolumce = Staticvars.server_ip + "/api/zahmet/bolumche/get/";
        public static string URL_Update_Bolumce = Staticvars.server_ip + "/api/zahmet/bolumche/update/";
        public static string URL_Get_All_Bolumce = Staticvars.server_ip + "/api/zahmet/bolumche/all/";

        public static string URL_Add_Topar = Staticvars.server_ip + "/api/zahmet/toparlar/add/";
        public static string URL_Get_Byid_Topar = Staticvars.server_ip + "/api/zahmet/toparlar/get/";
        public static string URL_Update_Topar = Staticvars.server_ip + "/api/zahmet/toparlar/update/";
        public static string URL_Get_All_Topar = Staticvars.server_ip + "/api/zahmet/toparlar/all/";


        public static string URL_Add_Wezipeler = Staticvars.server_ip + "/api/zahmet/wezipeler/add/";
        public static string URL_Get_Byid_Wezipeler = Staticvars.server_ip + "/api/zahmet/wezipeler/get/";
        public static string URL_Update_Wezipeler = Staticvars.server_ip + "/api/zahmet/wezipeler/update/";
        public static string URL_Get_All_Wezipeler = Staticvars.server_ip + "/api/zahmet/wezipeler/all/";


        public static string URL_Add_WezipeCesme = Staticvars.server_ip + "/api/zahmet/wezipecheshme/add/";
        public static string URL_Get_Byid_WezipeCesme = Staticvars.server_ip + "/api/zahmet/wezipecheshme/get/";
        public static string URL_Update_WezipeCesme = Staticvars.server_ip + "/api/zahmet/wezipecheshme/update/";
        public static string URL_Get_All_WezipeCesme = Staticvars.server_ip + "/api/zahmet/wezipecheshme/all/";


    }
}
