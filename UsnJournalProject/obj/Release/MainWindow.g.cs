﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "057C6D2EFFA36308D4A888CE0A32FDAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PInvoke;
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.DockPanel usnButtonStack;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button SelectVolume;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button QueryUsnJournal;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button CreateUsnJournal;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button DeleteUsnJournal;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button SaveUsnState;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button ViewUsnChanges;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button ListFolders;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button ListFiles;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.DockPanel resultsDock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label FunctionElapsedTime;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.ListBox resultsLb;
        
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
            System.Uri resourceLocater = new System.Uri("/UsnJournalProject;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 6 "..\..\MainWindow.xaml"
            ((UsnJournalProject.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.usnButtonStack = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 4:
            this.SelectVolume = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.SelectVolume.Click += new System.Windows.RoutedEventHandler(this.SelectVolume_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.QueryUsnJournal = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.QueryUsnJournal.Click += new System.Windows.RoutedEventHandler(this.QueryUsnJournal_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CreateUsnJournal = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.CreateUsnJournal.Click += new System.Windows.RoutedEventHandler(this.CreateUsnJournal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DeleteUsnJournal = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.DeleteUsnJournal.Click += new System.Windows.RoutedEventHandler(this.DeleteUsnJournal_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SaveUsnState = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.SaveUsnState.Click += new System.Windows.RoutedEventHandler(this.SaveUsnState_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ViewUsnChanges = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.ViewUsnChanges.Click += new System.Windows.RoutedEventHandler(this.ViewUsnChanges_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ListFolders = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.ListFolders.Click += new System.Windows.RoutedEventHandler(this.ListFolders_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ListFiles = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.ListFiles.Click += new System.Windows.RoutedEventHandler(this.ListFiles_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.resultsDock = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 13:
            this.FunctionElapsedTime = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.resultsLb = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.resultsLb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.resultsLb_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 32 "..\..\MainWindow.xaml"
            this.resultsLb.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.resultsLb_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 33 "..\..\MainWindow.xaml"
            this.resultsLb.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.resultsLb_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}