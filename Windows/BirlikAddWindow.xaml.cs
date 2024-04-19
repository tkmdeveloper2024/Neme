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
using System.Windows.Shapes;

namespace Neme.Windows
{
    /// <summary>
    /// Логика взаимодействия для BirlikAddWindow.xaml
    /// </summary>
    public partial class BirlikAddWindow : Window
    {
        private bool error1, error2, error3, error4, error5;
        public BirlikAddWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Birlikady.Text)) error1 = true;
            else error1 = false;

            if (!string.IsNullOrEmpty(Birlikdolyady.Text)) error2 = true;
            else error2 = false;

            if (!string.IsNullOrEmpty(Birlikbelgi.Text)) error3 = true;
            else error3 = false;

            if (!string.IsNullOrEmpty(Birliksene.Text)) error4 = true;
            else error4 = false;

            if (!string.IsNullOrEmpty(Birlikyzygiderlik.Text)) error5 = true;
            else error5 = false;

            


            if (error1==false && error2 == false && error3 == false && error4 == false && error5 == false )
            {
                //ADD birlik
            }

        }

     
        
    }
}
