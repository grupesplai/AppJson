using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlumno.Integration.Test
{
    class FuncionesTest
    {

        public static List<Alumno> getJson(string path)
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();

            using (StreamReader sr = new StreamReader(path))
            {
                string FileContent = sr.ReadToEnd();
                listadoAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(FileContent);

            }
            return listadoAlumnos;
        }
        public static Alumno RecogeDato(string path, int id, string nom, string ape, string dni)
        {
            Alumno al = new Alumno
            {
                Id = id,
                Nombre = nom,
                Apellidos = ape,
                DNI = dni
            };
            string sourceJson = string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}",
               al.Id, al.Nombre, al.Apellidos, al.DNI);

            using (StreamReader sr = new StreamReader(path))
            {
                string FileContent = sr.ReadToEnd();
                var listadoAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(FileContent);
                if (listadoAlumnos.Contains(al))
                    return al;
                else
                    return null;
            }
        }
    }
}
