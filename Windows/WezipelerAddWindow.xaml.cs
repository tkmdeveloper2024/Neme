using Neme.Classes;
using Neme.Pages;
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
using System.Windows.Shapes;

namespace Neme.Windows
{
    /// <summary>
    /// Логика взаимодействия для WezipelerAddWindow.xaml
    /// </summary>
    public partial class WezipelerAddWindow : Window
    {
        private bool error1, error2, error3, error4, error5, error6, error7,error8,error9,error10,error11,error12;

        public static ComboBox Static_WezipeGoshundy;  
        public static ComboBox Static_WezipeBuyrukady;
        public static ComboBox Static_Maliyecesme;
        public static TextBox Static_Oklad;
        public static List<WezipeGornush> Wezipegornushlist;
      
        public WezipelerAddWindow()
        {
            InitializeComponent();

            Wezipegornushlist = new List<WezipeGornush>();
            Static_WezipeGoshundy = Wezipegoshundy;           
            Static_WezipeBuyrukady = Wezipeady;
            Static_Maliyecesme = Maliyecesme;



        }     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy);
            Get_WezipeCesme(URLs.URL_Get_All_WezipeCesme);


        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Wezipegoshundy.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(Wezipedolyady.Text)) { error2 = false; }
            else { error2 = true; }

            if (Wezipeady.SelectedIndex != -1) { error3 = false; }
            else { error3 = true; }

            if (Maliyecesme.SelectedIndex != -1) { error4 = false; }
            else { error4 = true; }

            if (!string.IsNullOrEmpty(Wezipegornush.Text)) { error5 = false; }
            else { error5 = true; }
          
            if (WezipeHarbyYoriteAdyGornush.SelectedIndex != -1) { error8 = false; }
            else { error8 = true; }
            
            if (WezipeHarbyYoriteAdy.SelectedIndex != -1) { error9 = false; }
            else { error9 = true; }

            if (!string.IsNullOrEmpty(WezipeZahmetHaky.Text)) { error6 = false; }
            else { error6 = true; }

            if (!string.IsNullOrEmpty(Buyruknumber.Text)) { error7 = false; }
            else { error7 = true; }
            
             if (!string.IsNullOrEmpty(Buyruksene.Text)) { error10 = false; }
            else { error10 = true; }

            if (!string.IsNullOrEmpty(WezipeSany.Text)) { error11 = false; }
            else { error11 = true; }

            if (!string.IsNullOrEmpty(WezipeYzygiderlik.Text)) { error12 = false; }
            else { error12 = true; }


            if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false && error7 == false && error8 == false && error9 == false && error10== false && error11== false && error12 == false)
            {
                DateTime selectedDate = Buyruksene.SelectedDate.GetValueOrDefault();

                string formattedDate = selectedDate.ToString("yyyy-MM-dd");



                Add_Wezipe(Wezipedolyady.Text,
                    Convert.ToInt32(((TextBox)this.Wezipegornush).Tag),
                    Convert.ToInt32(((ComboBoxItem)this.Wezipegoshundy.SelectedItem).Tag),
                    Convert.ToInt32(((ComboBoxItem)this.Wezipeady.SelectedItem).Tag),
                    Convert.ToInt32(((ComboBoxItem)this.Maliyecesme.SelectedItem).Tag),                    
                    Convert.ToInt32(((ComboBoxItem)this.WezipeHarbyYoriteAdyGornush.SelectedItem).Tag),
                    Convert.ToInt32(((ComboBoxItem)this.WezipeHarbyYoriteAdy.SelectedItem).Tag),       
                    WezipeSany.Text,
                    WezipeYzygiderlik.Text,
                    WezipeZahmetHaky.Text,
                    Buyruknumber.Text,
                    formattedDate);

                this.Close();

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }
        }

        async public static void Add_Wezipe( string ady, int? wezipegornushid, int? gosundyid, int? wezipeid,  int? cesmeid, int? zwanyegornusid, int? zwanyeid, string sany, string yzygiderlik,string oklad,string buyruksene,string buyruknumber)
        {
            using (var form = new MultipartFormDataContent())
            {
                
                form.Add(new StringContent(ady), "fullName");
                form.Add(new StringContent(wezipegornushid.ToString()), "wezipe_gornush_id");
                form.Add(new StringContent(gosundyid.ToString()), "wezipe_goshundylar_id");
                form.Add(new StringContent(wezipeid.ToString()), "wezipe_id");
                form.Add(new StringContent(cesmeid.ToString()), "wezipe_cheshme_id");
                form.Add(new StringContent(zwanyegornusid.ToString()), "zvanye_gornush_id");
                form.Add(new StringContent(zwanyeid.ToString()), "zvanye_id");
                form.Add(new StringContent(sany.ToString()), "count");
                form.Add(new StringContent(yzygiderlik.ToString()), "yzygiderlik");
                form.Add(new StringContent(Staticvars.mudirlikid.ToString()), "mudirlikler_id");
                if (Staticvars.bolumid != null)
                {
                    form.Add(new StringContent(Staticvars.bolumid.ToString()), "bolumler_id");
                }
                if (Staticvars.bolumceid != null)
                {
                    form.Add(new StringContent(Staticvars.bolumceid.ToString()), "bolumcheler_id");
                }
                if (Staticvars.toparid != null)
                {
                    form.Add(new StringContent(Staticvars.toparid.ToString()), "toparlar_id");
                }
                // form.Add(new StringContent(Staticvars.toparid.ToString()), "toparlar_id");    oklad ucin ?
                form.Add(new StringContent(buyruksene), "opened_date");
                form.Add(new StringContent(buyruknumber), "created_number_of_buyruk");

                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Add_Wezipeler, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                             


                                    if (answer.Contains("successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli goşuldy");

                                        HasapPage.Get_All_Bolum(URLs.URL_Get_All_Bolum + "?sort=asc&hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolumcode=&search=&limit=10&page=");


                                    }
                                    else { MessageBox.Show(answer.ToString()); }

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
                                        WezipelerAddWindow.Static_WezipeGoshundy.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            WezipelerAddWindow.Static_WezipeGoshundy.Items.Add(new ComboBoxItem() { Content = item.Name.ToString(), Tag = item.Id });

                  
                                            
                                        }
                                     
                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok : " + await content.ReadAsStringAsync());
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
        async public static void Get_WezipeCesme(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_WezipeCesme>(result);
                         

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        WezipelerAddWindow.Static_Maliyecesme.Items.Clear();
                                        foreach (var item in Root.data)
                                        {
                                            WezipelerAddWindow.Static_Maliyecesme.Items.Add(new ComboBoxItem() { Content = item.name.ToString(), Tag = item.id });
                                        }

                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok : " + await content.ReadAsStringAsync());
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

        private void WezipeYzygiderlik_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void WezipeSany_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void Wezipegoshundy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValue = ((ComboBoxItem)Wezipegoshundy.SelectedItem).Tag.ToString();
           

            Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + selectedValue + "&sort=&limit=100&page=");
            
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
                       

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        WezipelerAddWindow.Static_WezipeBuyrukady.Items.Clear();
                                       
                                        foreach (var item in Root.data)
                                        {
                                            WezipelerAddWindow.Static_WezipeBuyrukady.Items.Add(new ComboBoxItem() { Content = item.name.ToString(), Tag = item.id });

                                            Wezipegornushlist.Add(new WezipeGornush()
                                            {
                                                Id = item.id,
                                                Name = item.name,
                                                Wezipegornushid = item.wezipe_gornush_id,
                                                Wezipegornushtype = item.wezipe_gornush_type,
                                                Wezipegoshundylarid = item.wezipe_goshundylar_id,
                                                Wezipegoshundylarname = item.wezipe_goshundylar_name,
                                                oklad = item.oklad,
                                                Buyruknumber = item.buyruk_number,
                                                Buyrukdate = item.date_of_buyruk
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
        private void Wezipeady_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                   
            string selectedValue = ((ComboBoxItem)Static_WezipeBuyrukady.SelectedItem).Tag.ToString();

            foreach(WezipeGornush item in Wezipegornushlist)
            {   
              
                if (item.Id == Convert.ToInt32(selectedValue))
                {
                  
                   WezipeZahmetHaky.Text = item.oklad.ToString();
                    Wezipegornush.Text = item.Wezipegornushtype.ToString();
                    Wezipegornush.Tag = item.Wezipegornushid;
                    Buyruknumber.Text = item.Buyruknumber;
                    Buyruksene.Text = item.Buyrukdate;

                }
            }
        

            



        }


    }
}
