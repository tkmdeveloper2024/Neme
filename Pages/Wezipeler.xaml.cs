using Neme.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для Wezipeler.xaml
    /// </summary>
    public partial class Wezipeler : Page
    {
        public static DataGrid dataGrid_Wezipeler;
        public static ComboBox comboBox1;
        public static ComboBox comboBox2;
        public static Label Counterlbl;
        public static int id = 0;

        public Wezipeler()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            dataGrid_Wezipeler = dataGrid_wezipeler;
            comboBox1 = combo1;
            comboBox2 = combo2;
            Counterlbl = Counter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            id = 0;
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=desc&limit=10&page=1");

           
            Get_All_WezipeGornush(URLs.URL_All_WezipeGornush);
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy);
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
                                       
                                        Wezipeler.dataGrid_Wezipeler.Items.Clear();
                                        
                                        foreach (var item in Root.data)
                                        {
                                            id++;
                                            Wezipeler.dataGrid_Wezipeler.Items.Add(new WezipeGornush()
                                            {
                                                Id = id,
                                                Uid=item.id,
                                                Name = item.name.ToString(),
                                                Wezipegornushid = item.wezipe_gornush_id,
                                                Wezipegornushtype = item.wezipe_gornush_type.ToString(),
                                                oklad = item.oklad,
                                                Wezipegoshundylarid=item.wezipe_goshundylar_id,
                                                Wezipegoshundylarname = item.wezipe_goshundylar_name.ToString(),
                                           
                                            });

                                        }
                                        Wezipeler.Counterlbl.Content = "(" + Root.total.ToString() + ")";
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
                       

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Wezipeler.comboBox1.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            Wezipeler.comboBox1.Items.Add(new ComboBoxItem() { Content = item.Type.ToString(), Tag = item.Id });
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
                                    

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Wezipeler.comboBox2.Items.Clear();

                                        foreach (var item in Root.data)
                                        {

                                            Wezipeler.comboBox2.Items.Add(new ComboBoxItem() { Content = item.Name, Tag = item.Id });
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
    

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
             
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy="+ Convert.ToInt32(((ComboBoxItem)this.combo2.SelectedItem).Tag) + "&sort="+ Convert.ToInt32(((ComboBoxItem)this.combo1.SelectedItem).Tag) + "&limit=10&page=");
            }
            else if (combo1.SelectedIndex != -1)
            {
             
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=" + Convert.ToInt32(((ComboBoxItem)this.combo1.SelectedItem).Tag) + "&limit=10&page=");
            }
            else if (combo2.SelectedIndex != -1)
            {
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy="+ Convert.ToInt32(((ComboBoxItem)this.combo2.SelectedItem).Tag) + "&sort=&limit=10&page=");
            }

            combo1.SelectedIndex = -1;
            combo2.SelectedIndex = -1;
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
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=" + Searchtxt.Text + "&goshundy=&sort=desc&limit=&page=");
        }

        private void Otuzlukbtn_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Otuzlukbtn.Content) - 1) * 10);
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=desc&limit=10&page="+Convert.ToInt32(Otuzlukbtn.Content)+"");
            
        }

        private void Yigrimlikbtn_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Yigrimlikbtn.Content) - 1) * 10);
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=desc&limit=10&page=" + Convert.ToInt32(Yigrimlikbtn.Content) + "");
        }

        private void Onlukbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Onlukbtn.Content) != 1)
            {
                id = 1;
                id = id * ((Convert.ToInt32(Onlukbtn.Content) - 1) * 10);
            }
            else
            {
                id = 0;
            }
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=&sort=desc&limit=10&page=" + Convert.ToInt32(Onlukbtn.Content) + "");
        }

        private void Rightside_Click(object sender, RoutedEventArgs e)
        {
            

           int bir= Convert.ToInt32(Onlukbtn.Content);
           int iki = Convert.ToInt32(Yigrimlikbtn.Content);
           int uc = Convert.ToInt32(Otuzlukbtn.Content);
                      
            if (uc < Convert.ToInt32(Staticvars.last))
            {
                bir = iki;
                iki = uc;
                uc++;
                Onlukbtn.Content = bir.ToString();
                Yigrimlikbtn.Content = iki.ToString();
                Otuzlukbtn.Content = uc.ToString();

            }
        }

        private void Leftside_Click(object sender, RoutedEventArgs e)
        {
            int bir = Convert.ToInt32(Onlukbtn.Content);
            int iki = Convert.ToInt32(Yigrimlikbtn.Content);
            int uc = Convert.ToInt32(Otuzlukbtn.Content);

            if (bir > 1)
            {
                bir = bir - 1;
                iki = iki - 1;
                uc = uc - 1;
                Onlukbtn.Content = bir.ToString();
                Yigrimlikbtn.Content = iki.ToString();
                Otuzlukbtn.Content = uc.ToString();

            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            WezipeGornush my_items = new WezipeGornush();
            if (dataGrid_Wezipeler.SelectedItems.Count > 0)
            {
                foreach (var obj in dataGrid_Wezipeler.SelectedItems)
                {
                    my_items = obj as WezipeGornush;
                }
                Staticvars.WezipegornushUID = my_items.Uid;

            }

            NavigationService.Navigate(new Uri("Pages/WezipeGornushUpdate.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
