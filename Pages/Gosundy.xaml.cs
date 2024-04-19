using Neme.Classes;
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
using Newtonsoft.Json;
namespace Neme.Pages
{
    /// <summary>
    /// Логика взаимодействия для Gosundy.xaml
    /// </summary>
    public partial class Gosundy : Page
    {
        public static DataGrid dataGrid_Gosundy;

        public Gosundy()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();

            dataGrid_Gosundy = dataGrid_latestgosundy;
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=5&page=1");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Gosundynumber.Text))
            {
                if (!string.IsNullOrEmpty(Gosundysubject.Text))
                {
                   
                  Add_Gosundy(Gosundynumber.Text,Gosundysubject.Text);


                    Gosundynumber.Clear();
                    Gosundysubject.Clear();
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


        async public static void Add_Gosundy(string gosnumber, string gossubject)
        {


            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(gosnumber), "name");
                form.Add(new StringContent(gossubject), "text");

                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {


                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Add_New_WezipeGosundy, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                    if (answer.Contains("successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli goşuldy!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                        Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy);
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
                                        Gosundy.dataGrid_Gosundy.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            Gosundy.dataGrid_Gosundy.Items.Add(new GosundyClass()
                                            {
                                                Gosundy_ID = item.Id,
                                                Gosundy_Number = item.Name.ToString(),
                                                Gosundy_Subject = item.Text.ToString(),
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

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gosundynumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(Gosundynumber.Text))
                {
                    if (!string.IsNullOrEmpty(Gosundysubject.Text))
                    {

                        Add_Gosundy(Gosundynumber.Text, Gosundysubject.Text);


                        Gosundynumber.Clear();
                        Gosundysubject.Clear();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=" + Searchtxt.Text + "&limit=5&page=1");
        }
    }
}
