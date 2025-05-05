using NcmAPI.Domain.Interfaces;
using NcmAPI.Domain.ValueObjects;
using NcmAPI.Domain.Exceptions;
using NcmAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NcmAPI.Application.Interfaces;

namespace NcmAPI.Application.Services
{
    public class NcmService : INcmQueryService
    {
        private readonly IOldNcmRepository _oldRepo;
        private readonly INewNcmRepository _newRepo;
        private readonly IUnitOfWork _uow;

        public NcmService(
            IOldNcmRepository oldRepo,
            INewNcmRepository newRepo,
            IUnitOfWork uow)
        {
            _oldRepo = oldRepo;
            _newRepo = newRepo;
            _uow = uow;
        }

      

        public async Task CreateNewNcmAsync(int oldId, string newCode)
        {
            await _uow.BeginTransactionAsync();
            try
            {
              
                var old = await _oldRepo.GetByIdAsync(oldId);
                if (old == null)
                    throw new DomainException($"OldNcm de Id {oldId} não encontrado.");

                var codeVo = new NcmCode(newCode);
                old.CreateNew(codeVo);

                await _uow.CommitAsync();
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }


        /// <summary>
        /// Retorna os códigos de NewNcm associados ao OldNcm informado.
        /// </summary>
        public async Task<IEnumerable<NewNcmDto>> GetNewNcmsByOldCodeAsync(string oldCode)
        {
            // Validação de entrada
            var codeVo = new NcmCode(oldCode);

            Console.WriteLine(oldCode);
            Console.WriteLine(codeVo.Value);

            // Busca o OldNcm
            var old = await _oldRepo.GetByCodeAsync(codeVo.Value);

            if (old is null)
                throw new DomainException($"OldNcm com código '{oldCode}' não encontrado.");

            // Busca os NewNcm relacionados
            var news = await _newRepo.GetByOldIdAsync(old.Id);

            // Map para DTO
            return news.Select(n => new NewNcmDto(n.Id, n.Code.Value));
        }
    }
}
