using Microsoft.EntityFrameworkCore.Query.Internal;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using Supermercado.API.Domain.Services;
using Supermercado.API.Exceptions;
using Supermercado.API.Exceptions.CategoriaException;
using Supermercado.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Supermercado.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private const string parametro_invalido_menssagem = "Parametro Invalido";
        private const string categoria_existente_menssagem = "Categoria Já Existe";
        private const string nenhuma_categoria_encontrada_menssagem = "Nenhuma Categoria Encontrada";

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _categoriaRepository.ListAsync();
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw new ParametroInvalidoCategoriaException(parametro_invalido_menssagem);

            Categoria categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria.IsValid())
                throw new NaoEncontradoCategoriaException(nenhuma_categoria_encontrada_menssagem+ " "+ id.ToString());

            return categoria;
        }

        public async Task<Categoria> AddAsync(Categoria categoria)
        {
            if (categoria.IsValid())
                throw new ParametroInvalidoCategoriaException(parametro_invalido_menssagem);

            Categoria categoriaExistente = await _categoriaRepository.GetByIdAsync(categoria.Id);

            if (!categoriaExistente.IsValid())
                throw new ExistenteCategoriaException(categoria_existente_menssagem);

            await _categoriaRepository.AddAsync(categoria);

            return categoria;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            if (categoria.IsValid() || categoria.Id.Equals(Guid.Empty))
                throw new ParametroInvalidoCategoriaException(parametro_invalido_menssagem);
            
            await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task RemoveAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw new ParametroInvalidoCategoriaException(parametro_invalido_menssagem);

            Categoria categoriaExistente = await _categoriaRepository.GetByIdAsync(id);

            if (categoriaExistente.IsValid())
                throw new NaoEncontradoCategoriaException(nenhuma_categoria_encontrada_menssagem);

            await _categoriaRepository.RemoveAsync(categoriaExistente);
        }
    }
}