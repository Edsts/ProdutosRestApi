using CatalogoApi.Context;
using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get() 
        {
            var categorias = _context.Categorias?.AsNoTracking().ToList();

            if (categorias is null)
                return NotFound("Nenhuma categoria encontrada");

            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias?.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
                return NotFound("Categora não encontrada");

            return Ok(categoria);
        }

        [HttpGet]
        [Route("Produtos")]
        public ActionResult<IEnumerable<Produto>> GetCategoriasComProdutos()
        {
            var categorias = _context.Categorias?.AsNoTracking().Include(c => c.Produtos).ToList();

            if (categorias is null)
                return NotFound("Nenhuma categoria encontrada");

            return Ok(categorias);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest("Categoria não informada");

            _context.Categorias?.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (categoria is null)
                return BadRequest("Informe a categoria para alteração");

            var categoriaLocalizada = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == id);

            if (categoriaLocalizada is null)
                return BadRequest("Categoria não localizada");

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
                return NotFound("Categoria não encontrada");

            _context.Categorias?.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}
