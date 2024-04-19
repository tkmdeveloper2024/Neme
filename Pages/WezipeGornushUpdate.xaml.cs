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
    /// Логика взаимодействия для WezipeGornushUpdate.xaml
    /// </summary>
    public partial class WezipeGornushUpdate : Page
    {
        public static ComboBox Static_ofisercombo;
        public static ComboBox Static_goshundycombo;
        public static TextBox Static_Ady;
        public static TextBox Static_Buyrukbelgi;
        public static DatePicker Static_Buyruksene;
        public static TextBox Static_Oklad;
        public WezipeGornushUpdate()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            Static_Ady = Adytxt;
            Static_Buyrukbelgi = Buyrukbelgi;
            Static_Buyruksene = Buyruksene;
            Static_ofisercombo = Ofisercombo;
            Static_Oklad = Okladtxt;
            Static_goshundycombo = Gosundycombo;
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          

            Get_All_WezipeGornush(URLs.URL_All_WezipeGornush);
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy+ "?search=&limit=100&page=");
            Get_Byid_WezipeGornush(Staticvars.WezipegornushUID);



           Ofisercombo.SelectedIndex = Convert.ToInt32(Ofisercombo.Tag);
            Gosundycombo.SelectedIndex = Convert.ToInt32(Gosundycombo.Tag);
     
        }
        async public static void Get_All_WezipeGornush(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_WezipeGornush>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        WezipeGornushUpdate.Static_ofisercombo.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            WezipeGornushUpdate.Static_ofisercombo.Items.Add(new ComboBoxItem() { Content = item.Type.ToString(), Tag = item.Id });
                                        }
                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok (Get_WezipeGornush): " + await content.ReadAsStringAsync());
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

        async public static void Get_Byid_WezipeGornush(int? wezipegornushid)
        {

            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {
                        using (HttpResponseMessage response = await client.GetAsync(URLs.URL_Get_Byid_Wezipe + wezipegornushid))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Get_Wezipe>(result);

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {


                                        Static_Ady.Text = Root.name.ToString();
                                        Static_Buyrukbelgi.Text = Root.buyruk_number.ToString();
                                        Static_Buyruksene.Text = Root.date_of_buyruk;
                                        Static_ofisercombo.Tag = Root.wezipe_gornush_id;
                                        Static_ofisercombo.Text = Root.wezipe_gornush_type;
                                        Static_Oklad.Text = Root.oklad.ToString();
                                        Static_goshundycombo.Tag = Root.wezipe_goshundylar_id;
                                        Static_goshundycombo.Text = Root.wezipe_goshundylar_name;

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
        async public static void Get_All_WezipeGosundy(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Gosundy>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        WezipeGornushUpdate.Static_goshundycombo.Items.Clear();

                                        foreach (var item in Root.data)
                                        {

                                            WezipeGornushUpdate.Static_goshundycombo.Items.Add(new ComboBoxItem() { Content = item.Name, Tag = item.Id });
                                          
                                        }
                          
                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok (Get_WezipeGoshundy): " + await content.ReadAsStringAsync());
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


        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Adytxt.Text)&& !string.IsNullOrEmpty(Buyrukbelgi.Text)&&!string.IsNullOrEmpty(Buyruksene.Text))
            {
                if (Ofisercombo.SelectedIndex!=-1)
                {
                    if (!string.IsNullOrEmpty(Okladtxt.Text))
                    {
                        if (Gosundycombo.SelectedIndex!=-1)
                        {
                            DateTime selectedDate = Buyruksene.SelectedDate.GetValueOrDefault();

                            // Format the date into "YYYY-MM-DD" format
                            string formattedDate = selectedDate.ToString("yyyy-MM-dd");


                            Update_WezipeGornush( Adytxt.Text, Convert.ToInt32(((ComboBoxItem)this.Ofisercombo.SelectedItem).Tag), Okladtxt.Text, Convert.ToInt32(((ComboBoxItem)this.Gosundycombo.SelectedItem).Tag),Buyrukbelgi.Text, formattedDate);

                            NavigationService.Navigate(new Uri("Pages/Wezipeler.xaml", UriKind.Relative));
                        }
                        else
                        {
                            MessageBox.Show("Ähli maglumatlary giriziň!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ähli maglumatlary giriziň!");
                    }
                }
                else
                {
                    MessageBox.Show("Ähli maglumatlary giriziň!");
                }
            }
            else
            {
                MessageBox.Show("Ähli maglumatlary giriziň!");
            }

        }


        async public static void Update_WezipeGornush(string name, int? ofiserid, string oklad,int? wezipegoshundyid,string buyrukbelgi,string buyruksene )
        {
           
                using (var form = new MultipartFormDataContent())
                {

                    form.Add(new StringContent(name), "name");
                    form.Add(new StringContent(ofiserid.ToString()), "wezipe_gornush_id");
                    form.Add(new StringContent(oklad), "oklad");
                    form.Add(new StringContent(wezipegoshundyid.ToString()), "wezipe_goshundylar_id");
                form.Add(new StringContent(buyrukbelgi), "buyruk_number");
                form.Add(new StringContent(buyruksene.ToString()), "date_of_buyruk");

                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                            try
                            {
                                using (HttpResponseMessage response = await client.PutAsync(URLs.URL_Update_Wezipe + Staticvars.WezipegornushUID, form))
                                {
                                    using (HttpContent content = response.Content)
                                    {
                                        string answer = await content.ReadAsStringAsync();
                                  
                                        if (answer.Contains("Successfully!"))
                                        {
                                            MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                            Wezipeler.Get_All_Wezipe(URLs.URL_All_Wezipe+"?search=&goshundy=&sort=&limit=&page=");
                                        }
                                        else { MessageBox.Show(response.StatusCode.ToString()); }
                                    

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

          
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Wezipeler.xaml", UriKind.Relative));
        }

        private void Adytxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(Adytxt.Text) && !string.IsNullOrEmpty(Buyrukbelgi.Text) && !string.IsNullOrEmpty(Buyruksene.Text))
                {
                    if (Ofisercombo.SelectedIndex != -1)
                    {
                        if (!string.IsNullOrEmpty(Okladtxt.Text))
                        {
                            if (Gosundycombo.SelectedIndex != -1)
                            {
                                DateTime selectedDate = Buyruksene.SelectedDate.GetValueOrDefault();

                                // Format the date into "YYYY-MM-DD" format
                                string formattedDate = selectedDate.ToString("yyyy-MM-dd");


                                Update_WezipeGornush(Adytxt.Text, Convert.ToInt32(((ComboBoxItem)this.Ofisercombo.SelectedItem).Tag), Okladtxt.Text, Convert.ToInt32(((ComboBoxItem)this.Gosundycombo.SelectedItem).Tag), Buyrukbelgi.Text, formattedDate);

                                NavigationService.Navigate(new Uri("Pages/Wezipeler.xaml", UriKind.Relative));
                            }
                            else
                            {
                                MessageBox.Show("Ähli maglumatlary giriziň!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ähli maglumatlary giriziň!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ähli maglumatlary giriziň!");
                    }
                }
                else
                {
                    MessageBox.Show("Ähli maglumatlary giriziň!");
                }
            }

        }
    }
}
