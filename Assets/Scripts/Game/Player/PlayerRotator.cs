using UnityEngine;

namespace P3D.Game
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _previousMousePosition;

        private void Start()
        {
            _previousMousePosition = Input.mousePosition;
        }

        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 delta = mousePosition - _previousMousePosition;
            float rotationDelta = delta.x;
            transform.Rotate(transform.up, rotationDelta * _speed * Time.deltaTime);
            _previousMousePosition = mousePosition;
        }
    }
}