using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Este data annotation indica que el campo es obligatorio.
        [Display(Name="Nombre de la Categoría")]//Me sirve para personalizar el nombre que se muestra en las vistas o mensajes de error
        public string Name { get; set; }
    }
}

