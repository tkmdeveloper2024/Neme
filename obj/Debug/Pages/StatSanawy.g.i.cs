﻿#pragma checksum "..\..\..\Pages\StatSanawy.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E6F596A1B9949BA3C5E5C20A5324869C7E491FE19F0D4427FF625B8661F26F1"
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
    /// StatSanawy
    /// </summary>
    public partial class StatSanawy : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 79 "..\..\..\Pages\StatSanawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MudirlikList;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Pages\StatSanawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Searchtxt;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\Pages\StatSanawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_Stat;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\Pages\StatSanawy.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Neme;component/pages/statsanawy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\StatSanawy.xaml"
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
            
            #line 10 "..\..\..\Pages\StatSanawy.xaml"
            ((Neme.Pages.StatSanawy)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MudirlikList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 78 "..\..\..\Pages\StatSanawy.xaml"
            this.MudirlikList.KeyDown += new System.Windows.Input.KeyEventHandler(this.Show_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Searchtxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 147 "..\..\..\Pages\StatSanawy.xaml"
            this.Searchtxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Searchtxt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid_Stat = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.Yeartb = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

