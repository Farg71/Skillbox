﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D8E9F42E6435BE04DF1A2EA58003620456DA9FA"
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
using WPF;


namespace WPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPF.MainWindow mainWindow;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox usersList;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox concreteUsersChat;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBxSendMsg;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendMsg;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelStatus;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectStatus;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem bot_Open;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem bot_Close;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainWindow = ((WPF.MainWindow)(target));
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.mainWindow.Closed += new System.EventHandler(this.mainWindow_Closed);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.mainWindow.Activated += new System.EventHandler(this.mainWindow_Activated);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.mainWindow.Closing += new System.ComponentModel.CancelEventHandler(this.mainWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.usersList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.concreteUsersChat = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.txtBxSendMsg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnSendMsg = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\MainWindow.xaml"
            this.btnSendMsg.Click += new System.Windows.RoutedEventHandler(this.btnSendMsg_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.rectStatus = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 8:
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 9:
            this.bot_Open = ((System.Windows.Controls.MenuItem)(target));
            
            #line 139 "..\..\..\MainWindow.xaml"
            this.bot_Open.Click += new System.Windows.RoutedEventHandler(this.bot_Open_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.bot_Close = ((System.Windows.Controls.MenuItem)(target));
            
            #line 143 "..\..\..\MainWindow.xaml"
            this.bot_Close.Click += new System.Windows.RoutedEventHandler(this.bot_Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

