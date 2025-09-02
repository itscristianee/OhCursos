using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    /// <summary>
    /// tabela Utilizadores
    /// </summary>
    public DbSet<Utilizadores> Utilizadores { get; set; }
    
    /// <summary>
    /// tabela Categorias na BD
    /// </summary>
    public DbSet<Categorias> Categorias { get; set; }
    
    /// <summary>
    /// tabela Categorias na BD
    /// </summary>
    public DbSet<Cursos> Cursos { get; set; }
    
    /// <summary>
    /// tabela Categorias na BD
    /// </summary>
    public DbSet<Inscricoes> Inscricoes { get; set; }
    
    
    
    
}