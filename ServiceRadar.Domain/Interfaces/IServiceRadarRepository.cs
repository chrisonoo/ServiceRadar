using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Domain.Interfaces;
public interface IServiceRadarRepository
{
    Task Create(Workshop workshop);
}
