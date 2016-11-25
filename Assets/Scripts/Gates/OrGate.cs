namespace Assets.Scripts.Gates
{
    public class OrGate : OnAbleGate {
        public override bool GetOutput(IOnAble a, IOnAble b)
        {
            return a.IsOn() | b.IsOn();
        }
    }
}
