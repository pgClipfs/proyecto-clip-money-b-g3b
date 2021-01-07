using ClipMoney.Domain.Models;
using ClipMoney.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.Application.BusinessLogics
{
    public class TransferBussinesLogic
    {
        private readonly TransferRepository _transferRepository;
        public TransferBussinesLogic(TransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<List<TransferModel>> GetByIdUser(int idUser)
        {
            if(idUser <= 0)
            {
                return null;
            }
            var result = await _transferRepository.GetTransactionsByIdUser(idUser);
            return result;
        }
    }
}