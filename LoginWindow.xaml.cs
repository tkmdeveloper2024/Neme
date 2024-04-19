using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Neme.Classes;

namespace Neme
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        bool isopened;
        string usernametxt,passwordtxt;

        public LoginWindow()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
        }
       

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
           usernametxt=Usernametxt.Text.Trim();
           passwordtxt=Passwordtxt.Password.Trim();


            if (!string.IsNullOrEmpty(Usernametxt.Text))
            {
                if (!string.IsNullOrEmpty(Passwordtxt.Password))
                {
                    PostToken(usernametxt,passwordtxt).ConfigureAwait(true);

                }
                else
                {
                    MessageBox.Show("Ulanyjy adyňyz ýa-da açar sözüňiz ýalňyş!");
                }
            }
            else
            {
                MessageBox.Show("Ulanyjy adyňyz ýa-da açar sözüňiz ýalňyş!");
            }

        }

        private void Usernametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                usernametxt = Usernametxt.Text.Trim();
                passwordtxt = Passwordtxt.Password.Trim();


                if (!string.IsNullOrEmpty(Usernametxt.Text))
                {
                    if (!string.IsNullOrEmpty(Passwordtxt.Password))
                    {
                        PostToken(usernametxt, passwordtxt).ConfigureAwait(true);

                    }
                    else
                    {
                        MessageBox.Show("Ulanyjy adyňyz ýa-da açar sözüňiz ýalňyş!");
                    }
                }
                else
                {
                    MessageBox.Show("Ulanyjy adyňyz ýa-da açar sözüňiz ýalňyş!");
                }
            }  
        }

        

        private async Task PostToken(string username,string password)
        {
            using (var form = new MultipartFormDataContent())
            {
                
                form.Add(new StringContent(username), "username");
                form.Add(new StringContent(password), "password");
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Login, form))
                        {

                            if (response.StatusCode == HttpStatusCode.OK)
                            {

                                using (HttpContent content = response.Content)
                                {
                                    string http_response = await content.ReadAsStringAsync();
                                    Model_Login login_model = JsonConvert.DeserializeObject<Model_Login>(http_response);

                                    Staticvars.access_token = login_model.access_token;
                                    Staticvars.refresh_token = login_model.refresh_token;
                                    Staticvars.status = login_model.status;
                                    Staticvars.user_id = login_model.user_id;
                                    //Usernametxt.Text = login_model.access_token;

                                    if (!string.IsNullOrEmpty(Staticvars.access_token))
                                    {

                                        if (isopened == false)
                                        {
                                            MainWindow mw = new MainWindow();
                                            mw.Show(); isopened = true;
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Tor ulgamyňyzda ýa-da serwerde näsazlyk bar", "Serwere baglanmady!", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                MessageBox.Show("Ulanyjy maglumatlaryňyzy dogry giriziň!", "Ulanyjy tapylmady", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                            else
                            {
                                MessageBox.Show("Ulanyjy maglumatlaryňyzy dogry giriziň!", "Ulanyjy tapylmady", MessageBoxButton.OK, MessageBoxImage.Stop);
                             //  

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

        }
    }
}
