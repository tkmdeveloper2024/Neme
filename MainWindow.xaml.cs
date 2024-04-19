using Neme.Classes;
using Neme.Pages;
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
using System.Windows.Threading;
using static Neme.Classes.Staticvars;

namespace Neme
{
   
    public partial class MainWindow : Window
    {
        static Task Task1;

        public static Image image;
        public MainWindow()
        {
            InitializeComponent();
     
            Umumym umumymaglumat = new Umumym();
            Main.Content = umumymaglumat;
        /*    ViewModel viewModel = new ViewModel();
            DataContext = viewModel;

            viewModel.LoadImageAsync(URLs.URL_Get_Byiduser);*/
            image = Surat;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            Task task1 = Task.Run(() => Get_Byiduser(URLs.URL_Get_Byiduser));


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

                                        BitmapImage bitmap = new BitmapImage(new Uri(Staticvars.server_ip + Root.photo));
                                       
                                        image.Source = bitmap;



                         

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



        private void Leftcornerbtn_Click(object sender, RoutedEventArgs e)
        {

        }
     
        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
           
        }
    


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {     
         
         //   Tazeisgarg tazeisgar = new Tazeisgarg();
         //   Main.Content = tazeisgar;         
      
        }

        private void Stackparol_MouseUp(object sender, MouseButtonEventArgs e)
        {
                 
            Parolu parolu = new Parolu();
            Main.Content = parolu;
          

        }

        private void Stackusanawy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Usanawy usanawy = new Usanawy();
            Main.Content = usanawy; 
           
          
        }

        private void Stackwezipeler_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wezipeler wezipeler = new Wezipeler();
            Main.Content = wezipeler;

        }

        private void Wezipeg_MouseUp(object sender, MouseButtonEventArgs e)
        {
                 Page1 pg1 = new Page1();
                Main.Content = pg1;
        }

        private void Stackgosundylar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Gosundylar gosundylar = new Gosundylar();
            Main.Content = gosundylar;
        }

        private void Stacktazeg_MouseUp(object sender, MouseButtonEventArgs e)
        {          
            Gosundy gosundy = new Gosundy();
            Main.Content = gosundy;
           

        }

        private void Stackumumy_MouseUp(object sender, MouseButtonEventArgs e)
        {
          
            Umumym umumymaglumat = new Umumym();
            Main.Content = umumymaglumat;
        }

    

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
           
        }

        private void StackAdmin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackMenu.Visibility = Visibility.Collapsed;
            StackAdmin.Visibility = Visibility.Collapsed;

            StackMenuUser.Visibility = Visibility.Visible;
            StackMenu2.Visibility = Visibility.Visible;

        }

        private void StackMenuUser_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackAdmin.Visibility = Visibility.Visible;
            StackMenu.Visibility = Visibility.Visible;

           
            StackMenu2.Visibility = Visibility.Collapsed;
            StackMenuUser.Visibility = Visibility.Collapsed;
        }

        private void Stackumumyadmin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AdminUmumy au = new  AdminUmumy();
            Main.Content = au;
        }

        private void Stacktazeigosmak_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TazeUser tazeuser = new TazeUser();
            Main.Content = tazeuser;
        }

        private void Expander1_Expanded(object sender, RoutedEventArgs e)
        {
            Expander2.IsExpanded = false;
            Expander3.IsExpanded = false;
        }

        private void Expander2_Expanded(object sender, RoutedEventArgs e)
        {
            Expander1.IsExpanded = false;
            Expander3.IsExpanded = false;
        }
        private void Expander3_Expanded(object sender, RoutedEventArgs e)
        {
            Expander1.IsExpanded = false;
            Expander2.IsExpanded = false;

        }      

        private void Stackstatwezipelergozkezmek_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StatSanawy statSanawy = new StatSanawy();
            Main.Content = statSanawy;
        }

        private void Stackstatgosmak_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HasapPage hasapPage = new HasapPage();
            Main.Content = hasapPage;
        }

      
    }
}
