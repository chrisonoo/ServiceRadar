﻿using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Domain.Interfaces;
public interface IServiceRadarRepository
{
    Task Create(Workshop workshop);
}
