
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Dominio.Entidades
{
    public class Administrador
    {

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [DisplayName("Login:")]
        [Required(ErrorMessage="Login é Obrigatorio")]
        public string Login { get; set; }
        [StringLength(50)]
        [DisplayName("Senha:")]
        [Required(ErrorMessage = "Senha é Obrigatorio")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get;  set; }
    }
}
