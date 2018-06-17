﻿#pragma checksum "..\..\..\Views\ElementsListView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "859F3B555C7814FEF0FDBC271B28F918999DBE66"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using FileManager.Views;
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


namespace FileManager.Views {
    
    
    /// <summary>
    /// ElementsListView
    /// </summary>
    public partial class ElementsListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NamesButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TypeButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DateButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxOfElements;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PreviousDirectoryButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DiscComboBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\ElementsListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBar;
        
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
            System.Uri resourceLocater = new System.Uri("/FileManager;component/views/elementslistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ElementsListView.xaml"
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
            this.NamesButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Views\ElementsListView.xaml"
            this.NamesButton.Click += new System.Windows.RoutedEventHandler(this.NamesButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TypeButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Views\ElementsListView.xaml"
            this.TypeButton.Click += new System.Windows.RoutedEventHandler(this.TypeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DateButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Views\ElementsListView.xaml"
            this.DateButton.Click += new System.Windows.RoutedEventHandler(this.DateButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListBoxOfElements = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\..\Views\ElementsListView.xaml"
            this.ListBoxOfElements.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemDoubleClicked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Views\ElementsListView.xaml"
            this.ListBoxOfElements.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ItemMouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PreviousDirectoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Views\ElementsListView.xaml"
            this.PreviousDirectoryButton.Click += new System.Windows.RoutedEventHandler(this.PreviousDirectoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DiscComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Views\ElementsListView.xaml"
            this.DiscComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DiscComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FilterBar = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Views\ElementsListView.xaml"
            this.FilterBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterBar_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

