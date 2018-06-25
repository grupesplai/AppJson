using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AppAlumno
{
    public class Funciones
    {       
        public static void RegistrarAlumno(Alumno alum, string path)
        {
            List<Alumno> listaAlumno = new List<Alumno> { alum };
            string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(path))
                sw.WriteLine(alumJson);
        }

        public static void addAlumno(Alumno alum, string path)
        {
            List<Alumno> listaAlumno = new List<Alumno>();

            using (StreamReader sr = new StreamReader(path))
            {
                string read = sr.ReadToEnd();
                listaAlumno = JsonConvert.DeserializeObject<List<Alumno>>(read);
            }

            listaAlumno.Add(alum);
            string alumnosFicheroNew = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(path))
                sw.WriteLine(alumnosFicheroNew);
        }

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
