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
    public class AlumnoRepository : IALumnoRepository
    {       
        public static string path = @".\alumnosJson.json";

        public Alumno Registrar(Alumno alum)
        {
            try
            {
                if (!File.Exists(path))
                    NewFileJson(alum);
                else
                    AddAlumnoToJson(alum);
            }
            catch (JsonException e)
            {
                Console.WriteLine("Ha ocurrido un problema con el fichero.");
                Console.WriteLine(e.Message);
            }
            return alum;
        }

        public static void NewFileJson(Alumno alum)
        {
            //List<Alumno> listaAlumno = new List<Alumno> { alum };
            string alumJson = JsonConvert.SerializeObject(alum, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(path))
                sw.WriteLine(alumJson);
        }

        public static void AddAlumnoToJson(Alumno alum)//tiene que devolver el alumno
            //este metodo tiene que ser heredada de una interfaz(esta interface se 
            //instanciará en el testing con referencia Alumnos)
        {
            List<Alumno> listaAlumno;

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
    }
}
