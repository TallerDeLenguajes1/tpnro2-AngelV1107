﻿#pragma checksum "..\..\..\Vistas\VistaAbmAlumno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78F06F73DC03B25A3E25DFFF887E9F5DD2B37405A8AA045F79E816840FDECE87"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WpfApp1.Vistas;


namespace WpfApp1.Vistas {
    
    
    /// <summary>
    /// VistaAbmAlumno
    /// </summary>
    public partial class VistaAbmAlumno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNombre;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDni;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbApellido;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaNac;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBorrar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Vistas\VistaAbmAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/vistas/vistaabmalumno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vistas\VistaAbmAlumno.xaml"
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
            
            #line 8 "..\..\..\Vistas\VistaAbmAlumno.xaml"
            ((WpfApp1.Vistas.VistaAbmAlumno)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbDni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbApellido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.dpFechaNac = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.btnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Vistas\VistaAbmAlumno.xaml"
            this.btnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnBorrar = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Vistas\VistaAbmAlumno.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.BtnSalir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

