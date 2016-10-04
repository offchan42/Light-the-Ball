using UnityEngine;

namespace Assets.Scripts
{
    public class OnAbleBall : OnAbleObject
    {
        public static readonly string LightSourceName = "OnLight";
        public bool initOnState;
        public bool inputBall;

        private GameObject lightSource;
        private Animator animator;

        private void Awake()
        {
            lightSource = transform.FindChild(LightSourceName).gameObject;
        }

        private void Start()
        {
            if (inputBall)
            {
                SetOn(initOnState);
            }
            else
            {
                GameManager.instance.AddOutputBall(this);
            }
            animator = GetComponent<Animator>();
        }

        public override void SetOn(bool isOn)
        {
            base.SetOn(isOn);
            lightSource.SetActive(onState);
            if (animator != null)
            {
                animator.SetBool("Swinging", isOn);
            }
        }

        public void ToggleOnState()
        {
            SetOn(!onState);
        }
    }
}