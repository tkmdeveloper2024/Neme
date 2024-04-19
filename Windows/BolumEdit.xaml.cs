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
    /// Логика взаимодействия для BolumEdit.xaml
    /// </summary>
    public partial class BolumEdit : Window
    {
        private bool error1, error2, error3, error4, error5, error6, error7;
        public static TextBox Static_Bolumady;
        public static TextBox Static_Bolumdolyady;
        public static ComboBox Hukuk;
        public static ComboBox Code;
        public static DatePicker Static_Bolumsene;
        public static TextBox Static_Bolumbuyruk;
        public static TextBox Static_Bolumyzygiderlik;
      
        public BolumEdit()
        {
            InitializeComponent();
            Static_Bolumady = Bolumady;
            Static_Bolumdolyady = Bolumdolyady;
            Hukuk = Bolumhukuk;
            Code = Bolumcode;
            Static_Bolumsene = Bolumsene;
            Static_Bolumbuyruk = Bolumbuyruk;
            Static_Bolumyzygiderlik = Bolumyzygiderlik;
        }

        private void Bolumyzygiderlik_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Get_Hukuk();
            Get_BolumCode();
            Get_Byid_Bolum(Staticvars.bolumid);

            Bolumhukuk.SelectedIndex = Convert.ToInt32(Bolumhukuk.Tag);
            Bolumcode.SelectedIndex = Convert.ToInt32(Bolumcode.Tag);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Bolumady.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(Bolumdolyady.Text)) { error2 = false; }
            else { error2 = true; }

            if (Bolumcode.SelectedIndex != -1) { error3 = false; }
            else { error3 = true; }

            if (Bolumhukuk.SelectedIndex != -1) { error4 = false; }
            else { error4 = true; }

            if (!string.IsNullOrEmpty(Bolumsene.Text)) { error5 = false; }
            else { error5 = true; }

            if (!string.IsNullOrEmpty(Bolumbuyruk.Text)) { error6 = false; }
            else { error6 = true; }

            if (!string.IsNullOrEmpty(Bolumyzygiderlik.Text)) { error7 = false; }
            else { error7 = true; }
            

            if (error1 == false && error2 == false && error3 == false && error4 == false && error5 == false && error6 == false && error7 == false)
            {
                DateTime selectedDate = Bolumsene.SelectedDate.GetValueOrDefault();
                
                // Format the date into "YYYY-MM-DD" format
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            

                Update_Bolum(Bolumady.Text, Bolumdolyady.Text, Convert.ToInt32(((ComboBoxItem)this.Bolumcode.SelectedItem).Tag), Convert.ToInt32(((ComboBoxItem)this.Bolumhukuk.SelectedItem).Tag), formattedDate, Bolumbuyruk.Text, Bolumyzygiderlik.Text);

                this.Close();

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }

        }
        async public static void Update_Bolum(string ady, string dolyady, int? code, int? hukuk, string sene, string buyruk, string yzygiderlik)
        {

            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(ady), "name");
                form.Add(new StringContent(dolyady), "fullName");
                form.Add(new StringContent(code.ToString()), "code_id");
                form.Add(new StringContent(hukuk.ToString()), "hukuk_id");
                form.Add(new StringContent(yzygiderlik), "yzygiderlik"); 
                form.Add(new StringContent(sene), "opened_date");
                form.Add(new StringContent(buyruk), "created_date_of_buyruk");


                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PutAsync(URLs.URL_Update_Bolum + Staticvars.bolumid, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                    if (answer.Contains("Successfully!"))
                                    {
                                        MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                                        HasapPage.Get_All_Bolum(URLs.URL_Get_All_Bolum);

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
        async public static void Get_Byid_Bolum(int? bolumid)
        {

            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {
                        using (HttpResponseMessage response = await client.GetAsync(URLs.URL_Get_Byid_Bolum + bolumid))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Get_Bolum>(result);

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Static_Bolumady.Text = Root.name.ToString();
                                        Static_Bolumdolyady.Text = Root.fullName.ToString();
                                        Hukuk.Tag = Root.hukuk_id;
                                        Hukuk.Text = Root.hukuk_name;
                                        Code.Tag = Root.bolum_code_id;
                                        Code.Text = Root.bolum_code.ToString();
                                        Static_Bolumsene.Text = Root.opened_date;
                                        Static_Bolumbuyruk.Text = Root.created_date_of_buyruk;
                                        Static_Bolumyzygiderlik.Text = Root.yzygiderlik.ToString();

                                   

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

                                        BolumEdit.Hukuk.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            BolumEdit.Hukuk.Items.Add(new ComboBoxItem() { Content = item.Name.ToString(), Tag = item.Id });
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
        async public static void Get_BolumCode()
        {
            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {


                        using (HttpResponseMessage response = await client.GetAsync(URLs.URL_Get_BolumCode))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    var Root = JsonConvert.DeserializeObject<Models_Get_BolumCode>(result);


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {

                                        BolumEdit.Code.Items.Clear();
                                        foreach (var item in Root.data)
                                        {

                                            BolumEdit.Code.Items.Add(new ComboBoxItem() { Content = item.Code.ToString(), Tag = item.Id });
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
