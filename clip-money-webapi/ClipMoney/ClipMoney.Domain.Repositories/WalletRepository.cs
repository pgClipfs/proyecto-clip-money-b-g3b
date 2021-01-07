using ClipMoney.Domain.Models;
using ClipMoney.Persistence.EntityFramework.context;
using ClipMoney.Persistence.EntityFramework.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Domain.Repositories
{
    public class WalletRepository
    {
        private readonly BilleteraClipMoneyContext _context;
        public WalletRepository(BilleteraClipMoneyContext context)
        {
            _context = context;
        }
        public async Task<bool> PostEntry(TransferModel transactionNew)
        {
            var trs = new transaction {
            id_user = transactionNew.Id_user,
            amount = transactionNew.Amount,
            transaction_type = transactionNew.Transaction_type};

            await _context.AddAsync(trs);

            if(await _context.SaveChangesAsync() > 0)
            {
                var funds = await (from w in _context.wallet
                                   where w.id_user == transactionNew.Id_user
                                   select w).FirstOrDefaultAsync();
                var newAmount = funds.funds + transactionNew.Amount;
                funds.funds = newAmount;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveFounds(TransferModel transaction)
        {
            var funds = await (from w in _context.wallet
                          where w.id_user == transaction.Id_user
                          select w).FirstOrDefaultAsync();

            if(transaction.Amount < funds.funds)
            {
                var newAmount = funds.funds - transaction.Amount;
                funds.funds = newAmount;

                var trs = new transaction
                {
                    id_user = transaction.Id_user,
                    amount = transaction.Amount,
                    transaction_type = transaction.Transaction_type
                };
                await _context.AddAsync(trs);

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<double?>GetFoundsByUserId(int userId)
        {
            var funds = await (from w in _context.wallet
                               where w.id_user == userId
                               select w.funds).FirstOrDefaultAsync();
            return funds;
        }
    }
}
