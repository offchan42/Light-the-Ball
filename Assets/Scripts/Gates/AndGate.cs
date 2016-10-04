namespace Assets.Scripts.Gates
{
    public class AndGate : OnAbleGate {
        public override bool FeedInput(IOnAble a, IOnAble b)
        {
            return a.IsOn() & b.IsOn();
        }
    }
}
