﻿#pragma checksum "..\..\..\..\Vue\EcranSelectionQuantite.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E5294EDB41F594476EB7B0C68D79023FADA49AB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using CaisseAutomatique.Vue;
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


namespace CaisseAutomatique.Vue {
    
    
    /// <summary>
    /// EcranSelectionQuantite
    /// </summary>
    public partial class EcranSelectionQuantite : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ZoneSaisie;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BoutonValider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CaisseAutomatique;component/vue/ecranselectionquantite.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ZoneSaisie = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
            this.ZoneSaisie.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ZoneSaisie_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BoutonValider = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
            this.BoutonValider.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Vue\EcranSelectionQuantite.xaml"
            this.BoutonValider.Click += new System.Windows.RoutedEventHandler(this.BoutonValider_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
