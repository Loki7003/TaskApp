﻿#pragma checksum "..\..\..\PanelWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A67A0C91BD9EB47D17EBA49EDA732F83A684B92"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// PanelWindow
    /// </summary>
    public partial class PanelWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\PanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTask;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\PanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SeeTasks;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\PanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUser;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\PanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelUser;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\PanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TasksApp_myzfpuwa_wpftmp;component/panelwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PanelWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddTask = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\PanelWindow.xaml"
            this.AddTask.Click += new System.Windows.RoutedEventHandler(this.AddTask_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SeeTasks = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\PanelWindow.xaml"
            this.SeeTasks.Click += new System.Windows.RoutedEventHandler(this.SeeTasks_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddUser = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\PanelWindow.xaml"
            this.AddUser.Click += new System.Windows.RoutedEventHandler(this.AddUser_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DelUser = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\PanelWindow.xaml"
            this.DelUser.Click += new System.Windows.RoutedEventHandler(this.DelUser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\PanelWindow.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

