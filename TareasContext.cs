using ApisConPuntoNet.Models;
using Microsoft.EntityFrameworkCore;


public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();

        categoriasInit.Add(new Categoria(){
            CategoriaId = Guid.Parse("4099b102-df96-4528-bf1d-a6edc76821f3"),
            Nombre = "Actividades pendientes",
            Peso = 20
        });

        categoriasInit.Add(new Categoria(){
            CategoriaId = Guid.Parse("4099b102-df96-4528-bf1d-a6edc76821f4"),
            Nombre = "Actividades personales",
            Peso = 50
        });



        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);
            categoria.HasData(categoriasInit);
        });


        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("4099b102-df96-4528-bf1d-a6edc76821f1"),
            CategoriaId = Guid.Parse("4099b102-df96-4528-bf1d-a6edc7682145"),
            PrioridadTarea =Prioridad.Media,
            Titulo ="Pago Sevicios Publicos",
            FechaCreacion = DateTime.Now
        });

      
        modelBuilder.Entity<Tarea>(tarea=> 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId); 
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.Estado).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.Property(p => p.Compuesta); 

            tarea.HasData(tareasInit);
        });

    }
}