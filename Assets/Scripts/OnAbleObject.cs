using UnityEngine;

namespace Assets.Scripts
{
    public delegate void OnStateChanged(bool isOn);

    public abstract class OnAbleObject : MonoBehaviour, IOnAble
    {
        protected bool onState;

        public virtual bool IsOn()
        {
            return onState;
        }

        public virtual void SetOn(bool isOn)
        {
//            if (onState == isOn) return;
            onState = isOn;
//            print(name + "'s state: " + isOn);
            if (OnStateChanged != null)
            {
                OnStateChanged(isOn);
            }
        }

        public event OnStateChanged OnStateChanged;
    }
}