using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlumno
{
    public class Alumno
    {// Automatic properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public Alumno() { }
        public Alumno(int id, string nombre, string apellidos, string dni)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Id == alumno.Id &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   DNI == alumno.DNI;
        }

        public override int GetHashCode()
        {
            var hashCode = -875667990;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }
        public override string ToString()//convierte los objetos en string, si no l hay te devuelve la ruta del objeto
        {
            return "id "+Id + "nombre: "+ Nombre+"apellidos: " + Apellidos +"dni: " + DNI;
        }
    }
    //ademas tiene que existir un metodo ToJson(), convertir el objeto en json y devolviendo
}
