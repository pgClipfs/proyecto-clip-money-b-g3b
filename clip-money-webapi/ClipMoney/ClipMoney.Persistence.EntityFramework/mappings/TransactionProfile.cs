using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ClipMoney.Persistence.EntityFramework.entities;

namespace ClipMoney.Persistence.EntityFramework.mappings
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransferModel, transaction>();
            CreateMap<transaction, TransferModel>();
        }
    }
}