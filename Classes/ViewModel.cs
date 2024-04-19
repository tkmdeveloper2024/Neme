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
using System.Windows.Media.Imaging;

namespace Neme.Classes
{
  public class ViewModel
    {

     
            public BitmapImage ImageSource { get; set; }

            public async Task LoadImageAsync(string url)
            {
                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.GetAsync(url + Staticvars.user_id))
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    using (HttpContent content = response.Content)
                                    {
                                        Staticvars.static_Get_Userbyid = await content.ReadAsStringAsync();

                                        var Root = JsonConvert.DeserializeObject<Get_All_User>(Staticvars.static_Get_Userbyid);

                                        App.Current.Dispatcher.Invoke((Action)delegate
                                        {
                                            ImageSource = new BitmapImage(new Uri(Staticvars.server_ip + Root.photo));
                                        });
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Статусный код ошибки (Get_By_iduser): " + (int)response.StatusCode + " - " + response.StatusCode);
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
