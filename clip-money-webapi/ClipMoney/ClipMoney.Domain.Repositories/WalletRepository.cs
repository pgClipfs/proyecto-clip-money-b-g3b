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

        //public async Task<bool> TransferFounds(TransferModel transactionNew)
        //{
        //    var trs = new transaction
        //    {
        //        id_user = transactionNew.Id_user,
        //        amount = transactionNew.Amount,
        //        transaction_type = transactionNew.Transaction_type
        //    };
        //    await _context.AddAsync(trs);

        //    if (await _context.SaveChangesAsync() > 0)
        //    {
        //        var funds = await (from w in _context.wallet
        //                           where w.id_user == transactionNew.Id_user
        //                           select w).FirstOrDefaultAsync();
        //        var newAmount = funds.funds - transactionNew.Amount;
        //        funds.funds = newAmount;
        //    }

        //    var trsdt = new transaction
        //    {
        //        id_user = transactionNew.Id_user_recive,
        //        amount = transactionNew.Amount,
        //        transaction_type = 1003
        //    };

        //    await _context.AddAsync(trs);

        //    if (await _context.SaveChangesAsync() > 0)
        //    {
        //        var newfunds = await (from w in _context.wallet
        //                           where w.id_user == transactionNew.Id_user_recive
        //                           select w).FirstOrDefaultAsync();
        //        var newAmountRecive = newfunds.funds + transactionNew.Amount;
        //        newfunds.funds = newAmountRecive;
        //    }
        //    return await _context.SaveChangesAsync() > 0;
        //}

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

        public async Task<bool> TransferMoney(TransferMoneyModel transfer)
        {
            var trans = await (from userWallet in _context.wallet
                               where userWallet.cvu_count == transfer.Cvu
                               select userWallet).FirstOrDefaultAsync();

            var newAmount = trans.funds + transfer.Mount;
            trans.funds = newAmount;

            if(await _context.SaveChangesAsync() > 0)
            {
                var owner = await (from userOwner in _context.Usuarios
                                   join walletOwner in _context.wallet
                                   on userOwner.id equals walletOwner.id_user
                                   where userOwner.nombre_usuario == transfer.OwnerUser
                                   select walletOwner).FirstOrDefaultAsync();
                var newAmountOwner = owner.funds - transfer.Mount;
                owner.funds = newAmountOwner;

                var trs = new transaction
                {
                    id_user = (int)owner.id_user,
                    amount = transfer.Mount,
                    transaction_type = 1002
                };
                await _context.AddAsync(trs);

                var trsrecive = new transaction
                {
                    id_user = (int)trans.id_user,
                    amount = transfer.Mount,
                    transaction_type = 1003
                };
                await _context.AddAsync(trsrecive);

                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                return false;
            }
        }

        public async Task<UserTransferModel> GetUserByCvu(long cvu)
        {
            try
            {
                var user = await (from userWallet in _context.wallet
                                  join userCount in _context.Usuarios
                                  on userWallet.id_user equals userCount.id
                                  where userWallet.cvu_count == cvu
                                  select new UserTransferModel
                                  {
                                      NombreUsuario = userCount.nombre_usuario,
                                      Cvu = userWallet.cvu_count
                                  }).FirstAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
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
