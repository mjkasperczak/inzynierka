﻿#pragma checksum "..\..\VolumeSelectDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C205AC9B7A7F46689740EC56A83D233"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace UsnJournalProject {
    
    
    /// <summary>
    /// VolumeSelectDialog
    /// </summary>
    public partial class VolumeSelectDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\VolumeSelectDialog.xaml"
        internal System.Windows.Controls.DockPanel selectionStack;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\VolumeSelectDialog.xaml"
        internal System.Windows.Controls.ListBox drivesLb;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\VolumeSelectDialog.xaml"
        internal System.Windows.Controls.TextBox selectionErrorTb;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\VolumeSelectDialog.xaml"
        internal System.Windows.Controls.Button cancelBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\VolumeSelectDialog.xaml"
        internal System.Windows.Controls.Button okBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UsnJournalProject;component/volumeselectdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VolumeSelectDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.selectionStack = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.drivesLb = ((System.Windows.Controls.ListBox)(target));
            
            #line 16 "..\..\VolumeSelectDialog.xaml"
            this.drivesLb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.drivesLb_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 16 "..\..\VolumeSelectDialog.xaml"
            this.drivesLb.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.drivesLb_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.selectionErrorTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\VolumeSelectDialog.xaml"
            this.cancelBtn.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.okBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\VolumeSelectDialog.xaml"
            this.okBtn.Click += new System.Windows.RoutedEventHandler(this.ok_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}