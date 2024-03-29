﻿using App.Contracts.DAL;
using Base.Contracts.BLL;

namespace App.Contracts.BLL.Services;

public interface IPaymentTypeService : IEntityService<App.BLL.DTO.PaymentType>, IPaymentTypeRepositoryCustom<App.BLL.DTO.PaymentType>
{
    
}