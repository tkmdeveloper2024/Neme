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
using static Neme.Classes.WezipeGornush;

namespace Neme.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private bool error1, error2, error3, error4, error5, error6, error7;
        public static ComboBox Static_ofisercombo;
        public static ComboBox Static_goshundycombo;
        public static DataGrid dataGrid_Wezipeler;
        public static ComboBox comboBox1;
        public static ComboBox comboBox2;


        public Page1()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            Static_ofisercombo = Ofisercombo;
            Static_goshundycombo = Gosundycombo;

            dataGrid_Wezipeler = dataGrid_wezipeler;
            comboBox1 = combo1;
            comboBox2 = combo2;
           
        }

        private void Filterbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Expander_Filter.IsExpanded == false)
            {
                Expander_Filter.IsExpanded = true;
                Expander_Filter.BorderBrush = Brushes.Gray;
            }
            else
            {
                Expander_Filter.IsExpanded = false;
                Expander_Filter.BorderBrush = Brushes.Transparent;
            }
        
    }

        private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
        Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=" + Searchtxt.Text + "&goshundy=&sort=&limit=&page=");
         }
        async public static void Get_All_Wezipe(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Wezipe>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Page1.dataGrid_Wezipeler.Items.Clear();
                                        int id = 0;
                                        foreach (var item in Root.data)
                                        {
                                            id++;
                                            Page1.dataGrid_Wezipeler.Items.Add(new WezipeGornush()
                                            {
                                                Id = id,
                                                Uid = item.id,
                                                Name = item.name.ToString(),
                                                Wezipegornushid = item.wezipe_gornush_id,
                                                Wezipegornushtype = item.wezipe_gornush_type.ToString(),
                                                oklad = item.oklad,
                                                Wezipegoshundylarid = item.wezipe_goshundylar_id,
                                                Wezipegoshundylarname = item.wezipe_goshundylar_name.ToString(),

                                            });

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
        private void Expander_Filter_Expanded(object sender, RoutedEventArgs e)
        {

        }

        private void Expander_Filter_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private void FilterGo_Click(object sender, RoutedEventArgs e)
        {
            if (combo1.SelectedIndex != -1 && combo2.SelectedIndex != -1)
            {

                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Convert.ToInt32(((ComboBoxItem)this.combo2.SelectedItem).Tag) + "&sort=" + Convert.ToInt32(((ComboBoxItem)this.combo1.SelectedItem).Tag) + "&limit=10&page=");
            }
            else if (combo1.SelectedIndex != -1)
            {

                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=" + Convert.ToInt32(((ComboBoxItem)this.combo1.SelectedItem).Tag) + "&limit=10&page=");
            }
            else if (combo2.SelectedIndex != -1)
            {
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Convert.ToInt32(((ComboBoxItem)this.combo2.SelectedItem).Tag) + "&sort=&limit=10&page=");
            }

            combo1.SelectedIndex = -1;
            combo2.SelectedIndex = -1;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Save_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(Adytxt.Text)) { error1 = false; }
                else { error1 = true; }

                if (!string.IsNullOrEmpty(Buyrukbelgi.Text)) { error2 = false; }
                else { error2 = true; }

                if (!string.IsNullOrEmpty(Buyruksene.Text)) { error3 = false; }
                else { error3 = true; }

                if (Ofisercombo.SelectedIndex != -1) { error4 = false; }
                else { error4 = true; }

                if (!string.IsNullOrEmpty(Okladtxt.Text)) { error5 = false; }
                else { error5 = true; }

                if (Gosundycombo.SelectedIndex != -1) { error6 = false; }
                else { error6 = true; }


                if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false)
                {
                    DateTime selectedDate = Buyruksene.SelectedDate.GetValueOrDefault();

                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");


                    Add_New_Wezipe(Adytxt.Text, Buyrukbelgi.Text, formattedDate, Convert.ToInt32(((ComboBoxItem)this.Ofisercombo.SelectedItem).Tag), Okladtxt.Text, Convert.ToInt32(((ComboBoxItem)this.Gosundycombo.SelectedItem).Tag));

                    //   NavigationService.Navigate(new Uri("Pages/Wezipeler.xaml", UriKind.Relative));
                    Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=&limit=5&page=");

                    Adytxt.Clear();
                    Buyrukbelgi.Clear();
                    Ofisercombo.SelectedIndex = -1;
                    Okladtxt.Clear();
                    Gosundycombo.SelectedIndex = -1;
                    Buyruksene.SelectedDate = null;

                }
                else { MessageBox.Show("Ähli maglumatlary giriziň!"); }
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=desc&limit=5&page=");
            Get_All_WezipeGornush(URLs.URL_All_WezipeGornush);
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=100&page=");
        }

        private void Okladtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch)) // Check if the input character is a digit
                {
                    e.Handled = true; // If it's not a digit, handle the input to prevent it
                    return;
                }
            }
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
                                        Page1.Static_ofisercombo.Items.Clear();                                       
                                        foreach (var item in Root.data)
                                        {
                                        
                                           Page1.Static_ofisercombo.Items.Add(new ComboBoxItem() { Content = item.Type.ToString(), Tag = item.Id });
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
                                        Page1.Static_goshundycombo.Items.Clear();
                                        
                                        foreach (var item in Root.data)
                                        {

                                            Page1.Static_goshundycombo.Items.Add(new ComboBoxItem() { Content = item.Name, Tag = item.Id });
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
            if (!string.IsNullOrEmpty(Adytxt.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(Buyrukbelgi.Text)) { error2 = false; }
            else { error2 = true; }

            if (!string.IsNullOrEmpty(Buyruksene.Text)) { error3 = false; }
            else { error3 = true; }

            if (Ofisercombo.SelectedIndex != -1) { error4 = false; }
            else { error4 = true; }

            if (!string.IsNullOrEmpty(Okladtxt.Text)) { error5 = false; }
            else { error5 = true; }

            if (Gosundycombo.SelectedIndex != -1) { error6 = false; }
            else { error6= true; }


            if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false)
            {
                DateTime selectedDate = Buyruksene.SelectedDate.GetValueOrDefault();

                string formattedDate = selectedDate.ToString("yyyy-MM-dd");


                Add_New_Wezipe(Adytxt.Text,Buyrukbelgi.Text,formattedDate, Convert.ToInt32(((ComboBoxItem)this.Ofisercombo.SelectedItem).Tag), Okladtxt.Text,Convert.ToInt32(((ComboBoxItem)this.Gosundycombo.SelectedItem).Tag));

                //   NavigationService.Navigate(new Uri("Pages/Wezipeler.xaml", UriKind.Relative));
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=&limit=5&page=");

                Adytxt.Clear();
                Buyrukbelgi.Clear();
                Ofisercombo.SelectedIndex = -1;
                Okladtxt.Clear();
                Gosundycombo.SelectedIndex = -1;
                Buyruksene.SelectedDate = null;

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }


        }

        async public static void Add_New_Wezipe(string ady,string buyrukbelgi,string sene, int ofisercombo, string oklad,int gosundycombo)
        {
            
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(ady), "name");              
                form.Add(new StringContent(ofisercombo.ToString()), "wezipe_gornush_id");
                form.Add(new StringContent(oklad), "oklad");
                form.Add(new StringContent(gosundycombo.ToString()), "wezipe_goshundylar_id");
                form.Add(new StringContent(buyrukbelgi), "buyruk_number");
                form.Add(new StringContent(sene), "date_of_buyruk");
                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                   

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Add_New_Wezipe, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                   
                                    string answer = await content.ReadAsStringAsync();
                                  
                              
                                    if (answer.Contains("successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli goşuldy!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                      
                                    }
                                    else { MessageBox.Show(answer); }
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
    }
}
