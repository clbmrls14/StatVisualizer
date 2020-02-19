using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsVisualizer.Models
{
    public class Contestant
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public DateTime LastSeen { get; set; }

        public int? GenerationsComputed { get; set; }

        public DateTime? StartedGameAt { get; set; }

        public DateTime? EndedGameAt { get; set; }

        //public TimeSpan? Elapsed { get; set; }
        public TimeSpan? Elapsed
        {
            get
            {
                if (StartedGameAt == null || EndedGameAt == null)
                {
                    return TimeSpan.MaxValue;
                }
                return EndedGameAt - StartedGameAt;
            }
        }

        public object FinalBoard { get; set; }

        public bool? CorrectFinalBoard { get; set; }

        
    }
    public class Stats
    {
        public IEnumerable<Contestant> Contestants { get; set; }
    }
}
