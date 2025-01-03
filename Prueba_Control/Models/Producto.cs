using System;
using System.Collections.Generic;

namespace Prueba_Control.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Imagenesproducto> Imagenesproductos { get; set; } = new List<Imagenesproducto>();
}
