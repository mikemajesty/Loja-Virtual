using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Repositorio
{
    
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext banco = new EfDbContext();

        public Administrador getAdmin(Administrador admin)
        {
            return banco.Administradores.FirstOrDefault(a=>a.Login == admin.Login);
        }
    }
}
