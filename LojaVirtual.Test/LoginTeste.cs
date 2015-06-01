using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
namespace LojaVirtual.Test
{
    [TestClass]
    public class LoginTeste
    {
        [TestMethod]
        public void Logar()
        {
            AdministradoresRepositorio rep = new AdministradoresRepositorio();

            Administrador admin = new Administrador
            {
                 Login = "admin",
                  Senha = "admin"
            };

            Assert.AreEqual(rep.getAdmin(admin),new Administrador());

        }
    }
}
