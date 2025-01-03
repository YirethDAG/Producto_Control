using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Prueba_Control.Models;

namespace Prueba_Control.Controllers
{
    public class ImagenesproductoesController : Controller
    {
        private readonly PruebaProductosContext _context;
        public const string UPLOADS_FOLDER = @"c:\temp";

        public ImagenesproductoesController(PruebaProductosContext context)
        {
            _context = context;
        }

        // GET: Imagenesproductoes
        public async Task<IActionResult> Index()
        {
            var pruebaProductosContext = _context.Imagenesproductos.Include(i => i.IdProductoNavigation);
            return View(await pruebaProductosContext.ToListAsync());
        }

        // GET: Imagenesproductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesproducto = await _context.Imagenesproductos
                .Include(i => i.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdImagenesProductos == id);
            if (imagenesproducto == null)
            {
                return NotFound();
            }

            return View(imagenesproducto);
        }

        // GET: Imagenesproductoes/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: Imagenesproductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImagenesProductos,Nombre,Estado,ImagenExt,IdProducto")] Imagenesproducto imagenesproducto, IFormFile file)
        {
            try
            {
                if (true)
                {

                    #region img

                    if (file == null || file.Length == 0)
                    {
                        return BadRequest("No se proporcionó ningún archivo o el archivo está vacío.");
                    }

                    using var memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    var base64String = Convert.ToBase64String(fileBytes);

                    // Convertir Base64 a bytes
                    //var convertirba64 = Convert.FromBase64String(file.);

                    #endregion

                    imagenesproducto.Nombre = file.FileName;
                    //imagenesproducto.Nombre = convertirba64;
                    imagenesproducto.Estado = true;
                    imagenesproducto.ImagenExt = base64String;


                    _context.Add(imagenesproducto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", imagenesproducto.IdProducto);
                return View(imagenesproducto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar el archivo: {ex.Message}");
            }           
        }

        // GET: Imagenesproductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesproducto = await _context.Imagenesproductos.FindAsync(id);
            if (imagenesproducto == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", imagenesproducto.IdProducto);
            return View(imagenesproducto);
        }

        // POST: Imagenesproductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImagenesProductos,Nombre,Estado,ImagenExt,IdProducto")] Imagenesproducto imagenesproducto)
        {
            if (id != imagenesproducto.IdImagenesProductos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagenesproducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagenesproductoExists(imagenesproducto.IdImagenesProductos))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", imagenesproducto.IdProducto);
            return View(imagenesproducto);
        }

        // GET: Imagenesproductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesproducto = await _context.Imagenesproductos
                .Include(i => i.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdImagenesProductos == id);
            if (imagenesproducto == null)
            {
                return NotFound();
            }

            return View(imagenesproducto);
        }

        // POST: Imagenesproductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagenesproducto = await _context.Imagenesproductos.FindAsync(id);
            if (imagenesproducto != null)
            {
                _context.Imagenesproductos.Remove(imagenesproducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagenesproductoExists(int id)
        {
            return _context.Imagenesproductos.Any(e => e.IdImagenesProductos == id);
        }

        public IActionResult CreatePro()
        {
            return View("create_pro");
        }



    }
}
