// Updated by XamlIntelliSenseFileGenerator 22.06.2023 23:18:29
#pragma checksum "..\..\..\..\Pages\ProductArrival\ProductArrivalAddPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A6B5BE63100F5DA6054C400C67AA4FC4F952C559E5AA1604157DCC4E51423BF7"
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
using WarehouseAccountingSystem.Pages.ProductArrival;


namespace WarehouseAccountingSystem.Pages.ProductArrival
{


    /// <summary>
    /// ProductArrivalAddPage
    /// </summary>
    public partial class ProductArrivalAddPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WarehouseAccountingSystem;component/pages/productarrival/productarrivaladdpage.x" +
                    "aml", System.UriKind.Relative);

#line 1 "..\..\..\..\Pages\ProductArrival\ProductArrivalAddPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button BtnBack;
        internal System.Windows.Controls.TextBox TxbQuantity;
        internal System.Windows.Controls.Button BtnAdd;
        internal System.Windows.Controls.ComboBox CmbProductName;
        internal System.Windows.Controls.TextBox TxbUnitPrice;
        internal System.Windows.Controls.TextBox TxbPrice;
        internal System.Windows.Controls.ComboBox CmbEmployeeAccepted;
        internal System.Windows.Controls.TextBox TxbProviderName;
        internal System.Windows.Controls.TextBox TxbProviderAddress;
        internal System.Windows.Controls.TextBox TxbProviderINNNumber;
        internal System.Windows.Controls.TextBox TxbProviderPhoneNumber;
        internal System.Windows.Controls.DatePicker DPProviderINNRegistrationDate;
        internal System.Windows.Controls.TextBox TxbProviderINNWhoRegistered;
        internal System.Windows.Controls.DatePicker DPArrivalDate;
        internal System.Windows.Controls.DatePicker DPProcurationDateOfIssue;
        internal System.Windows.Controls.TextBox TxbProcurationNumber;
        internal System.Windows.Controls.CheckBox CBAddProvider;
        internal System.Windows.Controls.StackPanel SPAddProvider;
        internal System.Windows.Controls.CheckBox CBChooseProvider;
        internal System.Windows.Controls.StackPanel SPChooseProvider;
        internal System.Windows.Controls.ComboBox CmbProvider;
        internal System.Windows.Controls.TextBox TxbDescription;
    }
}
