using EntidadesDeProyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Vistas;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    enum Entidad
    {
        Alumno,
        Empleado,
        Curso
    }
    enum ModoABM
    {
        Alta,
        Modif,
        SinSelecc
    }
    public partial class MainWindow : Window
    {
        List<Alumno> alumnos;
        List<Empleado> empleados;
        List<Curso> cursos;

        public MainWindow()
        {
            alumnos = new List<Alumno>();
            empleados = new List<Empleado>();
            cursos = new List<Curso>();

            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CbxEntidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                UpdateList();
                UpdateInfo();
                UpdateBtns();
            }
        }
        private void UpdateInfo()
        {
            stkInfo.Children.Clear();

            

            if (DeterminarModoABM() == ModoABM.Alta || DeterminarModoABM() == ModoABM.SinSelecc)
            {
                //Sin seleccion o alta
                switch (EntidadSeleccionada())
                {
                    case Entidad.Alumno:
                        stkInfo.Children.Add(WPInfo("Nombre:", ""));
                        stkInfo.Children.Add(WPInfo("Apellido:", ""));
                        stkInfo.Children.Add(WPInfo("DNI:", ""));
                        stkInfo.Children.Add(WPInfo("Fecha de nacimiento:", ""));
                        stkInfo.Children.Add(WPInfo("Edad:", ""));
                        stkInfo.Children.Add(WPInfo("Cuotas pagadas:", ""));
                        break;
                    case Entidad.Empleado:
                        stkInfo.Children.Add(WPInfo("Nombre:", ""));
                        stkInfo.Children.Add(WPInfo("Apellido:", ""));
                        stkInfo.Children.Add(WPInfo("DNI:", ""));
                        stkInfo.Children.Add(WPInfo("Fecha de nacimiento:", ""));
                        stkInfo.Children.Add(WPInfo("Edad:", ""));
                        stkInfo.Children.Add(WPInfo("Fecha de alta:", ""));
                        stkInfo.Children.Add(WPInfo("Antiguedad:", ""));
                        stkInfo.Children.Add(WPInfo("Cargo:", ""));
                        stkInfo.Children.Add(WPInfo("Sueldo:", ""));
                        break;
                    case Entidad.Curso:
                        stkInfo.Children.Add(WPInfo("Tema:", ""));
                        stkInfo.Children.Add(WPInfo("Docente:", ""));
                        stkInfo.Children.Add(WPInfo("Turno:", ""));
                        stkInfo.Children.Add(WPInfo("Inscripcion:", ""));
                        stkInfo.Children.Add(WPInfo("Cuota:", ""));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //Datos de una entidad existente

                int indiceLbx = lbxEntidades.SelectedIndex;
                switch (EntidadSeleccionada())
                {
                    case Entidad.Alumno:
                        UpdateInfo(alumnos[indiceLbx]);
                        break;
                    case Entidad.Empleado:
                        UpdateInfo(empleados[indiceLbx]);
                        break;
                    case Entidad.Curso:
                        UpdateInfo(cursos[indiceLbx]);
                        break;
                    default:
                        break;
                }
            }            
        }
        private void UpdateInfo(Alumno alum)
        {
            stkInfo.Children.Clear();
            stkInfo.Children.Add(WPInfo("Nombre:", alum.Nombre));
            stkInfo.Children.Add(WPInfo("Apellido:", alum.Apellido));
            stkInfo.Children.Add(WPInfo("DNI:", alum.Dni.ToString()));
            stkInfo.Children.Add(WPInfo("Fecha de nacimiento:", alum.FechaDeNac.ToShortDateString()));
            stkInfo.Children.Add(WPInfo("Edad:", alum.Edad().ToString()));
            stkInfo.Children.Add(WPInfo("Cuotas pagadas:", ""));
        }
        private void UpdateInfo(Empleado emp)
        {
            stkInfo.Children.Clear();
            stkInfo.Children.Add(WPInfo("Nombre:", emp.Nombre));
            stkInfo.Children.Add(WPInfo("Apellido:", emp.Apellido));
            stkInfo.Children.Add(WPInfo("DNI:", emp.Dni.ToString()));
            stkInfo.Children.Add(WPInfo("Fecha de nacimiento:", emp.FechaDeNac.ToShortDateString()));
            stkInfo.Children.Add(WPInfo("Edad:", emp.Edad().ToString()));
            stkInfo.Children.Add(WPInfo("Fecha de alta:", emp.FechaDeAlta.ToShortDateString()));
            stkInfo.Children.Add(WPInfo("Antiguedad:", emp.Antiguedad().ToString()));
            stkInfo.Children.Add(WPInfo("Cargo:", emp.CargoEmp.ToString()));
            stkInfo.Children.Add(WPInfo("Sueldo:", emp.Sueldo.ToString()));
        }
        private void UpdateInfo(Curso cur)
        {
            stkInfo.Children.Clear();
            stkInfo.Children.Add(WPInfo("Tema:", cur.Tema));
            stkInfo.Children.Add(WPInfo("Docente:", cur.Docente.Apellido + ", " + cur.Docente.Nombre ));
            stkInfo.Children.Add(WPInfo("Turno:", cur.Turno.ToString()));
            stkInfo.Children.Add(WPInfo("Inscripcion:", cur.Inscripcion.ToString()));
            stkInfo.Children.Add(WPInfo("Cuota:", cur.Cuota.ToString()));
        }
        private void UpdateList()
        {
            lbxEntidades.Items.Clear();

            switch (EntidadSeleccionada())
            {
                case Entidad.Alumno:                    
                    foreach(Alumno alum in alumnos)
                    {
                        lbxEntidades.Items.Add(alum);
                    }
                    break;
                case Entidad.Empleado:
                    foreach (Empleado emp in empleados)
                    {
                        lbxEntidades.Items.Add(emp);
                    }
                    break;
                case Entidad.Curso:
                    foreach (Curso cur in cursos)
                    {
                        lbxEntidades.Items.Add(cur);
                    }
                    break;
                default:
                    break;
            }

            lbxEntidades.Items.Add("<nuevo>");
        }
        private void UpdateBtns()
        {
            if (DeterminarModoABM() != ModoABM.SinSelecc)
            {
                btnABM.IsEnabled = true;
                btnOpcion1.IsEnabled = true;
                btnOpcion2.IsEnabled = true;
            }
            else
            {
                btnABM.IsEnabled = false;
                btnOpcion1.IsEnabled = false;
                btnOpcion2.IsEnabled = false;
            }

            switch (EntidadSeleccionada())
            {
                case Entidad.Alumno:
                    btnOpcion1.Content = "Pagar cuotas";
                    btnOpcion2.Content = "";

                    btnOpcion2.IsEnabled = false;
                    break;
                case Entidad.Empleado:
                    btnOpcion1.Content = "";
                    btnOpcion2.Content = "";

                    btnOpcion1.IsEnabled = false;
                    btnOpcion2.IsEnabled = false;
                    break;
                case Entidad.Curso:
                    btnOpcion1.Content = "Ver inscripciones";
                    btnOpcion2.Content = "Generar CSV";
                    break;
                default:
                    break;
            }
        }
        private WrapPanel WPInfo(string tipo, string contenido)
        {
            WrapPanel wp = new WrapPanel();
            Label lbTipo = new Label();
            Label lbInfo = new Label();

            lbTipo.Content = tipo;
            lbInfo.Content = contenido;

            wp.Children.Add(lbTipo);
            wp.Children.Add(lbInfo);

            return wp;
        }
        private Entidad EntidadSeleccionada()
        {
            Entidad ent = (Entidad)cbxEntidades.SelectedIndex;
            return ent;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxEntidades.SelectedIndex = (int) Entidad.Alumno;
            UpdateList();
            UpdateInfo();
            UpdateBtns();
        }
        private void LbxEntidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInfo();
            UpdateBtns();
        }
        private ModoABM DeterminarModoABM()
        {
            if (lbxEntidades.SelectedIndex != -1)
            {
                if (lbxEntidades.SelectedItem.ToString() == "<nuevo>")
                {
                    return ModoABM.Alta;
                }
                else
                {
                    return ModoABM.Modif;
                }
            }
            else
            {
                return ModoABM.SinSelecc;
            }
        }
        private void BtnABM_Click(object sender, RoutedEventArgs e)
        {
            if (DeterminarModoABM() != ModoABM.SinSelecc)
            {
                int indiceLbx = lbxEntidades.SelectedIndex;
                if (DeterminarModoABM() == ModoABM.Alta)
                {
                    Alta();
                }
                else if (DeterminarModoABM() == ModoABM.Modif)
                {
                    Modificacion();
                }
                lbxEntidades.SelectedIndex = indiceLbx;
                UpdateInfo();
            }
            else
            {
                //Nada
            }
        }
        private void Alta()
        {
            switch (EntidadSeleccionada())
            {
                case Entidad.Alumno:
                    VistaAbmAlumno AbmAlum = new VistaAbmAlumno();
                    AbmAlum.ShowDialog();

                    if (AbmAlum.ConGuardado == true)
                    {
                        alumnos.Add(AbmAlum.Alumno);
                    }
                    UpdateList();
                    break;
                case Entidad.Empleado:
                    VistaAbmEmpleado AbmEmp = new VistaAbmEmpleado();
                    AbmEmp.ShowDialog();
                    
                    if (AbmEmp.ConGuardado == true)
                    {
                       empleados.Add(AbmEmp.Empleado);
                    }
                    UpdateList();
                    break;
                case Entidad.Curso:
                    VistaAbmCurso AbmCur = new VistaAbmCurso(alumnos, empleados);
                    AbmCur.ShowDialog();

                    if (AbmCur.ConGuardado == true)
                    {
                        cursos.Add(AbmCur.Curso);
                    }
                    UpdateList();
                    break;

                default:
                    break;
            }
        }
        private void Modificacion()
        {
            switch (EntidadSeleccionada())
            {
                case Entidad.Alumno:
                    VistaAbmAlumno AbmAlum = new VistaAbmAlumno(alumnos[lbxEntidades.SelectedIndex]);
                    AbmAlum.ShowDialog();
                    alumnos[lbxEntidades.SelectedIndex] = AbmAlum.Alumno;
                    UpdateList();
                    break;

                case Entidad.Empleado:
                    VistaAbmEmpleado AbmEmp = new VistaAbmEmpleado(empleados[lbxEntidades.SelectedIndex]);
                    AbmEmp.ShowDialog();
                    empleados[lbxEntidades.SelectedIndex] = AbmEmp.Empleado;
                    UpdateList();
                    break;

                case Entidad.Curso:
                    VistaAbmCurso AbmCur = new VistaAbmCurso(alumnos, empleados, cursos[lbxEntidades.SelectedIndex]);
                    AbmCur.ShowDialog();
                    cursos[lbxEntidades.SelectedIndex] = AbmCur.Curso;
                    UpdateList();
                    break;
                default:
                    break;
            }
        }
    }
}
