﻿#pragma checksum "..\..\EnterFileFilterString.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CF5D84AB1AC97920AFC71AE0A005693E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
    /// EnterFileFilterString
    /// </summary>
    public partial class EnterFileFilterString : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\EnterFileFilterString.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _fileFilterTb;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EnterFileFilterString.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _cancel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EnterFileFilterString.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _ok;
        
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
            System.Uri resourceLocater = new System.Uri("/UsnJournalProject;component/enterfilefilterstring.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EnterFileFilterString.xaml"
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
            this._fileFilterTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\EnterFileFilterString.xaml"
            this._fileFilterTb.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this._fileFilter_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this._cancel = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\EnterFileFilterString.xaml"
            this._cancel.Click += new System.Windows.RoutedEventHandler(this._cancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this._ok = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\EnterFileFilterString.xaml"
            this._ok.Click += new System.Windows.RoutedEventHandler(this._ok_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

