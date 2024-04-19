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
    /// Логика взаимодействия для BolumceAddWindow.xaml
    /// </summary>
    public partial class BolumceAddWindow : Window
    {
        private bool error1, error2, error3, error4, error5, error6, error7;

        private void Bolumceyzygiderlik_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        public static ComboBox Hukuk;
        public BolumceAddWindow()
        {
            InitializeComponent();
            Hukuk=Bolumcehukuk;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Get_Hukuk();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Bolumceady.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(Bolumcedolyady.Text)) { error2 = false; }
            else { error2 = true; }    

            if (Bolumcehukuk.SelectedIndex != -1) { error3 = false; }
            else { error3 = true; }

            if (!string.IsNullOrEmpty(Bolumcesene.Text)) { error4 = false; }
            else { error4 = true; }

            if (!string.IsNullOrEmpty(Bolumcebuyruk.Text)) { error5 = false; }
            else { error5 = true; }

            if (!string.IsNullOrEmpty(Bolumceyzygiderlik.Text)) { error6 = false; }
            else { error6 = true; }
            



            if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false )
            {
                DateTime selectedDate = Bolumcesene.SelectedDate.GetValueOrDefault();

     
                // Format the date into "YYYY-MM-DD" format
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");
        

                Add_Bolumce(Bolumceady.Text, Bolumcedolyady.Text, Convert.ToInt32(((ComboBoxItem)this.Bolumcehukuk.SelectedItem).Tag), formattedDate, Bolumcebuyruk.Text, Bolumceyzygiderlik.Text);

                this.Close();

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }

        }
        async public static void Add_Bolumce(string ady, string dolyady, int? hukuk, string sene, string buyruk, string yzygiderlik)
        {
            using (var form = new MultipartFormDataContent())
            {

                if (Staticvars.bolumid != null)
                {
                    form.Add(new StringContent(ady), "name");
                    form.Add(new StringContent(dolyady), "full_name");
                    form.Add(new StringContent(hukuk.ToString()), "hukuk_id");
                    form.Add(new StringContent(yzygiderlik), "yzygiderlik");
                    form.Add(new StringContent(Staticvars.mudirlikid.ToString()), "mudirlikler_id");
                    form.Add(new StringContent(Staticvars.bolumid.ToString()), "bolumler_id");
                    form.Add(new StringContent(sene), "opened_date");
                    form.Add(new StringContent(buyruk), "created_date_of_buyruk");
                }
                else
                {
                    form.Add(new StringContent(ady), "name");
                    form.Add(new StringContent(dolyady), "full_name");
                    form.Add(new StringContent(hukuk.ToString()), "hukuk_id");
                    form.Add(new StringContent(yzygiderlik), "yzygiderlik");
                    form.Add(new StringContent(Staticvars.mudirlikid.ToString()), "mudirlikler_id");
                  
                    form.Add(new StringContent(sene), "opened_date");
                    form.Add(new StringContent(buyruk), "created_date_of_buyruk");
                }


                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Add_Bolumce, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                    if (answer.Contains("successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli goşuldy");

                                       // HasapPage.Get_All_Bolumce(URLs.URL_Get_All_Bolumce);
                                       HasapPage.Get_All_Bolumce(URLs.URL_Get_All_Bolumce + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum="+Staticvars.bolumid+"&search=&sort=desc&limit=10&page=");

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


        async public static void Get_Hukuk()
        {
            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {


                        using (HttpResponseMessage response = await client.GetAsync(URLs.URL_Get_All_Hukuk))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Hukuk>(result);


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {

                                        BolumceAddWindow.Hukuk.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            BolumceAddWindow.Hukuk.Items.Add(new ComboBoxItem() { Content = item.Name.ToString(), Tag = item.Id });
                                        }


                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok (Get_Divisions): " + await content.ReadAsStringAsync());
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
    }
}
