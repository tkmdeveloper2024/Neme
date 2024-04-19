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
    /// Логика взаимодействия для Parolu.xaml
    /// </summary>
    public partial class Parolu : Page
    {
        public static TextBox mudurlik;
        public static TextBox name;
        public static TextBox surname;
        public static TextBox username;
        public static TextBox ministirlik;
        public static TextBox bolum;
        public static TextBox bolumce;
        public static TextBox topar;
        public static TextBox wezipe;
        public static Image image;
        static string password;
        string selectedImagePath;
        private bool error1, error2, error3, error4;

        public Parolu()
        {
            InitializeComponent();


         /*   ViewModel viewModel = new ViewModel();
            DataContext = viewModel;

            viewModel.LoadImageAsync(URLs.URL_Get_Byiduser);

            */

            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            mudurlik = User_mudurliktxt;
            bolum = User_Bolumtxt;
            bolumce = User_Bolumcetxt;
            topar = User_Topartxt;
            wezipe = User_Wezipetxt;
            name = User_Nametxt;
            surname = User_Surnametxt;
            username = User_usernametxt;
            image = Surat;
           
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Task task1 = Task.Run(() => Get_Byiduser(URLs.URL_Get_Byiduser));

            await Task.WhenAll(task1);

            Application.Current.Dispatcher.Invoke(() =>
            {
                SuratEllipse.Visibility = Visibility.Visible;
                Ellipse.Visibility = Visibility.Collapsed;
                PhotoIcon.Visibility = Visibility.Collapsed;
                Ellipse2.Visibility = Visibility.Collapsed;
            });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(User_mudurliktxt.Text)) { error1 = false; }
            else { error1 = true; }

            if (!string.IsNullOrEmpty(User_Nametxt.Text)) { error2 = false; }
            else { error2 = true; }
          

            if (!string.IsNullOrEmpty(User_Surnametxt.Text)) { error3 = false; }
            else { error3 = true; }

            if (!string.IsNullOrEmpty(User_usernametxt.Text)) { error4 = false; }
            else { error4 = true; }          


            if (error1 == false && error2 == false && error3 == false && error4 == false)
            {
               
                Update_UserReq(User_Nametxt.Text, User_Surnametxt.Text, User_usernametxt.Text,selectedImagePath);

           

            }
            else { MessageBox.Show("Ähli maglumatlary giriziň!"); }

        }
        async public static void Update_UserReq(string name, string surname, string username, string avatar)
        {
            FileInfo fileInfo = new FileInfo(avatar);

            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(surname), "surname");
                form.Add(new StringContent(username), "username");
          
                //Add the file
                var fileStreamContent = new StreamContent(File.OpenRead(avatar));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                form.Add(fileStreamContent, name: "photo", fileName: fileInfo.Name);
                
                if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                        try
                        {
                            try
                            {
                                using (HttpResponseMessage response = await client.PutAsync(URLs.URL_Update_User + Staticvars.Userid, form))
                                {
                                    if (response.StatusCode == HttpStatusCode.Created)
                                    {
                                        using (HttpContent content = response.Content)
                                        {
                                            string answer = await content.ReadAsStringAsync();

                                            MessageBox.Show(response.ReasonPhrase.ToString());
                                      /*      if (answer.Contains("\"answer\":\"updated\""))
                                            {
                                                Usanawy.Get_UsersList(URLs.URL_Get_All_User);
                                                //MessageBox.Show("Täze sorag goşuldy!: \n" + answer, "Goşuldy", MessageBoxButton.OK, MessageBoxImage.Information);
                                            }
                                            else if (answer.Contains("\"custom user with this Login already exists.\""))
                                            {
                                                MessageBox.Show("Bular ýaly ulanyjy ulgamda bar, başga ulanyjy adyny ulanyň!\n" + answer, "Ulanyjy döredilmedi", MessageBoxButton.OK, MessageBoxImage.Information);
                                               
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ýalňyşlyk: \n" + answer);
                                   
                                            } */
                                        }
                                    }
                                    else if (response.StatusCode == HttpStatusCode.Forbidden)
                                    {
                                        HttpContent content = response.Content;
                                        MessageBox.Show("Rugsat ýok: " + await content.ReadAsStringAsync());
                                     
                                    }
                                    else
                                    {
                                        HttpContent content = response.Content;
                                        MessageBox.Show("Ýalňyşlyk: " + await content.ReadAsStringAsync());
                                       
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Form error: " + ex);
 
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

        async public static void Update_passwordforuser(string password)
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
                            using (HttpResponseMessage response = await client.PostAsync(URLs.URL_Update_passwordforuser, form))
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string answer = await content.ReadAsStringAsync();

                                   
                                    if (answer.Contains("Successfully"))
                                    {
                                        MessageBox.Show("Üstünlikli üýtgedildi!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                        
                                    }
                                    else {
                                       
                                        MessageBox.Show(answer); }
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
            NavigationService.Navigate(new Uri("Pages/Usanawy.xaml", UriKind.Relative));

        }

        async public static void Get_Byiduser(string url)
        {
            if (!string.IsNullOrWhiteSpace(Staticvars.access_token))
            {
               
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Staticvars.access_token);
                    try
                    {
                        using (HttpResponseMessage response = await client.GetAsync(url+Staticvars.Userid))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                using (HttpContent content = response.Content)
                                {
                                    Staticvars.static_Get_Userbyid = await content.ReadAsStringAsync();
                                

                                    var Root = JsonConvert.DeserializeObject <Get_All_User> (Staticvars.static_Get_Userbyid);

                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {

                                        BitmapImage bitmap = new BitmapImage(new Uri(Staticvars.server_ip+Root.photo));
                                       
                                         image.Source = bitmap;
                                  
                                
                                        
                                        mudurlik.Text = Root.mudirlikler_name;
                                        bolum.Text = Root.bolumlername;
                                        bolumce.Text = Root.bolumcheler_name;
                                        topar.Text = Root.toparlar_name;
                                        wezipe.Text = Root.wezipeler_name;
                                        name.Text = Root.Name;
                                        surname.Text = Root.Surname;
                                        username.Text = Root.Username;                         

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

        private void Save2_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Passwordtxt.Text))
            {
                if (!string.IsNullOrEmpty(Passwordtxt2.Text))
                {
                    if (Passwordtxt.Text == Passwordtxt2.Text)
                    {

                        Update_passwordforuser(Passwordtxt.Text);

                        Passwordtxt.Clear();
                        Passwordtxt2.Clear();

                        NavigationService.Navigate(new Uri("Pages/Usanawy.xaml", UriKind.Relative));
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
    }
}
