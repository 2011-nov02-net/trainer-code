using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public interface IAnimal
    {
        int LegCount { get; }
        bool CanSwim { get; }
        double Height { get; }
    }
}
