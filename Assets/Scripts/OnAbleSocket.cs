using Assets.Scripts.Gates;
using UnityEngine;

namespace Assets.Scripts
{
    public class OnAbleSocket : OnAbleObject
    {
//        private OnAbleLine onAbleLine;
        private OnAbleObject onAbleParent;
        private bool isInput; // determine whether this socket should listen to the line or the gate
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            onAbleParent = GetComponentInParent<OnAbleGate>() ?? (OnAbleObject) GetComponentInParent<OnAbleBall>();
            if (onAbleParent == null)
            {
                print("The socket is not attached to any OnAbleObject.");
            }
            isInput = name.ToLower().Contains("input");
        }

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            SetOn(onState);
        }

        private void OnEnable()
        {
            if (!isInput)
            {
                onAbleParent.OnStateChanged += SetOn;
            }
            else
            {
                OnStateChanged += onAbleParent.SetOn;
            }
        }

        private void OnDisable()
        {
            if (!isInput)
            {
                onAbleParent.OnStateChanged -= SetOn;
            }
            else
            {
                OnStateChanged += onAbleParent.SetOn;
            }
        }

        public override void SetOn(bool isOn)
        {
            base.SetOn(isOn);
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = isOn;
            }
        }
    }
}