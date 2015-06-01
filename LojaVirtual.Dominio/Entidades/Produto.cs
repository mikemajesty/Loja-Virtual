
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
       

        [HiddenInput(DisplayValue=false)]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage="Nome é Obrigatorio!")]
        [DisplayName("Nome Do Produto:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição é Obrigatorio!")]
          [DisplayName("Descrição Do Produto:")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
      /*  [RegularExpression(@"/^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/", ErrorMessage = "{0} Deve ser um numero!.")]*/
        [RegularExpression(@"^[-+]?([0-9]*\,[0-9]+|[0-9]+)$", ErrorMessage = "{0} Deve ser um numero!.")]
        [Range(0.01,double.MaxValue,ErrorMessage="Valor não é Valido")]
        [Required(ErrorMessage = "Preço é Obrigatorio!")]
         [DisplayName("Preço Do Produto:")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Categoria é Obrigatorio!")]
          [DisplayName("Categoria(s) Do Produto:")]
        public string Categoria { get; set; }

        [HiddenInput(DisplayValue=false)]
        public byte[] Imagem { get; set; }
          [HiddenInput(DisplayValue = false)]
        public string ImagemMimeType { get; set; }



        
    }
}
