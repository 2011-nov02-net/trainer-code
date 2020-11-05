using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RPS
{
    public class Score
    {
        public event Action WinHappened;
        // tracks win, loss, and ties

        [JsonPropertyName("wins")]
        public int winCount { get; set; } = 0;

        [JsonPropertyName("losses")]
        public int lossCount { get; set; } = 0;

        [JsonIgnore]
        public int tieCount { get; set; } = 0;

        // methods to increment scores
        public void winSet()
        {
            winCount++;
            //WinHappened(); // you fire events like this, calling them like functions
            // that will call every subscribed delegate with the parameters.

            // but you can't do it that way, because if there are no subscribers, the event is null.
            WinHappened?.Invoke(); // ?. is like . if the thing to the left isn't null. but if it is, it just does nothing.
        }
        public void loseSet()
        {
            lossCount++;
        }       
        public void tieSet()
        {
            tieCount++;
        }
    }
}
