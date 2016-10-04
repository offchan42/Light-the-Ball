namespace Assets.Scripts.Gates
{
    public abstract class OnAbleGate : OnAbleObject
    {
        protected OnAbleSocket input1Socket;
        protected OnAbleSocket input2Socket;
        protected OnAbleSocket outputSocket;
        protected bool binary;

        protected virtual void Awake()
        {
            input1Socket = transform.Find("Input1Socket").GetComponent<OnAbleSocket>();
            var find2 = transform.Find("Input2Socket");
            if (find2 != null)
            {
                input2Socket = find2.GetComponent<OnAbleSocket>();
            }
            binary = find2 != null;
            outputSocket = transform.Find("OutputSocket").GetComponent<OnAbleSocket>();
        }

        public override void SetOn(bool isOn)
        {
            base.SetOn(FeedInput(input1Socket, input2Socket));
        }

        public abstract bool FeedInput(IOnAble a, IOnAble b);
    }
}