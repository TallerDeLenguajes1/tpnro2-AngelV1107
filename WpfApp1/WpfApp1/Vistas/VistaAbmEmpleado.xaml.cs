using EntidadesDeProyecto;
using HelperWPF;
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

namespace WpfApp1.Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaAbmEmpleado.xaml
    /// </summary>
    public partial class VistaAbmEmpleado : Window
    {
        bool conGuardado = false;
        Empleado empleado;
        public VistaAbmEmpleado()
        {
            InitializeComponent();
            cbxCargo.ItemsSource = Enum.GetValues(typeof(Cargo));
            empleado = new Empleado();
        }
        public VistaAbmEmpleado(Empleado _empleado) : this()
        {
            empleado = _empleado;

            txbNombre.Text = empleado.Nombre;
            txbApellido.Text = empleado.Apellido;
            txbDni.Text = empleado.Dni.ToString();
            txbSueldo.Text = empleado.Sueldo.ToString();
            dpFechaAlta.SelectedDate = empleado.FechaDeAlta;
            dpFechaNac.SelectedDate = empleado.FechaDeNac;
            cbxCargo.SelectedIndex = (int)empleado.CargoEmp;
        }

        public Empleado Empleado { get => empleado; }
        public bool ConGuardado { get => conGuardado; }

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


        private bool ValidarCampos()
        {
            if (Validacion.esTxbTexto(txbNombre)
                && Validacion.esTxbTexto(txbApellido)
                && Validacion.esTxbNumLong(txbDni)
                && Validacion.esTxbNumDouble(txbSueldo)
                && Validacion.esFechaPasado(dpFechaNac)
                && Validacion.esFechaPasado(dpFechaAlta) 
                && cbxCargo.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GuardarDatosEmpleado()
        {
            empleado.Nombre = txbNombre.Text;
            empleado.Apellido = txbApellido.Text;
            empleado.Dni = Convert.ToInt64(txbDni.Text);
            empleado.Sueldo = Convert.ToDecimal(txbSueldo.Text);
            empleado.FechaDeNac = dpFechaNac.SelectedDate.Value;
            empleado.FechaDeAlta = dpFechaAlta.SelectedDate.Value;
            empleado.CargoEmp = (Cargo)cbxCargo.SelectedIndex;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (conGuardado == true)
            {
                if (ValidarCampos() == true)
                {
                    GuardarDatosEmpleado();
                }
                else
                {
                    conGuardado = false;
                    MessageBox.Show("Datos incorrectos", "ABM Empleado");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBoxResult result =
                    MessageBox.Show
                    ("Salir sin guardar?"
                    , "ABM Empleado"
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
    }
}
