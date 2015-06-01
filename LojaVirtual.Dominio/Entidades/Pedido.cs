using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        

       
        [Required(ErrorMessage = "Informe Seu Nome")]
        [Display(Name = "Nome Do Cliente:")]
        public string NomeCliente { get; set; }
      



        
       
        [Display(Name = "CEP:")]
        public string CEP { get; set; }



       
      
        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Informe Seu Endereço")]
        public string Endereco { get; set; }

        
        
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }
        

        
        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Informe Seu Cidade")]
        public string Cidade { get; set; }

      
       
        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Informe Seu Bairro")]
        public string Bairro { get; set; }

       
         [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Informe Seu Estado")]
        public string Estado { get; set; }
        
        
        [Display(Name = "E-Mail:")]
        [Required(ErrorMessage = "Informe Seu E-Mail")]
        [EmailAddress(ErrorMessage = "E-mail Ínvalido")]
         public string Email { get; set; }
        
       
        [Display(Name = "Embrulha Para Presente")]
        public bool EmbrulhaPresente { get; set; }




    }
}
