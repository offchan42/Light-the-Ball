using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(OnAbleBall))]
    public class BallStateToggler : MonoBehaviour
    {
        public AudioSource toggleSound;

        private OnAbleBall onAbleBall;

        private void Start()
        {
            onAbleBall = GetComponent<OnAbleBall>();
        }

        private void OnMouseDown()
        {
            onAbleBall.ToggleOnState();
            if (toggleSound != null)
            {
                toggleSound.Play();
            }
        }
    }
}