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
    /// Lógica de interacción para VistaAbmCurso.xaml
    /// </summary>

    public partial class VistaAbmCurso : Window
    {
        readonly List<Alumno> alumnos;
        readonly List<Empleado> empleados;
        List<Empleado> docentes;

        bool conGuardado = false;
        Curso curso;

        public VistaAbmCurso(List<Alumno> _alumnos, List<Empleado> _empleados)
        {
            InitializeComponent();

            alumnos = _alumnos;
            empleados = _empleados;
            docentes = new List<Empleado>();

            foreach(Empleado emp in empleados)
            {
                if (emp.CargoEmp == Cargo.docente)
                {
                    docentes.Add(emp);
                }
            }
            lbxDocentes.ItemsSource = docentes;
        }
        public VistaAbmCurso(List<Alumno> _alumnos, List<Empleado> _empleados, Curso _curso) : this(_alumnos, _empleados)
        {
            curso = _curso;

            txbTema.Text = curso.Tema;
            txbInscr.Text = curso.Inscripcion.ToString();
            txbCuota.Text = curso.Cuota.ToString();
            dpTurno.SelectedDate = curso.Turno;
            
        }
        public bool ConGuardado { get => conGuardado; }
        public Curso Curso { get => curso; }


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
            if (   Validacion.esTxbTexto(txbTema)
                && Validacion.esTxbNumDouble(txbInscr)
                && Validacion.esTxbNumDouble(txbCuota)
                && ( !Validacion.esFechaPasado(dpTurno) )
                && cbxTipo.SelectedIndex != -1
                && lbxDocentes.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GuardarDatosCurso()
        {
            switch (cbxTipo.SelectedIndex)
            {
                case 0:
                    curso = new Presencial();
                    break;
                case 1:
                    curso = new SemiPresencial();
                    break;
                case 2:
                    curso = new NoPresencial();
                    break;
                default:
                    break;
            }
            curso.Tema = txbTema.Text;
            curso.Inscripcion = Convert.ToDecimal(txbInscr.Text);
            curso.Cuota = Convert.ToDecimal(txbCuota.Text);
            curso.Turno = dpTurno.SelectedDate.Value;
            curso.Tema = txbTema.Text;
            curso.Docente = docentes[lbxDocentes.SelectedIndex];
        }

        private void LbxDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (conGuardado == true)
            {
                if (ValidarCampos() == true)
                {
                    GuardarDatosCurso();
                }
                else
                {
                    conGuardado = false;
                    MessageBox.Show("Datos incorrectos", "ABM Curso");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBoxResult result =
                    MessageBox.Show
                    ("Salir sin guardar?"
                    , "ABM Curso"
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
