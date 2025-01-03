using System;
using System.Collections.Generic;

namespace Prueba_Control.Models;

public partial class Imagenesproducto
{
    public int IdImagenesProductos { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public string ImagenExt { get; set; } = null!;

    public int IdProducto { get; set; }
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
