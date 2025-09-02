using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PlataformaCursosOnline.Models;

public class Cursos
{
    /// <summary>
    /// Identificador do curso.
    /// </summary>
    [Key] 
    public int Id { get; set; }

    /// <summary>
    /// Título do curso (visível nas listas e detalhes).
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição curta do curso (objetivos, conteúdo, etc.).
    /// </summary>
    [StringLength(2000, ErrorMessage = "A {0} não pode ter mais de {1} caracteres")]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    /// <summary>
    /// imagem de capa (opcional).
    /// </summary>
    [Display(Name = "Capa ")]
    public string? Capa { get; set; }

    /// <summary>
    /// Data de criação do registo (UTC).
    /// </summary>
    [Display(Name = "Data de criação")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    /* **********************
     * Relacionamentos N-1
     * ******************** */

    /// <summary>
    /// FK para a Categoria.
    /// </summary>
    [Display(Name = "Categoria")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecione uma {0} válida")]
    [ForeignKey(nameof(Categoria))]
    public int CategoriaFK { get; set; }

    /// <summary>
    /// Navegação para a Categoria (não validar no binding).
    /// </summary>
    [ValidateNever]
    public Categorias Categoria { get; set; }
    
    
    /// <summary>
    /// FK para Formador (dono).
    /// </summary>
    [Display(Name = "Formador")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecione uma {0} válida")]
    [ForeignKey(nameof(Formador))]
    public string FormadorFK { get; set; }
    
    /// <summary>
    /// Navegação para o Formador (não validar no binding).
    /// </summary>
    [ValidateNever]
    public Utilizadores Formador { get; set; }
    
    
    public ICollection<Inscricoes> Inscricoes { get; set; } = new List<Inscricoes>();
}