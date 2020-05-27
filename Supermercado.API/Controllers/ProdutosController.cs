using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado.API.Domain.Services;
using Supermercado.API.Domain.Models;
using System.Runtime.CompilerServices;
using Supermercado.API.Exceptions.ProdutoException;

namespace Supermercado.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProdutosController: Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService) 
        {
            _produtoService = produtoService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Produto>> ListAsync() {
            return await _produtoService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetByIdAsync(Guid id)
        {
            try
            {
                Produto produto = await _produtoService.GetByIdAsync(id);
                return Ok(produto);
            }
            catch (ParametroInvalidoProdutoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NaoEncontradoProdutoException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<ActionResult> AddAsync([FromBody] Produto produto) 
        {
            try
            {
                await _produtoService.AddAsync(produto);
                return Created("Criado com sucesso", produto.Nome + " criado com sucesso!");
            }
            catch (ParametroInvalidoProdutoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExistenteProdutoException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateAsync([FromBody] Produto produto)
        {
            try
            {
                await _produtoService.UpdateAsync(produto);
                return Ok(produto.Nome + " Atuzalido com sucesso");
            }
            catch (ParametroInvalidoProdutoException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (NaoEncontradoProdutoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(Guid id) 
        {
            try
            {
                await _produtoService.RemoveAsync(id);
                return Ok("Removido com sucesso");
            }
            catch (ParametroInvalidoProdutoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NaoEncontradoProdutoException ex) 
            {
                return NotFound(ex.Message);
            }
        }
    }
}
