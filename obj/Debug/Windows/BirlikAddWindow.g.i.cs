﻿#pragma checksum "..\..\..\Windows\BirlikAddWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "921CFBA3822F263256A6BE0030B851F21E5739239016D2ADE52264D11517EFA6"
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
using Neme.Windows;
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


namespace Neme.Windows {
    
    
    /// <summary>
    /// BirlikAddWindow
    /// </summary>
    public partial class BirlikAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Birlikady;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Birlikdolyady;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Birlikbelgi;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Birliksene;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Birlikyzygiderlik;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\Windows\BirlikAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
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
            System.Uri resourceLocater = new System.Uri("/Neme;component/windows/birlikaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\BirlikAddWindow.xaml"
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
            this.Birlikady = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Birlikdolyady = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Birlikbelgi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Birliksene = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Birlikyzygiderlik = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 229 "..\..\..\Windows\BirlikAddWindow.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

