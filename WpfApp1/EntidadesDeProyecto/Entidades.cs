using System;
using System.Collections.Generic;

namespace EntidadesDeProyecto
{
    public class Persona
    {
        string nombre;
        string apellido;
        DateTime fechaDeNacimiento;
        long dni;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public DateTime FechaDeNacimiento
        {
            get
            {
                return fechaDeNacimiento;
            }

            set
            {
                fechaDeNacimiento = value;
            }
        }

        public long Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public int Edad()
        {

            //Hacer Edad
            return 0;
        }

        public override string ToString()
        {
            return dni + ", " + apellido + ", " + apellido + ", " + FechaDeNacimiento.ToShortDateString();
        }

    }

    public class Alumno : Persona
    {
        List<Cuota> cuotas;

        public Alumno()
        {
            cuotas = new List<Cuota>(12);
        }

        public List<Cuota> Cuotas
        {
            get
            {
                return cuotas;
            }

            set
            {
                cuotas = value;
            }
        }

    }

    public enum Cargo
    {
        docente,
        director,
        conserje
    }


    public class Empleado : Persona
    {
        DateTime fechaDeAlta;
        Cargo cargoEmp;
        decimal sueldo;

        public DateTime FechaDeAlta
        {
            get
            {
                return fechaDeAlta;
            }

            set
            {
                fechaDeAlta = value;
            }
        }

        public Cargo CargoEmp
        {
            get
            {
                return cargoEmp;
            }

            set
            {
                cargoEmp = value;
            }
        }

        public decimal Sueldo
        {
            get
            {
                return sueldo;
            }

            set
            {
                sueldo = value;
            }
        }

        public int Antiguedad()
        {
            //hacer antiguedad
            return 0;
        }

    }

    public abstract class Curso
    {
        DateTime turno;
        List<Alumno> alumnos;
        Empleado docente;
        string tema;
        float cuota;
        float inscripcion;

        public abstract string GetTipo();


        public DateTime Turno
        {
            get
            {
                return turno;
            }

            set
            {
                turno = value;
            }
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }

            set
            {
                alumnos = value;
            }
        }

        public Empleado Docente
        {
            get
            {
                return docente;
            }

            set
            {
                docente = value;
            }
        }

        public string Tema
        {
            get
            {
                return tema;
            }

            set
            {
                tema = value;
            }
        }

        public float Cuota
        {
            get
            {
                return cuota;
            }

            set
            {
                cuota = value;
            }
        }

        public float Inscripcion
        {
            get
            {
                return inscripcion;
            }

            set
            {
                inscripcion = value;
            }
        }

        public void CargarAlumno(Alumno alu)
        {

        }

        public void GuardarDatosEnArchivo()
        {

        }

        public virtual decimal ValorCuota()
        {
            return 0;
        }


    }

    public class Presencial : Curso
    {
        public override string GetTipo()
        {
            return "Presencial";
        }
    }

    public class SemiPresencial : Curso
    {
        public override string GetTipo()
        {
            return "SemiPresencial";
        }
    }

    public class NoPresencial : Curso
    {
        public override string GetTipo()
        {
            return "No Presencial";
        }
    }

    public class Cuota
    {
        decimal valor;
        bool pagada;

        public decimal Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public bool Pagada
        {
            get
            {
                return pagada;
            }

            set
            {
                pagada = value;
            }
        }
    }
}
