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

namespace Neme.Pages._2
{
    /// <summary>
    /// Логика взаимодействия для WezipelerAll.xaml
    /// </summary>
    public partial class WezipelerAll : Page
    {
        public static DataGrid dataGrid_Wezipeler;
        public static ComboBox comboBox1;
        public static ComboBox comboBox2;
        public static Label Counterlbl;
        public static int id = 0;
        public WezipelerAll()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();

            dataGrid_Wezipeler = dataGrid_wezipeler;
            comboBox1 = combo1;
            comboBox2 = combo2;
            Counterlbl = Counter;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Staticvars.Uid != null)
            {
                id = 0;
                Task task1 = Task.Run(() => Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Staticvars.Uid + "&sort=desc&limit=10&page=1"));

            }
         
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
                                        WezipelerAll.dataGrid_Wezipeler.Items.Clear();
                                     
                                        foreach (var item in Root.data)
                                        {
                                            id++;
                                            WezipelerAll.dataGrid_Wezipeler.Items.Add(new WezipeGornush()
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
                                        WezipelerAll.Counterlbl.Content = "(" + Root.total.ToString() + ")";
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
                                        WezipelerAll.comboBox1.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            WezipelerAll.comboBox1.Items.Add(new ComboBoxItem() { Content = item.Type.ToString(), Tag = item.Id });
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
                                        WezipelerAll.comboBox2.Items.Clear();

                                        foreach (var item in Root.data)
                                        {

                                            WezipelerAll.comboBox2.Items.Add(new ComboBoxItem() { Content = item.Name, Tag = item.Id });
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

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Gosundylar.xaml", UriKind.Relative));
        }

        private void Otuzluk_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Otuzluk.Content) - 1) * 10);
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Staticvars.Uid + "&sort=desc&limit=10&page=" + Convert.ToInt32(Otuzluk.Content) + "");
        }

        private void Yigrimlik_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Yigrimlik.Content) - 1) * 10);
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Staticvars.Uid + "&sort=desc&limit=10&page=" + Convert.ToInt32(Yigrimlik.Content) + "");
        }

        private void Onluk_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Onluk.Content) != 1)
            {
                id = 1;
                id = id * ((Convert.ToInt32(Onluk.Content) - 1) * 10);
            }
            else
            {
                id = 0;
            }
            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Staticvars.Uid + "&sort=desc&limit=10&page=" + Convert.ToInt32(Onluk.Content) + "");
        }

        private void Leftside_Click(object sender, RoutedEventArgs e)
        {
            int bir = Convert.ToInt32(Onluk.Content);
            int iki = Convert.ToInt32(Yigrimlik.Content);
            int uc = Convert.ToInt32(Otuzluk.Content);

            if (bir > 1)
            {
                bir = bir - 1;
                iki = iki - 1;
                uc = uc - 1;
                Onluk.Content = bir.ToString();
                Yigrimlik.Content = iki.ToString();
                Otuzluk.Content = uc.ToString();

            }
        }

        private void Rightside_Click(object sender, RoutedEventArgs e)
        {

            int bir = Convert.ToInt32(Onluk.Content);
            int iki = Convert.ToInt32(Yigrimlik.Content);
            int uc = Convert.ToInt32(Otuzluk.Content);

            if (uc < Convert.ToInt32(Staticvars.last))
            {
                bir = iki;
                iki = uc;
                uc++;
                Onluk.Content = bir.ToString();
                Yigrimlik.Content = iki.ToString();
                Otuzluk.Content = uc.ToString();

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

            NavigationService.Navigate(new Uri("Pages/2/WezipeGornushUpdate2.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
