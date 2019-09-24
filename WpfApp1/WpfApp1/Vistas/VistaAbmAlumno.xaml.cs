using EntidadesDeProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HelperWPF;

namespace WpfApp1.Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaAbmAlumno.xaml
    /// </summary>
    public partial class VistaAbmAlumno : Window
    {
        bool conGuardado = false;
        Alumno alumno;


        public VistaAbmAlumno()
        {
            InitializeComponent();
            alumno = new Alumno();
        }
        public VistaAbmAlumno(Alumno _alumno) : this()
        {
            alumno = _alumno;

            txbNombre.Text = alumno.Nombre;
            txbApellido.Text = alumno.Apellido;
            txbDni.Text = alumno.Dni.ToString();
            dpFechaNac.SelectedDate = alumno.FechaDeNac;
        }

        public bool ConGuardado { get => conGuardado;}
        public Alumno Alumno { get => alumno;}

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            conGuardado = true;
            this.Close();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            conGuardado = false;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (conGuardado == true)
            {
                if (ValidarCampos() == true)
                {
                    GuardarDatosAlumno();
                }
                else
                {
                    conGuardado = false;
                    MessageBox.Show("Datos incorrectos", "ABM Alumno");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBoxResult result = 
                    MessageBox.Show
                    ( "Salir sin guardar?"
                    , "ABM Alumno"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Question
                    );

                if (result == MessageBoxResult.Yes)
                {
                    conGuardado = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private bool ValidarCampos()
        {
            if (   Validacion.esTxbTexto(txbNombre)
                && Validacion.esTxbTexto(txbApellido)
                && Validacion.esTxbNumLong(txbDni)
                && Validacion.esFechaPasado(dpFechaNac) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GuardarDatosAlumno()
        {
            alumno.Nombre = txbNombre.Text;
            alumno.Apellido = txbApellido.Text;
            alumno.Dni = Convert.ToInt64(txbDni.Text);
            alumno.FechaDeNac = dpFechaNac.SelectedDate.Value;
        }
    }
}
