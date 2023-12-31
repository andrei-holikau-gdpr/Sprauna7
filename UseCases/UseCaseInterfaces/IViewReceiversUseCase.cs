﻿using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewReceiversUseCase
    {
        IEnumerable<Receiver> Execute();
    }
}