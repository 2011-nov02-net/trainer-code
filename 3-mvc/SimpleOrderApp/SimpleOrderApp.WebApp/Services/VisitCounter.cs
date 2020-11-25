using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrderApp.WebApp.Services
{
    public class VisitCounter
    {
        // should have better encapsulation
        public IDictionary<string, int> VisitCounts { get; set; } = new ConcurrentDictionary<string, int>();
    }
}
