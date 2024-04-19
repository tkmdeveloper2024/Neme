using Neme.Classes;
using Neme.Windows;
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
    /// Логика взаимодействия для HasapPage.xaml
    /// </summary>
    public partial class HasapPage : Page
    {
        public static ListView Static_MudirlikList;
        public static ListView Static_BolumList;
        public static ListView Static_BolumceList;
        public static ListView Static_ToparList;
        public static ListView Static_WeziplerList;

        public HasapPage()
        {
            InitializeComponent();

            Static_MudirlikList = MudirlikList;
            Static_BolumList = BolumList;
            Static_BolumceList = BolumceList;
            Static_ToparList = ToparList;
            Static_WeziplerList = WezipeList;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Get_All_Mudirlik(URLs.URL_Get_All_Mudirlik);
            }catch (Exception ex)
            { }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BirlikAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BirlikRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MudirlikRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MudirlikAddbtn_Click(object sender, RoutedEventArgs e)
        {
            try { 
            MudirlikAddWindow MAW = new MudirlikAddWindow();
            Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
            MAW.Owner = parentWindow;
            MAW.ShowDialog();
            }catch (Exception ex)
            { }


}


        private void BolumRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BolumAddbtn_Click(object sender, RoutedEventArgs e)
        {
           try{
                if (MudirlikList.SelectedIndex != -1)
                 {
                Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
                BolumAddWindow Bolumaw = new BolumAddWindow();
                Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                Bolumaw.Owner = parentWindow;
                Bolumaw.ShowDialog();
                 }
                     else { MessageBox.Show("Müdirlik saýlaň!"); }

            } catch (Exception ex)
            { }
}

        private void BolumceRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BolumceAdd_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (MudirlikList.SelectedIndex != -1)
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
                    if (BolumList.SelectedIndex!=-1)
                    {
                        Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                    }
                BolumceAddWindow Bolumceaw = new BolumceAddWindow();
                Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                Bolumceaw.Owner = parentWindow;
                Bolumceaw.ShowDialog();
            }
            else { MessageBox.Show("Bölüm saýlaň!"); }
            }
            catch (Exception ex)
            { }
        }

        private void ToparRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToparAddbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BolumceList.SelectedIndex != -1)
                {
                    Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
                    if (BolumList.SelectedIndex != -1)
                    {
                        Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                    }
                    Staticvars.bolumceid = Convert.ToInt32(((ListViewItem)this.BolumceList.SelectedItem).Tag);
                    ToparAddWindow TAW = new ToparAddWindow();
                    Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                    TAW.Owner = parentWindow;
                    TAW.ShowDialog();
                }
                else { MessageBox.Show("Bölüm saýlaň!"); }
            }
              catch (Exception ex)
            { }
}

        private void WezipelerRemovebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WezipelerAddbtn_Click(object sender, RoutedEventArgs e)
        { 
          try{  if (MudirlikList.SelectedIndex != -1)
            {
                Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
            }
                if (BolumList.SelectedIndex != -1)
                {
                    Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                }
                else Staticvars.bolumid = 0;
            if (BolumceList.SelectedIndex != -1)
            {
                Staticvars.bolumceid = Convert.ToInt32(((ListViewItem)this.BolumceList.SelectedItem).Tag);
            }
                else Staticvars.bolumceid = 0;
            if (ToparList.SelectedIndex != -1)
            {
                Staticvars.toparid = Convert.ToInt32(((ListViewItem)this.ToparList.SelectedItem).Tag);
            }
                else Staticvars.toparid = 0;


                if (MudirlikList.SelectedIndex != -1)
            {
                try
                {
                    WezipelerAddWindow WAW = new WezipelerAddWindow();
                    Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                    WAW.Owner = parentWindow;
                    WAW.ShowDialog();
                } catch(Exception ex)
                {

                }
            }
            }catch (Exception ex)
            { }
}

        private void Save2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MudirlikList.SelectedIndex != -1)
                {
                    Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
                    MudirlikEdit me = new MudirlikEdit();
                    Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                    me.Owner = parentWindow;
                    me.ShowDialog();

                }
            
            }catch (Exception ex)
            { }
}

        private void Save3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BolumList.SelectedIndex != -1)
                {
                    Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                    BolumEdit me = new BolumEdit();
                    Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                    me.Owner = parentWindow;
                    me.ShowDialog();

                }
            }
            catch (Exception ex)
            { }
}
        private void Save4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BolumceList.SelectedIndex != -1)
                {
                    Staticvars.bolumceid = Convert.ToInt32(((ListViewItem)this.BolumceList.SelectedItem).Tag);
                    BolumceEdit Bolumce = new BolumceEdit();
                    Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                    Bolumce.Owner = parentWindow;
                    Bolumce.ShowDialog();

                }
            }
            catch (Exception ex)
            { }
}
        private void Save5_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (ToparList.SelectedIndex != -1)
            {
                Staticvars.toparid = Convert.ToInt32(((ListViewItem)this.ToparList.SelectedItem).Tag);
                ToparEdit Topare = new ToparEdit();
                Window parentWindow = Window.GetWindow(this); // 'this' refers to the current page
                Topare.Owner = parentWindow;
                Topare.ShowDialog();

            }
                }catch (Exception ex)
            { }
}
        private void Save6_Click(object sender, RoutedEventArgs e)
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
                                        HasapPage.Static_MudirlikList.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            HasapPage.Static_MudirlikList.Items.Add(new ListViewItem { Content = item.name, Tag = item.id });

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
                                        HasapPage.Static_BolumList.Items.Clear();

                                        foreach (var item in Root.data)
                                        {
                                            HasapPage.Static_BolumList.Items.Add(new ListViewItem { Content = item.name, Tag = item.id });

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
                                        HasapPage.Static_BolumceList.Items.Clear();

                                        if (Root.data == null || !Root.data.Any())
                                        {
                                            Static_BolumceList.ItemsSource = null; // Set the ListView's ItemsSource to null to display nothing
                                        }
                                        else
                                        {
                                            foreach (var item in Root.data)
                                            {
                                                HasapPage.Static_BolumceList.Items.Add(new ListViewItem { Content = item.name, Tag = item.id });

                                            }
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
                                        HasapPage.Static_ToparList.Items.Clear();

                                        if (Root.data == null || !Root.data.Any())
                                        {
                                            Static_ToparList.ItemsSource = null; // Set the ListView's ItemsSource to null to display nothing
                                        }
                                        else
                                        {
                                            foreach (var item in Root.data)
                                            {
                                                HasapPage.Static_ToparList.Items.Add(new ListViewItem { Content = item.name, Tag = item.id });

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
                                        HasapPage.Static_WeziplerList.Items.Clear();

                                        if (Root.data == null || !Root.data.Any())
                                        {
                                            Static_WeziplerList.ItemsSource = null; // Set the ListView's ItemsSource to null to display nothing
                                        }
                                        else
                                        {
                                            foreach (var item in Root.data)
                                            {
                                                HasapPage.Static_WeziplerList.Items.Add(new ListViewItem { Content = item.full_name, Tag = item.id });

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
            try { 
                Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);
            if (Staticvars.mudirlikid != null)
                {
                Get_All_Bolum(URLs.URL_Get_All_Bolum + "?sort=asc&hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolumcode=&search=&limit=10&page=");
                Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
                }catch (Exception ex)
            { }
}

        private void BolumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
                Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);

            if (Staticvars.mudirlikid != null && BolumList.Items.Count > 0)
            {
                Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
               
                Get_All_Bolumce(URLs.URL_Get_All_Bolumce + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&search=&sort=desc&limit=10&page=");
                Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            else
            {
                BolumceList.Items.Clear();
            }
        }catch (Exception ex)
            { }
}

        private void BolumceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);

            if (Staticvars.mudirlikid != null && BolumList.Items.Count > 0 && BolumceList.Items.Count>0)
            {
                Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                Staticvars.bolumceid = Convert.ToInt32(((ListViewItem)this.BolumceList.SelectedItem).Tag);
         
                Get_All_Topar(URLs.URL_Get_All_Topar + "?hukuk=&mudirlik="+Staticvars.mudirlikid+"&bolum="+Staticvars.bolumid+"&bolumche="+Staticvars.bolumceid+"&search=&sort=&limit=10&page=");
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&topar=&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            else
            {
                ToparList.Items.Clear();
            }


        }catch (Exception ex)
            { }
}

        private void ToparList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            Staticvars.mudirlikid = Convert.ToInt32(((ListViewItem)this.MudirlikList.SelectedItem).Tag);

            if (Staticvars.mudirlikid != null && BolumList.Items.Count > 0 && BolumceList.Items.Count > 0 && ToparList.Items.Count > 0)
            {
                Staticvars.bolumid = Convert.ToInt32(((ListViewItem)this.BolumList.SelectedItem).Tag);
                Staticvars.bolumceid = Convert.ToInt32(((ListViewItem)this.BolumceList.SelectedItem).Tag);
                Staticvars.toparid= Convert.ToInt32(((ListViewItem)this.ToparList.SelectedItem).Tag);

                Get_All_Topar(URLs.URL_Get_All_Topar + "?hukuk=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&search=&sort=&limit=10&page=");
                    Get_All_Wezipeler(URLs.URL_Get_All_Wezipeler + "?search=&mudirlik=" + Staticvars.mudirlikid + "&bolum=" + Staticvars.bolumid + "&bolumche=" + Staticvars.bolumceid + "&topar=" + Staticvars.toparid + "&goshundy=&wezipe=&cheshme=&gornush=&zvanye=&zvanye_gornush=&sort=&limit=&page=");
                }
            else
            {
                WezipeList.Items.Clear();
            }
        }catch (Exception ex)
            { }
}

        private void WezipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      
    }
}
