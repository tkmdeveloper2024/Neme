using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Umumym.xaml
    /// </summary>
    public partial class Umumym : Page
    {
        List<dataGriditems> items1 = new List<dataGriditems>();
        List<dataGriditems2> items2 = new List<dataGriditems2>();
        List<dataGriditems3> items3 = new List<dataGriditems3>();
        List<dataGriditems4> items4 = new List<dataGriditems4>();
        public Umumym()
        {
            InitializeComponent();

            int currentyear = DateTime.Now.Year;
            Yeartb.Content = currentyear.ToString();
            items1.Add(new dataGriditems() { Number = "202", AFAA = "Ulanyjylar",  });
            items1.Add(new dataGriditems() { Number = "202", AFAA = "Ulanyjylar", });
            items1.Add(new dataGriditems() { Number = "202", AFAA = "Ulanyjylar", });
            items1.Add(new dataGriditems() { Number = "202", AFAA = "Ulanyjylar",  });
                                                                                                                                  

            dataGrid_1.Items.Clear();
            dataGrid_1.ItemsSource = null;
            dataGrid_1.Items.Refresh();
            dataGrid_1.ItemsSource = items1;


            items2.Add(new dataGriditems2() { Number = "202", AFAA = "Ulanyjylar", });
            items2.Add(new dataGriditems2() { Number = "202", AFAA = "Ulanyjylar", });

            dataGrid_2.Items.Clear();
            dataGrid_2.ItemsSource = null;
            dataGrid_2.Items.Refresh();
            dataGrid_2.ItemsSource = items2;

            items3.Add(new dataGriditems3() { Number = "202", AFAA = "Ulanyjylar", });
            items3.Add(new dataGriditems3() { Number = "202", AFAA = "Ulanyjylar", });

            dataGrid_3.Items.Clear();
            dataGrid_3.ItemsSource = null;
            dataGrid_3.Items.Refresh();
            dataGrid_3.ItemsSource = items3;

            items4.Add(new dataGriditems4() { Number = "202", AFAA = "Ulanyjylar", });
            items4.Add(new dataGriditems4() { Number = "202", AFAA = "Ulanyjylar", });

            dataGrid_4.Items.Clear();
            dataGrid_4.ItemsSource = null;
            dataGrid_4.Items.Refresh();
            dataGrid_4.ItemsSource = items4;
        }

        public class dataGriditems
        {
            public string Number { get; set; }
            public string AFAA { get; set; }         


        }

        public class dataGriditems2
        {
            public string Number { get; set; }
            public string AFAA { get; set; }


        }
        public class dataGriditems3
        {
            public string Number { get; set; }
            public string AFAA { get; set; }


        }
        public class dataGriditems4
        {
            public string Number { get; set; }
            public string AFAA { get; set; }


        }

    }
}
