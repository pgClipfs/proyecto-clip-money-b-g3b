﻿using ClipMoney.Domain.Models;
using ClipMoney.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.Application.BusinessLogics
{
    public class WalletBussinesLogic
    {
        private readonly WalletRepository _walletRepository;
        public WalletBussinesLogic(WalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<bool> Post(TransferModel transaction)
        {
            //var result = await _walletRepository.PostEntry(transaction);

            if (transaction.Transaction_type == 1)
            {
                var result = await _walletRepository.PostEntry(transaction);
                return result;
            }
            else
            {
                var result = await _walletRepository.RemoveFounds(transaction);
                return result;
            }
        }

        public async Task<double?>GetFundsByUserId(int userId)
        {
            if( userId <= 0)
            {
                return null;
            }
            var result = await _walletRepository.GetFoundsByUserId(userId);

            return result;
        }

        public async Task<UserTransferModel> GetUserByCvu(long cvu)
        {
            try
            {
                if (cvu <= 0)
                {
                    return null;
                }
                var result = await _walletRepository.GetUserByCvu(cvu);
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> TransferMoney(TransferMoneyModel transfer)
        {
            if (transfer.Cvu <= 0)
            {
                return false;
            }
            var result = await _walletRepository.TransferMoney(transfer);

            return result;
        }
    }
}
