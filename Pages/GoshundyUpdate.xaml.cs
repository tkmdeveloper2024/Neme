using Neme.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            Gosundynumber.Text = Staticvars.Number;
            Gosundysubject.Text = Staticvars.Subject;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Gosundynumber.Text))
            {
                if (!string.IsNullOrEmpty(Gosundysubject.Text))
                {

                    Update_Goshundy(Staticvars.Uid, Gosundynumber.Text, Gosundysubject.Text);


                    Gosundynumber.Clear();
                    Gosundysubject.Clear();

                    NavigationService.Navigate(new Uri("Pages/Gosundylar.xaml", UriKind.Relative));
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

        async public static void Update_Goshundy(int? goshundyid,string number,string subject)
        {
            using (var form = new MultipartFormDataContent())
            {
               
                form.Add(new StringContent(number), "name");
                form.Add(new StringContent(subject), "text");

                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PutAsync(URLs.URL_Update_WezipeGosundy + goshundyid, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                    if (answer.Contains("Successfully!"))
                                    {
                                        MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                        Gosundylar.Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy);
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

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Gosundylar.xaml", UriKind.Relative));

        }
    }
}
