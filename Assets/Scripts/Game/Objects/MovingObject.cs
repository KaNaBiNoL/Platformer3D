using UnityEngine;

namespace P3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private Transform _fromTransform;
        [SerializeField] private Transform _toTransform;

        public Transform FromTransform => _fromTransform;
        public Transform ToTransform => _toTransform;
    }
}
