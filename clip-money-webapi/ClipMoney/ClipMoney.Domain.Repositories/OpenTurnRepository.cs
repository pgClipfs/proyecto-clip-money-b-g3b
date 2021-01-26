using ClipMoney.Domain.Models;
using ClipMoney.Persistence.EntityFramework.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Domain.Repositories
{
    public class OpenTurnRepository
    {
        private readonly BilleteraClipMoneyContext _context;

        public OpenTurnRepository(BilleteraClipMoneyContext context)
        {
            _context = context;
        }

        public async Task<OpenTurnModel> GetByUserId(int idUser)
        {
            try
            {
                var trans = await (from ot in _context.giro_descubierto
                                   where ot.id_user == idUser
                                   select new OpenTurnModel {
                                     Id = ot.id,
                                     Id_user = ot.id_user,
                                     Amount = ot.amount,
                                     Balance = ot.balance}).FirstOrDefaultAsync();
                return trans;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}