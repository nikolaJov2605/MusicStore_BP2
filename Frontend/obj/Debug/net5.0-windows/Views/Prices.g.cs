﻿#pragma checksum "..\..\..\..\Views\Prices.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B69A11DFE0241A1B5E018A4EEC90FEBE67FFBD9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Frontend.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Frontend.Views {
    
    
    /// <summary>
    /// Prices
    /// </summary>
    public partial class Prices : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgPrices;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCaption;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbNewPrice;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAmmount;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDateStart;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDateEnd;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAmmount;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDateStart;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDateEnd;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Frontend;component/views/prices.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Prices.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Views\Prices.xaml"
            ((Frontend.Views.Prices)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgPrices = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.lblCaption = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.gbNewPrice = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 5:
            this.lblAmmount = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblDateStart = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblDateEnd = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.tbAmmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.dpDateStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.dpDateEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.btnAddPrice = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Views\Prices.xaml"
            this.btnAddPrice.Click += new System.Windows.RoutedEventHandler(this.btnAddPrice_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
