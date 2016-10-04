using UnityEngine;

namespace Assets.Scripts
{
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