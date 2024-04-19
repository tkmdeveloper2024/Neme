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
    /// Логика взаимодействия для ToparEdit.xaml
    /// </summary>
    public partial class ToparEdit : Window
    {
        private bool error1, error2, error3, error4, error5, error6, error7;
        public static TextBox Static_Toparady;
        public static TextBox Static_Topardolyady;
        public static ComboBox Hukuk;

        public static DatePicker Static_Toparsene;
        public static TextBox Static_Toparbuyruk;
        public static TextBox Static_Toparyzygiderlik;

        private void Toparyzygiderlik_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        public ToparEdit()
        {
            InitializeComponent();
            Static_Toparady = Toparady;
            Static_Topardolyady = Topardolyady;
            Hukuk = Toparhukuk;
            Static_Toparsene = Toparsene;
            Static_Toparbuyruk = Toparbuyruk;
            Static_Toparyzygiderlik = Toparyzygiderlik;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Get_Hukuk();

            Get_Byid_Topar(Staticvars.toparid);

            Toparhukuk.SelectedIndex = Convert.ToInt32(Toparhukuk.Tag);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Toparady.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(Topardolyady.Text)) { error2 = false; }
            else { error2 = true; }

            if (Toparhukuk.SelectedIndex != -1) { error3 = false; }
            else { error3 = true; }

            if (!string.IsNullOrEmpty(Toparsene.Text)) { error4 = false; }
            else { error4 = true; }

            if (!string.IsNullOrEmpty(Toparbuyruk.Text)) { error5 = false; }
            else { error5 = true; }

            if (!string.IsNullOrEmpty(Toparyzygiderlik.Text)) { error6 = false; }
            else { error6 = true; }




            if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false)
            {
                DateTime selectedDate = Toparsene.SelectedDate.GetValueOrDefault();

             
                // Format the date into "YYYY-MM-DD" format
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");


                Update_Topar(Toparady.Text, Topardolyady.Text, Convert.ToInt32(((ComboBoxItem)this.Toparhukuk.SelectedItem).Tag), formattedDate, Toparbuyruk.Text, Toparyzygiderlik.Text);

                this.Close();

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }
        }


        async public static void Update_Topar(string ady, string dolyady, int? hukuk, string sene, string buyruk, string yzygiderlik)
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
                    form.Add(new StringContent(Staticvars.bolumceid.ToString()), "bolumcheler_id");
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

                    form.Add(new StringContent(Staticvars.bolumceid.ToString()), "bolumcheler_id");
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
                            using (HttpResponseMessage response = await client.PutAsync(URLs.URL_Update_Topar + Staticvars.toparid, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                    if (answer.Contains("Successfully!"))
                                    {
                                        MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                                        HasapPage.Get_All_Topar(URLs.URL_Get_All_Topar + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&search=&sort=&limit=10&page=");

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
        async public static void Get_Byid_Topar(int? toparid)
        {

            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {
                        using (HttpResponseMessage response = await client.GetAsync(URLs.URL_Get_Byid_Topar + toparid))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Get_Topar>(result);

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Static_Toparady.Text = Root.name.ToString();
                                        Static_Topardolyady.Text = Root.full_name.ToString();
                                        Hukuk.Tag = Root.hukuk_id;
                                        Hukuk.Text = Root.hukuk_name;
                                        Static_Toparsene.Text = Root.opened_date;
                                        Static_Toparbuyruk.Text = Root.created_date_of_buyruk;
                                        Static_Toparyzygiderlik.Text = Root.yzygiderlik.ToString();



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

                                        ToparEdit.Hukuk.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            ToparEdit.Hukuk.Items.Add(new ComboBoxItem() { Content = item.Name.ToString(), Tag = item.Id });
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
