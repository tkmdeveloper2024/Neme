﻿#pragma checksum "..\..\..\Pages\Gosundy.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "658A4C938FA36E50DC65647AB04E8898275A8E25F2597676BD2A36EADE0CDA63"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Neme.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Neme.Pages {
    
    
    /// <summary>
    /// Gosundy
    /// </summary>
    public partial class Gosundy : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Gosundynumber;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Gosundysubject;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Searchtxt;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_latestgosundy;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\..\Pages\Gosundy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Yeartb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Neme;component/pages/gosundy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Gosundy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\Pages\Gosundy.xaml"
            ((Neme.Pages.Gosundy)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Gosundynumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\Pages\Gosundy.xaml"
            this.Gosundynumber.KeyDown += new System.Windows.Input.KeyEventHandler(this.Gosundynumber_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Gosundysubject = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\Pages\Gosundy.xaml"
            this.Gosundysubject.KeyDown += new System.Windows.Input.KeyEventHandler(this.Gosundynumber_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\Pages\Gosundy.xaml"
            this.Save.KeyDown += new System.Windows.Input.KeyEventHandler(this.Gosundynumber_KeyDown);
            
            #line default
            #line hidden
            
            #line 142 "..\..\..\Pages\Gosundy.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Searchtxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 221 "..\..\..\Pages\Gosundy.xaml"
            this.Searchtxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dataGrid_latestgosundy = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.Yeartb = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

