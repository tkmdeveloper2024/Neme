using Microsoft.Win32;
using Neme.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для TazeUser.xaml
    /// </summary>
    public partial class TazeUser : Page
    {
        public static DataGrid dataGrid_Users;
        public static ComboBox Static_MudirlikList;
        public static ComboBox Static_BolumList;
        public static ComboBox Static_BolumceList;
        public static ComboBox Static_ToparList;
        public static ComboBox Static_WeziplerList;
        private bool error1, error2, error3, error4;
        string selectedImagePath;
        int mudirlik=0,bolum=0,bolumce=0,topar=0,wezipe=0;
        public TazeUser()
        {
            InitializeComponent();
            dataGrid_Users = dataGrid_users;
            Static_MudirlikList = MudirlikList;
            Static_BolumList = BolumList;
            Static_BolumceList = BolumceList;
            Static_ToparList = ToparList;
            Static_WeziplerList = WezipeList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Get_UsersList(URLs.URL_Get_All_User);
            try
            {
                Get_All_Mudirlik(URLs.URL_Get_All_Mudirlik);
            }
            catch (Exception ex)
            { }
          
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


                                    var Root = JsonConvert.DeserializeObject<Models_Get_All_User>(Staticvars.static_Get_All_User);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        dataGrid_Users.Items.Clear();

                                        int userid = 0;
                                        foreach (var item in Root.data)
                                        {


                                            userid++;
                                            dataGrid_Users.Items.Add(new UsersClass()
                                            {
                                                Id = userid.ToString(),
                                                Uid = item.Id.ToString(),
                                                Name_Surname = item.Name + " " + item.Surname,
                                                Degishli_Mudirligi = item.mudirlikler_name,
                                                Logini = item.Username,
                                                Ulgamda = item.photo,

                                                UserName = item.Name,
                                                UserSurname = item.Surname,
                                                UserLastName = item.Lastname,
                                                UserUsername = item.Username,
                                                UserMudirlikid = item.mudirlikler_id,
                                                Usermudirliklername = item.mudirlikler_name,
                                                UserBolumlerid = item.bolumid,
                                                UserBolumlername = item.bolumlername,
                                                UserBolumchelerid = item.bolumcheler_id,
                                                UserBolumchelername = item.bolumcheler_name,
                                                UserToparid = item.toparlar_id,
                                                UserToparlarname = item.toparlar_name,
                                                UserWezipelerid = item.wezipeler_id,
                                                UserWezipelername = item.wezipeler_name,
                                                UserPhoto = item.photo,
                                                UserCreatedDate = item.created_date,


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
        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenSurat_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == true)
            {

                selectedImagePath = openFileDialog.FileName;
                Uri imageUri = new Uri(selectedImagePath);
                Surat.Source = new System.Windows.Media.Imaging.BitmapImage(imageUri);

                SuratEllipse.Visibility = Visibility.Visible;
                Ellipse.Visibility = Visibility.Collapsed;
                PhotoIcon.Visibility = Visibility.Collapsed;
                Ellipse2.Visibility = Visibility.Collapsed;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MudirlikList.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(User_Nametxt.Text)) { error2 = false; }
            else { error2 = true; }


            if (!string.IsNullOrEmpty(User_Surnametxt.Text)) { error3 = false; }
            else { error3 = true; }

            if (!string.IsNullOrEmpty(User_usernametxt.Text)) { error4 = false; }
            else { error4 = true; }


            if (error1 == false && error2 == false && error3 == false && error4 == false)
            {
              
                    mudirlik = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);

                if (BolumList.SelectedIndex!=-1)
                {

                    bolum = Convert.ToInt32(((ComboBoxItem)this.BolumList.SelectedItem).Tag);
                }
                if (BolumceList.SelectedIndex != -1)
                {

                    bolumce = Convert.ToInt32(((ComboBoxItem)this.BolumceList.SelectedItem).Tag);
                }
                if (ToparList.SelectedIndex != -1)
                {
                    topar = Convert.ToInt32(((ComboBoxItem)this.ToparList.SelectedItem).Tag);
                }
                if (WezipeList.SelectedIndex != -1)
                {
                    wezipe = Convert.ToInt32(((ComboBoxItem)this.WezipeList.SelectedItem).Tag);
                }

                try
                {
                    AddUser(mudirlik, bolum, bolumce, topar, wezipe, User_Nametxt.Text, User_Surnametxt.Text, User_usernametxt.Text, selectedImagePath);



                    User_Nametxt.Clear();
                    User_Surnametxt.Clear();
                    User_usernametxt.Clear();

                }
                catch (Exception)
                {

                    MessageBox.Show("Ähli boşluklary dolduryň!!!");
                }
                
                


            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }

        }


        async public static void AddUser(int mudirlikid, int bolumid, int bolumceid, int toparid, int wezipeid, string name, string surname, string username, string avatar)
        {

            try
            {

          
            FileInfo fileInfo = new FileInfo(avatar);

            using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(name), "name");
                    form.Add(new StringContent(surname), "surname");
                    form.Add(new StringContent(username), "username");

                    form.Add(new StringContent(mudirlikid.ToString()), "mudirlik");
                form.Add(new StringContent(bolumid.ToString()), "bolum");
                form.Add(new StringContent(bolumceid.ToString()), "bolumche");
                form.Add(new StringContent(toparid.ToString()), "topar");
                form.Add(new StringContent(wezipeid.ToString()), "wezipe");
           
                //Add the file
                var fileStreamContent = new StreamContent(File.OpenRead(avatar));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                form.Add(fileStreamContent, name: "image", fileName: fileInfo.Name);

                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Add_New_User, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                        if (answer.Contains("Successfully!"))
                                        {
                                            MessageBox.Show("Üstünlikli goşuldy");

                                            Get_UsersList(URLs.URL_Get_All_User);


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
            catch (Exception ex)
            {

                MessageBox.Show("Surat saýlaň ýa-da ähli boşluklary dolduryň!");
            }
        }

        private void Save2_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Passwordtxt.Text))
            {
                if (!string.IsNullOrEmpty(Passwordtxt2.Text))
                {
                    if (Passwordtxt.Text == Passwordtxt2.Text)
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
                            Update_passwordforuser(Passwordtxt.Text);

                        Passwordtxt.Clear();
                        Passwordtxt2.Clear();

                        
                    }


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
        async public static void Update_passwordforuser(string password)
        {
            try
            {

          
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(password), "password");


                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Update_passwordforuser+Staticvars.Userid, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();


                                    if (answer.Contains("Successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    else
                                    {

                                        MessageBox.Show(answer);
                                    }
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
            catch (Exception ex)
            {
                MessageBox.Show("Bir ulanyjyny saýlaň we täzeden synanşyp görüň!");
            }
        }
        private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Get_UsersList(URLs.URL_Get_All_User);
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        async public static void Get_All_Mudirlik(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Mudirlik>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        TazeUser.Static_MudirlikList.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            TazeUser.Static_MudirlikList.Items.Add(new ComboBoxItem { Content = item.name, Tag = item.id });

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
        async public static void Get_All_Bolum(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Bolum>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        TazeUser.Static_BolumList.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            TazeUser.Static_BolumList.Items.Add(new ComboBoxItem { Content = item.name, Tag = item.id });
                                        
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
        async public static void Get_All_Bolumce(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Bolumce>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        TazeUser.Static_BolumceList.Items.Clear();

                                       
                                            foreach (var item in Root.data)
                                            {
                                                TazeUser.Static_BolumceList.Items.Add(new ComboBoxItem { Content = item.name, Tag = item.id });
                                           
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
        async public static void Get_All_Topar(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Topar>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        TazeUser.Static_ToparList.Items.Clear();

                                     
                                            foreach (var item in Root.data)
                                            {
                                                TazeUser.Static_ToparList.Items.Add(new ComboBoxItem { Content = item.name, Tag = item.id });

                                            }
                                        



                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok :" + await content.ReadAsStringAsync());
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
        async public static void Get_All_Wezipeler(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Wezipeler>(result);
                                    Staticvars.current = Root.currentPage;
                                    Staticvars.last = Root.lastPage;
                                    Staticvars.total = Root.total;


                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        TazeUser.Static_WeziplerList.Items.Clear();

                                        if (Root.data == null || !Root.data.Any())
                                        {
                                            Static_WeziplerList.ItemsSource = null; // Set the ListView's ItemsSource to null to display nothing
                                        }
                                        else
                                        {
                                            foreach (var item in Root.data)
                                            {
                                                TazeUser.Static_WeziplerList.Items.Add(new ComboBoxItem { Content = item.full_name, Tag = item.id });

                                            }
                                        }



                                    });
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Forbidden)
                            {
                                HttpContent content = response.Content;
                                MessageBox.Show("Rugsat ýok :" + await content.ReadAsStringAsync());
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

        private void MudirlikList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                if (Staticvars.mudirlikid != null)
                {
                    Get_All_Bolum(URLs.URL_Get_All_Bolum + "?sort=asc&hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolumcode=&search=&limit=100&page=");
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            }
            catch (Exception ex)
            { }

        }

        private void BolumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                Staticvars.bolumid = Convert.ToInt32(((ComboBoxItem)this.BolumList.SelectedItem).Tag);

                if (Staticvars.mudirlikid != null && Staticvars.bolumid!=null)
                {       

                    Get_All_Bolumce(URLs.URL_Get_All_Bolumce + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&search=&sort=desc&limit=100&page=");
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
                else
                {
                    BolumceList.Items.Clear();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void BolumceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                Staticvars.bolumid = Convert.ToInt32(((ComboBoxItem)this.BolumList.SelectedItem).Tag);
                Staticvars.bolumceid = Convert.ToInt32(((ComboBoxItem)this.BolumceList.SelectedItem).Tag);

                if (Staticvars.mudirlikid != null && Staticvars.bolumid!=null && Staticvars.bolumceid!=null)
                {
                   

                    Get_All_Topar(URLs.URL_Get_All_Topar + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&search=&sort=&limit=100&page=");
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
                else
                {
                    ToparList.Items.Clear();
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void ToparList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ComboBoxItem)this.MudirlikList.SelectedItem).Tag);
                Staticvars.bolumid = Convert.ToInt32(((ComboBoxItem)this.BolumList.SelectedItem).Tag);
                Staticvars.bolumceid = Convert.ToInt32(((ComboBoxItem)this.BolumceList.SelectedItem).Tag);
                Staticvars.toparid = Convert.ToInt32(((ComboBoxItem)this.ToparList.SelectedItem).Tag);

                if (Staticvars.mudirlikid != null && BolumList.Items.Count > 0 && BolumceList.Items.Count > 0 && ToparList.Items.Count > 0)
                {
                   

                  
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&topar=" + Staticvars.toparid + "&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
                else
                {
                    WezipeList.Items.Clear();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
