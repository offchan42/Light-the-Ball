using System;

namespace Assets.Scripts.Gates
{
    public class NotGate : OnAbleGate { 

        public override bool FeedInput(IOnAble a, IOnAble b)
        {
            if (b != null)
            {
                throw new ArgumentException("Not gate works only with one input");
            }
            return !a.IsOn();
        }
    }
}
