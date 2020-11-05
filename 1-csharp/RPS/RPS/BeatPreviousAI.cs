using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    public class BeatPreviousAI : IAI
    {
        public string ChooseRPS(string lastPlay)
        {
            return lastPlay switch
            {
                "r" => "p",
                "p" => "s",
                _ => "r",
            };
        }
    }
}
