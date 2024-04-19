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

namespace Neme.Pages
{
    /// <summary>
    /// Логика взаимодействия для Usanawy.xaml
    /// </summary>
    public partial class Usanawy : Page
    {

        public static DataGrid dataGrid_Users;
        public Usanawy()
        {
            InitializeComponent();
            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            dataGrid_Users = dataGrid_users;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Get_UsersList(URLs.URL_Get_All_User);
        }
        

        async public static void Get_UsersList(string url)
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
                                    Staticvars.static_Get_All_User = await content.ReadAsStringAsync();


                                    var Root = JsonConvert.DeserializeObject <Models_Get_All_User>(Staticvars.static_Get_All_User);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                        {
                                            dataGrid_Users.Items.Clear();

                                            int userid= 0;
                                            foreach (var item in Root.data)
                                            {
                                               
                                                
                                                userid++;
                                                dataGrid_Users.Items.Add(new UsersClass()
                                                { 
                                                    Id = userid.ToString(),
                                                    Uid=item.Id.ToString(),
                                                    Name_Surname = item.Name+" "+item.Surname,
                                                    Degishli_Mudirligi= item.mudirlikler_name,
                                                    Logini = item.Username,
                                                    Ulgamda = item.photo,
                                               
                                                    UserName=item.Name,
                                                    UserSurname=item.Surname,
                                                    UserLastName=item.Lastname,
                                                    UserUsername=item.Username,
                                                    UserMudirlikid=item.mudirlikler_id,
                                                    Usermudirliklername=item.mudirlikler_name,
                                                    UserBolumlerid=item.bolumid,
                                                    UserBolumlername=item.bolumlername,
                                                    UserBolumchelerid=item.bolumcheler_id,
                                                    UserBolumchelername=item.bolumcheler_name,
                                                    UserToparid=item.toparlar_id,
                                                    UserToparlarname=item.toparlar_name,
                                                    UserWezipelerid=item.wezipeler_id,
                                                    UserWezipelername=item.wezipeler_name,
                                                    UserPhoto=item.photo,
                                                    UserCreatedDate=item.created_date,
                                                    
                                                    
                                                });                                               
                                               
                                            }                                            
                                        });                               

                                }
                            }
                            else
                            {
                                MessageBox.Show("Статусный код ошибки (Get_All_User): " + (int)response.StatusCode + " - " + response.StatusCode);
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
            Get_UsersList(URLs.URL_Get_All_User);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            UsersClass my_items = new UsersClass();
            if (dataGrid_users.SelectedItems.Count > 0)
            {
                foreach (var obj in dataGrid_users.SelectedItems)
                {
                    my_items = obj as UsersClass;
                }

                Staticvars.Userid = my_items.Uid.ToString();

            }


            NavigationService.Navigate(new Uri("Pages/Parolu.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
