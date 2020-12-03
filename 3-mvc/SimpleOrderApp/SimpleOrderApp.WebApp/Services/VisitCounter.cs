using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleOrderApp.WebApp.Services
{
    public class VisitCounter
    {
        // should have better encapsulation
        public IDictionary<string, int> VisitCounts { get; set; } = new ConcurrentDictionary<string, int>();
    }
}
