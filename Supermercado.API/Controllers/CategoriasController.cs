using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Services;
using Supermercado.API.Exceptions;
using Supermercado.API.Exceptions.CategoriaException;

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
        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
   
            return await _categoriaService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(Guid id)
        {

            try
            {
                var categoria = await _categoriaService.GetByIdAsync(id);

                return Ok(categoria);
            }
            catch (ParametroInvalidoCategoriaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NaoEncontradoCategoriaException ex) 
            {
                return NotFound(ex.Message); 
            }
        }

        [HttpPost("")]
        public async Task<ActionResult> AddAsync([FromBody] Categoria categoria)
        {
            try
            {
                await _categoriaService.AddAsync(categoria);
                return Created("Criado com sucesso", categoria.Nome + " criado com sucesso!");   
            }
            catch (ParametroInvalidoCategoriaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExistenteCategoriaException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] Categoria categoria)
        {
            try
            {
                await _categoriaService.UpdateAsync(id, categoria);
                return Ok(categoria.Nome + " Atuzalido com sucesso");
            }
            catch (ParametroInvalidoCategoriaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NaoEncontradoCategoriaException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _categoriaService.RemoveAsync(id);
                return Ok("Removido com sucesso");
            }
            catch (ParametroInvalidoCategoriaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NaoEncontradoCategoriaException ex)
            {
                return NotFound(ex.Message);

            }
            
        }
    }
}
