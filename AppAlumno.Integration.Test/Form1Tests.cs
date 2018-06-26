
using System;
using System.Collections.Generic;
using Xunit;
using 

namespace AppAlumno.Tests
{
    public class Form1Tests
    {
        IALumnoRepository alumno = new Form1();

        [Fact]
        public void RegistrarTest()
        {
            string path = @".\alumnosJson.json";

            List<Alumno> listaAlumnos = getJson(path);
            Alumno al = RecogeDato(path, 1, "asd", "asd", "aaa");
            alumno.Registrar(al);
            Assert.True(al.Equals(listaAlumnos[listaAlumnos.Count - 1]));
        }
    }
}