using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class OnAbleLine : OnAbleObject
    {
        public OnAbleSocket inputSocket;
        public OnAbleSocket outputSocket;
        public Material offMaterial;
        public Material onMaterial;

        private LineRenderer lineRenderer;
        private static Vector3 backVector = Vector3.back;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            lineRenderer.SetPositions(new[] { inputSocket.transform.position + backVector, outputSocket.transform.position + backVector });
            SetOn(onState);
        }

        private void Update()
        {
            lineRenderer.SetPositions(new[] { inputSocket.transform.position + backVector, outputSocket.transform.position + backVector });
        }


        private void OnEnable()
        {
            inputSocket.OnStateChanged += SetOn;
            OnStateChanged += outputSocket.SetOn;
        }

        private void OnDisable()
        {
            inputSocket.OnStateChanged -= SetOn;
            OnStateChanged -= outputSocket.SetOn;
        }

        public override void SetOn(bool isOn)
        {
            base.SetOn(isOn);
            lineRenderer.material = isOn ? onMaterial : offMaterial;
        }
    }
}