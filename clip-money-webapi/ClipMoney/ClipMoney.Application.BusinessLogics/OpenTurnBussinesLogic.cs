using ClipMoney.Domain.Models;
using ClipMoney.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.Application.BusinessLogics
{
    public class OpenTurnBussinesLogic
    {
        private readonly OpenTurnRepository _openTurnRepository;
        public OpenTurnBussinesLogic(OpenTurnRepository openTurnRepository)
        {
            _openTurnRepository = openTurnRepository;
        }

        public async Task<OpenTurnModel> GetByUserId(int idUser)
        {
            try
            {
                if (idUser <= 0)
                    return null;
                var result = await _openTurnRepository.GetByUserId(idUser);
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}