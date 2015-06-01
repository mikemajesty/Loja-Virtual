
using System;

namespace LojaVirtual.Web.Models
{
    public class Paginacao
    {
        private int itemsTotal;
        public int ItemsTotal
        {
            get { return itemsTotal; }
            set { itemsTotal = value; }
        }
        private int itensPorPagina;
        public int ItemsPorPagina
        {
            get { return itensPorPagina; }
            set { itensPorPagina = value; }
        }
        private int paginaAtual;
        public int PaginaAtual
        {
            get { return paginaAtual; }
            set { paginaAtual = value; }
        }
       
        public int TotalPagina
        {
            get 
            {
                return (int)Math.Ceiling((decimal)itemsTotal / itensPorPagina);
            }
            
        }


    }
}