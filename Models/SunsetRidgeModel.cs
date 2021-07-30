using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCChallenges.Models
{
    public class SunsetRidgeModel
    {
        public List<int> DefaultData { get; set; } = new();
        public List<int> CustomData { get; set; } = new();
        public List<int> DarkData { get; set; } = new();
        public List<int> LightData { get; set; } = new();
        public bool PopModal { get; set; } = false;
    }
}