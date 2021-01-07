using ClipMoney.Domain.Models;
using ClipMoney.Persistence.EntityFramework.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Domain.Repositories
{
    public class TransferRepository
    {
        private readonly BilleteraClipMoneyContext _context;

        public TransferRepository(BilleteraClipMoneyContext context)
        {
            _context = context;
        }

        public async Task<List<TransferModel>> GetTransactionsByIdUser(int idUser)
        {
            var trsList = await (from trs in _context.transaction
                                 where trs.id_user == idUser
                                 orderby trs.id descending
                                 select new TransferModel
                                 {
                                     Amount = trs.amount,
                                     Transaction_type = trs.transaction_type
                                 }).ToListAsync();
            return trsList;
        }
    }
}