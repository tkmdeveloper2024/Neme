using Neme.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neme.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatSanawy.xaml
    /// </summary>
    public partial class StatSanawy : Page
    {
        public static ComboBox Static_MudirlikList;
        public static DataGrid Static_WeziplerList;
        public static int id = 0;
        public StatSanawy()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            Static_MudirlikList = MudirlikList;
            Static_WeziplerList = dataGrid_Stat;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                if (Staticvars.mudirlikid != null)
                {

                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                if (Staticvars.mudirlikid != null)
                {
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            }
            catch (Exception ex)
            { }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Get_All_Mudirlik(URLs.URL_Get_All_Mudirlik);
            }
            catch (Exception ex)
            { }
        }


        async public static void Get_All_Mudirlik(string url)
        {

            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {


                        using (HttpResponseMessage response = await client.GetAsync(url))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Mudirlik>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        StatSanawy.Static_MudirlikList.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            StatSanawy.Static_MudirlikList.Items.Add(new ComboBoxItem { Content = item.name, Tag = item.id });

                                        }

                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok (Get_Rules): " + await content.ReadAsStringAsync());
                            }
                            else
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Ýalňyşlyk: " + await content.ReadAsStringAsync());
                                MessageBox.Show(response.ToString());
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        WebExceptionStatus status = ex.Status;
                        if (status == WebExceptionStatus.ProtocolError)
                        {
                            HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                            MessageBox.Show("Статусный код ошибки: " + (int)httpResponse.StatusCode + " - " + httpResponse.StatusCode);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка WebException: " + ex.Message);
                        }
                    }
                    catch (HttpRequestException request_ex)
                    {
                        MessageBox.Show("Ошибка HttpRequestException: " + request_ex.Message);
                    }
                }
            }
            else
            {

                MessageBox.Show("Tokeniň wagty gutardy, programmany täzeden açyň!");
            }


        }
        async public static void Get_All_Wezipeler(string url)
        {

            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {


                        using (HttpResponseMessage response = await client.GetAsync(url))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Models_Get_StatkaWezipeler>(result);
                                    /*      Staticvars.current = Root.currentPage;
                                          Staticvars.last = Root.lastPage;
                                          Staticvars.total = Root.total;*/


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        StatSanawy.Static_WeziplerList.Items.Clear();

                                        if (Root.data == null || !Root.data.Any())
                                        {
                                            Static_WeziplerList.ItemsSource = null; // Set the ListView's ItemsSource to null to display nothing
                                        }
                                        else
                                        {
                                            foreach (var item in Root.data)
                                            {

                                                id++;
                                                StatSanawy.Static_WeziplerList.Items.Add(new StatkaWezipeler()
                                                {
                                                    Id = id,
                                                    Uid = item.id,
                                                    Fullname = item.full_name.ToString(),
                                                    Wezipegornushid = item.wezipe_gornush_id,
                                                    Wezipegornushtype = item.wezipe_gornush_type.ToString(),
                                                    zwanyegornushid = item.zvanye_gornush_id,
                                                    zwanyegornushname = item.zvanye_gornush_name,
                                                    zwanyeid = item.zvanye_id,
                                                    zwanyename = item.zvanye_fullname,
                                                    count = item.count,
                                                    Wezipegoshundylarid = item.wezipe_goshundylar_id,
                                                    Wezipegoshundylarname = item.wezipe_goshundylar_name.ToString(),

                                                });

                                            }
                                        }



                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok :" + await content.ReadAsStringAsync());
                            }
                            else
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Ýalňyşlyk: " + await content.ReadAsStringAsync());
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        WebExceptionStatus status = ex.Status;
                        if (status == WebExceptionStatus.ProtocolError)
                        {
                            HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                            MessageBox.Show("Статусный код ошибки: " + (int)httpResponse.StatusCode + " - " + httpResponse.StatusCode);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка WebException: " + ex.Message);
                        }
                    }
                    catch (HttpRequestException request_ex)
                    {
                        MessageBox.Show("Ошибка HttpRequestException: " + request_ex.Message);
                    }
                }
            }
            else
            {

                MessageBox.Show("Tokeniň wagty gutardy, programmany täzeden açyň!");
            }


        }

        private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                if (Staticvars.mudirlikid != null)
                {

                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search="+Searchtxt.Text+"&mudirlik=" + Staticvars.mudirlikid + "&bolum=&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
