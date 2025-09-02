using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PlataformaCursosOnline.Models;

public class Inscricoes
{
    /// <summary>
    /// Identificador da inscrição.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /* ***************
     * Relacionamento com Curso (N:1 do ponto de vista da inscrição)
     * *************** */

    /// <summary>
    /// FK para o curso a que o utilizador se inscreve.
    /// </summary>
    [Display(Name = "Curso")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecione um {0} válido")]
    [ForeignKey(nameof(Curso))]
    public int CursoFK { get; set; }

    /// <summary>
    /// Navegação para o curso (não validar no binding).
    /// </summary>
    [ValidateNever]
    public Cursos Curso { get; set; }

    /* ***************
     * Relacionamento com Utilizador (Identity)
     * *************** */

    /// <summary>
    /// FK para o utilizador (Id do IdentityUser).
    /// </summary>
    [Display(Name = "Utilizador")]
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [ForeignKey(nameof(Utilizador))]
    public string UtilizadorFK { get; set; } = null!;

    /// <summary>
    /// Navegação para o utilizador (Identity).
    /// </summary>
    [ValidateNever]
    public Utilizadores Utilizador { get; set; }

    /// <summary>
    /// Data/hora da inscrição (UTC).
    /// </summary>
    [Display(Name = "Data de inscrição")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataInscricao { get; set; } = DateTime.UtcNow;
}