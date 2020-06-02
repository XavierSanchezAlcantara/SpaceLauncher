using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceLauncher.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model.Tests
{
    [TestClass()]
    public class juegoTests
    {
        [TestMethod()]
        public void CalcularTiempo()
        {
            var instancia = new tiempoJugado();
            var segundos = instancia.CalcularTiempo(20);
            Assert.AreEqual(segundos,"0:0:20");
            var segundos2 = instancia.CalcularTiempo(140);
            Assert.AreEqual(segundos2, "0:2:20");
        }
        [TestMethod()]
        public void CalcularTiempo2()
        {
            var instancia = new tiempoJugado();
            var segundos = instancia.calcularTiempo2("0", "0", "20");
            Assert.AreEqual(segundos, "20");
            var segundos2 = instancia.calcularTiempo2("0", "2", "20");
            Assert.AreEqual(segundos2, "140");
        }
        public void provaUsuari()
        {
            var instancia = new usuari("xavi","xavi@gmail.com","Admin1234","2019/12/28","M");
            var segundos = instancia.ComprobarFormatoEmail(instancia.Email);
            Assert.AreEqual(segundos, true);
        }
    }
}