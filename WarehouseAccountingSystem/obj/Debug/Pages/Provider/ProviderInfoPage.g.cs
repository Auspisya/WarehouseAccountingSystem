﻿#pragma checksum "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D291B54D6146A230FAB5326CEC4E91D3EFCAEC52D3A48A253645328B5E536B02"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WarehouseAccountingSystem.Pages.Provider;


namespace WarehouseAccountingSystem.Pages.Provider {
    
    
    /// <summary>
    /// ProviderInfoPage
    /// </summary>
    public partial class ProviderInfoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbAddress;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbINNNumber;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbINNWhoRegistered;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbINNRegistrationDate;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseAccountingSystem;component/pages/provider/providerinfopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
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
            this.TxbName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TxbAddress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TxbPhoneNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TxbINNNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TxbINNWhoRegistered = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TxbINNRegistrationDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Pages\Provider\ProviderInfoPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
