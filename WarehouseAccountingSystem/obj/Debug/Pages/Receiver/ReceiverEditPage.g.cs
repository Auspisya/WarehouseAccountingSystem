﻿#pragma checksum "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "706313DF62E492FD5CCC6C9E2D78705BD957C0E44B6DA9B0C290489CBBC02147"
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
using WarehouseAccountingSystem.Pages.Receiver;


namespace WarehouseAccountingSystem.Pages.Receiver {
    
    
    /// <summary>
    /// ReceiverEditPage
    /// </summary>
    public partial class ReceiverEditPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbAddress;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbINNNumber;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DPINNRegistrationDate;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbINNWhoRegistered;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseAccountingSystem;component/pages/receiver/receivereditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
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
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxbAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxbINNNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
            this.TxbINNNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxbNum_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TxbPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
            this.TxbPhoneNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxbNum_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DPINNRegistrationDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.TxbINNWhoRegistered = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\..\Pages\Receiver\ReceiverEditPage.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

