using System.ComponentModel.DataAnnotations;

namespace PlataformaCursosOnline.Models;

public class Categorias
{
    /// Identificador da categoria
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome legível da categoria. Ex.: "Programação".
    /// </summary>
    [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
    [StringLength(20)]
    [Display(Name = "Categoria")]
    public string Nome { get; set; } = ""; // <=> string.Empty;
    
    
    /* **********************
     * Relacionamentos 1-N
     * ******************** */
    public ICollection<Cursos> Cursos { get; set; } = new List<Cursos>();
}