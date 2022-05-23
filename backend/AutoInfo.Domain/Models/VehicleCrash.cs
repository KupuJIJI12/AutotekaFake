using System;
using System.Collections.Generic;

namespace AutoInfo.Domain.Models
{
    public class VehicleCrash<TDamage>
        where TDamage: VehicleDamage
    {
        public DateTime Date { get; set; }

        //public CrashType Type { get; set; }
        public string Type { get; set; } = "Столкновение";

        public IEnumerable<TDamage> VehicleDamages { get; set; }
    }
}