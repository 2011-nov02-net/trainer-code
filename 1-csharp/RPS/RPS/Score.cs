using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    public class Score
    {
        public event Action WinHappened;
        // tracks win, loss, and ties

        public int winCount = 0;
        public int lossCount = 0;
        public int tieCount = 0;

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
