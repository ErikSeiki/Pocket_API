using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Services;

namespace Supermercado.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService) 
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAllAsync()
        {
            var categorias = await _categoriaService.ListAsync();
            return Ok(categorias);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            
            //return StatusCode(305, "");

            if (categoria == null)
                return NotFound("Nenhuma categoria encontrada");

            return Ok(categoria);
        }

        [HttpPost("")]
        public async Task<ActionResult> AddAsync([FromBody] Categoria categoria)
        {
            await _categoriaService.AddAsync(categoria);

            return Created("Criado com sucesso", categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove( int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            
            if (categoria == null) 
                return NotFound("Nenhuma categoria encontrada");

            _categoriaService.Remove(categoria);

            return Ok("Removido com sucesso");
        }


        [HttpPut("")]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            _categoriaService.Update(categoria);

            return Ok("Atuzalido com sucesso");
        }
    }
}
