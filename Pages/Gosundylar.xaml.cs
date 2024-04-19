using Neme.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Gosundylar.xaml
    /// </summary>
    public partial class Gosundylar : Page
    {
        public static DataGrid dataGrid_Gosundylar;
        public static Label Counterlbl;
       public static int id = 0;
        public static List<WezipeGornush> Wezipegornushlist = new List<WezipeGornush>();

        public Gosundylar()
        {
            InitializeComponent();

            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            dataGrid_Gosundylar = dataGrid_gosundylar;
            Counterlbl = Counter;
           
     

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            id = 0;
            Task task1 = Task.Run(() => Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=10&page=1"));

            await Task.WhenAll(task1);
           

        }
        async public static void Get_All_WezipeGosundy(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Gosundy>(result);
                                 


                                   
                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        Staticvars.current = Root.currentPage;
                                        Staticvars.last = Root.lastPage;
                                        Staticvars.total = Root.total;
                                        Gosundylar.dataGrid_Gosundylar.Items.Clear();
                                    
                                        foreach (var item in Root.data)
                                        {
                                            id++;

                                            Gosundylar.dataGrid_Gosundylar.Items.Add(new GosundyClass()
                                            {
                                                Gosundy_ID = id,
                                                Goshundy_UID = item.Id,
                                                Gosundy_Number = item.Name.ToString(),
                                                Gosundy_Subject = item.Text.ToString(),
                                            });
                                           
                                        }
                                        Gosundylar.Counterlbl.Content ="("+Root.total.ToString()+")";
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

        private async void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task task1 = Task.Run(() => GetItems());

            await Task.WhenAll(task1);


            NavigationService.Navigate(new Uri("Pages/2/WezipelerAll.xaml", UriKind.Relative));
        }

        private async Task GetItems()
        {

            Application.Current.Dispatcher.Invoke(() =>
            {

                GosundyClass selected_dg = new GosundyClass();
            if (dataGrid_gosundylar.SelectedItems.Count > 0)
            {
                foreach (var obj in dataGrid_gosundylar.SelectedItems)
                {
                    selected_dg = obj as GosundyClass;
                }

            }
            Staticvars.Uid = selected_dg.Goshundy_UID;
            Staticvars.Number = selected_dg.Gosundy_Number;
            Staticvars.Subject = selected_dg.Gosundy_Subject;
            });
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

        private void Expander_Filter_Expanded(object sender, RoutedEventArgs e)
        {

        }

        private void Expander_Filter_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private void FilterGo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=" + Searchtxt.Text + "&limit=10&page=");
        }

        private void PrevPagebtn_Click(object sender, RoutedEventArgs e)
        {
            int bir = Convert.ToInt32(Onluk10.Content);
            int iki = Convert.ToInt32(Onluk20.Content);
            int uc = Convert.ToInt32(Onluk30.Content);
            
            if (bir > 1)
            {
                bir = bir - 1;
                iki = iki - 1;
                uc = uc - 1;
                Onluk10.Content = bir.ToString();
                Onluk20.Content = iki.ToString();
                Onluk30.Content = uc.ToString();

            }

        }

        private void NextPagebtn_Click(object sender, RoutedEventArgs e)
        {
            
            int bir = Convert.ToInt32(Onluk10.Content);
            int iki = Convert.ToInt32(Onluk20.Content);
            int uc = Convert.ToInt32(Onluk30.Content);

            if (uc < Convert.ToInt32(Staticvars.last))
            {
                bir = iki;
                iki = uc;
                uc++;
                Onluk10.Content = bir.ToString();
                Onluk20.Content = iki.ToString();
                Onluk30.Content = uc.ToString();

            }
        }

        private void Onluk10_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Onluk10.Content) != 1)
            {
                id = 1;
                id = id * ((Convert.ToInt32(Onluk10.Content) - 1) * 10);
            }
            else
            {
                id = 0;
            }
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=10&page=" + Convert.ToInt32(Onluk10.Content) + "");

        }

        private void Onluk20_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Onluk20.Content) - 1) * 10);

            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=10&page=" + Convert.ToInt32(Onluk20.Content) + "");
        }

        private void Onluk30_Click(object sender, RoutedEventArgs e)
        {
            id = 1;
            id = id * ((Convert.ToInt32(Onluk30.Content) - 1) * 10);
            Get_All_WezipeGosundy(URLs.URL_All_WezipeGosundy + "?search=&limit=10&page=" + Convert.ToInt32(Onluk30.Content) + "");
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            Task task1 = Task.Run(() => GetItems());

            await Task.WhenAll(task1);


            NavigationService.Navigate(new Uri("Pages/GoshundyUpdate.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void View_Click(object sender, RoutedEventArgs e)
        {
            Task task1 = Task.Run(() => GetItems());

            await Task.WhenAll(task1);

            if (Staticvars.Uid != null)
            {
                id = 0;
                Get_All_Wezipe(URLs.URL_All_Wezipe + "?search=&goshundy=" + Staticvars.Uid + "&sort=desc&limit=100&page=");            }

        }

        private  void Print_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("control.exe", "/name Microsoft.DevicesAndPrinters");
        
        }
        async public static void Get_All_Wezipe(string url)
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
                                    var Root = JsonConvert.DeserializeObject<Models_Get_Wezipe>(result);

                                    Wezipegornushlist.Clear();

                                    foreach (var item in Root.data)
                                    {
                                        if (Root.data != null)
                                        {

                                            Wezipegornushlist.Add(new WezipeGornush()
                                            {
                                                Id = item.id,
                                                Name = item.name,
                                                Wezipegornushid = item.wezipe_gornush_id,
                                                Wezipegornushtype = item.wezipe_gornush_type,
                                                Wezipegoshundylarid = item.wezipe_goshundylar_id,
                                                Wezipegoshundylarname = item.wezipe_goshundylar_name,
                                                oklad = item.oklad,
                                                Buyruknumber = item.buyruk_number,
                                                Buyrukdate = item.date_of_buyruk
                                            });


                                        }
                                    }
                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        CreateWordDocument();
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
        public class MyModel
        {
            public string Name { get; set; }
            public string oklad { get; set; }
        }
        private static void CreateWordDocument()
        {
            try
            {

                List<MyModel> modelList = new List<MyModel> { };           

                modelList.Clear();

                foreach (var item in Wezipegornushlist)
                {
                    modelList.Add( new MyModel { Name = item.Name.ToString(),  oklad=item.oklad.ToString() });
                }
                
                // Create a new Word application instance
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = true;

                string documentName = "" + DateTime.Now.ToString("yyyy") + "-" + Staticvars.Number + ".docx";
                string documentPath = @"D:\";
                Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add();


                // Add a header or paragraph to the right side
                Microsoft.Office.Interop.Word.Paragraph headerParagraph = wordDoc.Content.Paragraphs.Add();
                headerParagraph.Range.Text = "  Türkmenistanyň Içeri işler ministrliginiň";

                headerParagraph.Range.Font.Size = 14; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight; // Align to the right side   
                headerParagraph.Range.InsertParagraphAfter();

                headerParagraph.Range.Text ="" +DateTime.Now.ToString("yyyy") + " - nji ýylyň «____»-nji(y) dekabryndaky " + " ";
                // Insert a new paragraph after the current one
                headerParagraph.Range.Font.Size = 14; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight; // Align to the right side      
                headerParagraph.Range.InsertParagraphAfter();

                headerParagraph.Range.Text = " ____ belgili buýrugyna " + Staticvars.Number + " ";
                // Insert a new paragraph after the current one
                headerParagraph.Range.Font.Size = 14; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight; // Align to the right side         

                headerParagraph.Range.InsertParagraphAfter();

                headerParagraph.Range.Text = "  ";
                // Insert a new paragraph after the current one
                headerParagraph.Range.Font.Size = 14; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight; // Align to the right side         

                headerParagraph.Range.InsertParagraphAfter();
                headerParagraph.Range.Font.Size = 12; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; // Align to the right side            

                headerParagraph.Range.Text = ""+Staticvars.Subject+"";
                // Insert a new paragraph after the current one
                headerParagraph.Range.Font.Size = 14; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; // Align to the right side  
                
                headerParagraph.Range.InsertParagraphAfter();
                headerParagraph.Range.Font.Size = 12; // Set the font size
                headerParagraph.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; // Align to the right side    
                // Create a new table with the appropriate number of rows and columns
                int numRows = modelList.Count+1;
               
                int numCols = 2;

             //   headerParagraph.Range.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdSectionBreakContinuous); // Insert a section break after the paragraph

                Microsoft.Office.Interop.Word.Table wordTable = wordDoc.Tables.Add(headerParagraph.Range, numRows, numCols, Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior, Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);

                wordTable.Cell(1, 1).Range.Text = "W E Z I P E L E R I Ň    A T L A R Y ";
                wordTable.Cell(1, 2).Range.Text = "Aýlyk wezipe haky (manat)";

                // Loop through the model and add data to the table
                for (int row = 1; row < modelList.Count; row ++)
                {
                    // Use a separate index for the DataTable
                    int dataTableIndex = row  + 1;
                    for (int col = 1; col <= numCols; col++)
                    {
                        object cellValue = modelList[row].GetType().GetProperty(col == 1 ? "Name" : "oklad").GetValue(modelList[row], null);
                        // Set the text of the corresponding cell in the Word table
                        wordTable.Cell(dataTableIndex, col).Range.Text = cellValue.ToString();
                    }
                }
                
                wordDoc.SaveAs2(documentPath+documentName);

               
                // Close the Word document and application
                wordDoc.Close();
                wordApp.Quit();
                // Release COM objects
                Marshal.ReleaseComObject(wordTable);
                Marshal.ReleaseComObject(wordDoc);
                Marshal.ReleaseComObject(wordApp);



            }
            catch (Exception ex)
            {

                MessageBox.Show("Microsoft Word programmasyny işe girizmekde kynçylyk ýüze çykdy!");
            }

        }
       


       




    }
}
