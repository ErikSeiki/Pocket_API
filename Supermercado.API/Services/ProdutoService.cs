using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using Supermercado.API.Domain.Services;
using Supermercado.API.Exceptions.ProdutoException;
using Supermercado.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private const string parametro_invalido_menssagem = "Parametro Invalido";
        private const string produto_existente_menssagem = "Produto Já Existe";
        private const string nenhum_produto_encontrado_menssagem = "Nenhum Produto Encontrado";


        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _produtoRepository.ListAsync();
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw new ParametroInvalidoProdutoException(parametro_invalido_menssagem);

            Produto produto = await _produtoRepository.GetByIdAsync(id);

            if (produto.IsValid())
                throw new NaoEncontradoProdutoException(nenhum_produto_encontrado_menssagem);

            return produto;
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            if (produto.IsValid())
                throw new ParametroInvalidoProdutoException(parametro_invalido_menssagem);

            Produto produtoExistente = await _produtoRepository.GetByIdAsync(produto.Id);

            if (!produtoExistente.IsValid())
                throw new ExistenteProdutoException(produto_existente_menssagem);

            await _produtoRepository.AddAsync(produto);
            
            return produto;
        }

        public async Task UpdateAsync(Produto produto)
        {
            if (produto.IsValid() || produto.Id.Equals(Guid.Empty))
                throw new ParametroInvalidoProdutoException(parametro_invalido_menssagem);

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task RemoveAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw new ParametroInvalidoProdutoException(parametro_invalido_menssagem);

            Produto produtoExistente = await _produtoRepository.GetByIdAsync(id);

            if (produtoExistente.IsValid())
                throw new NaoEncontradoProdutoException(nenhum_produto_encontrado_menssagem);

            await _produtoRepository.RemoveAsync(produtoExistente);
        }
    }
}
