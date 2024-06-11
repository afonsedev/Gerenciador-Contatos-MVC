using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleContatos.Models
{

    [Table("Contato")]
    public class ContatoModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }



        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Não deixe o nome em branco.")]
        public string Nome { get; set; }



        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Não deixe o e-mail em branco.")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido")]
        public string Email { get; set; }


        [Column("Celular")]
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Não deixe o número em branco.")]
        [Phone(ErrorMessage ="O número informado não é válido.")]
        public string Celular { get; set; }
    }
}