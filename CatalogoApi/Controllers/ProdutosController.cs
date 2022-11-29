using CatalogoApi.Context;
using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos?.AsNoTracking().ToList();

                if (produtos is null)
                    return NotFound();

                return produtos;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }


            
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos?.AsNoTracking().FirstOrDefault(x => x.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não encontrado !");

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos?.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("O ID do produto informado deve ser o mesmo do que será alterado ! ");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);

        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não localizado !");

            _context.Produtos?.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
