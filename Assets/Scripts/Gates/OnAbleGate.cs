using UnityEngine;

namespace Assets.Scripts.Gates
{
    public abstract class OnAbleGate : OnAbleObject
    {
        protected OnAbleSocket input1Socket;
        protected OnAbleSocket input2Socket;
        protected OnAbleSocket outputSocket;
        protected bool binary;

        public override void SetOn(bool isOn)
        {
            base.SetOn(GetOutput(input1Socket, input2Socket));
        }

        protected virtual void Awake()
        {
            input1Socket = transform.Find("Input1Socket").GetComponent<OnAbleSocket>();
            Transform find2 = transform.Find("Input2Socket");
            if (find2 != null)
            {
                input2Socket = find2.GetComponent<OnAbleSocket>();
            }
            binary = find2 != null;
            outputSocket = transform.Find("OutputSocket").GetComponent<OnAbleSocket>();
        }

        public abstract bool GetOutput(IOnAble a, IOnAble b);
    }
}