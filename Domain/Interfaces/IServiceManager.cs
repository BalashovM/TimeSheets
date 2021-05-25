﻿using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    /// <summary>Менеджер запросов к данным по услуге</summary>
    interface IServiceManager :IManagerBase<Service,ServiceRequest>
    {
    }
}
