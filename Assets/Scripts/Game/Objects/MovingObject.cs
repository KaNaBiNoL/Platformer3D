using System;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _duration = 3f;
        [SerializeField] private float _interval = 2f;
        [SerializeField] private Ease _ease;

        private Tween _tween;

        public Transform[] Points => _points;

        private void Awake()
        {
            transform.position = _fromTransform.position;
        }

        private void Start()
        {
            Play();
        }

        public void Play()
        {
            _tween?.Kill(true);
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_interval);
            sequence.Append(transform
                .DOMove(_toTransform.position, _duration)
                .SetEase(_ease));
            sequence.AppendInterval(_interval);
            sequence.Append(transform
                .DOMove(_fromTransform.position, _duration)
                .SetEase(_ease));
            sequence
                .SetLoops(-1)
                .SetUpdate(UpdateType.Fixed);

            _tween = sequence;
        }
    }
    
    
}
