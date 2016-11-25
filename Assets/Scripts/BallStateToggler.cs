using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(OnAbleBall))]
    public class BallStateToggler : MonoBehaviour
    {
        private OnAbleBall onAbleBall;

        private void Start()
        {
            onAbleBall = GetComponent<OnAbleBall>();
        }

        private void OnMouseDown()
        {
            onAbleBall.ToggleOnState();
        }
    }
}