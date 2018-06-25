
using System;
using System.Collections.Generic;
using Xunit;

namespace AppAlumno.Tests
{
    public class Form1Tests
    {
        IAppAlumno alumno = new Form1();

        [Fact]
        public void RegistrarTest()
        {
            string path = @".\alumnosJson.txt";

            List<Alumno> listaAlumnos = Funciones.getJson(path);
            Alumno al = Funciones.RecogeDato(path, 1, "asd", "asd", "aaa");
            alumno.Registrar(al);
            Assert.True(al.Equals(listaAlumnos[listaAlumnos.Count - 1]));
        }
    }
}