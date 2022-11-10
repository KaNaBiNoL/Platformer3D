using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;
        [SerializeField] private float _duration = 3f;
        [SerializeField] private float _interval = 2f;
        [SerializeField] private Ease _ease;

        private Tween _tween;

        public List<Transform> Points => _points;

        private void Awake()
        {
            if (!IsValid())
            {
                return;
            }

            transform.position = _points.First().position;
        }

        private void Start()
        {
            if (!IsValid())
            {
                return;
            }

            Play();
        }

        public void Play()
        {
            _tween?.Kill(true);
            Sequence sequence = DOTween.Sequence();

            for (int i = 1; i < _points.Count; i++)
            {
                Transform point = _points[i];
                sequence.AppendInterval(_interval);
                sequence.Append(transform
                    .DOMove(point.position, _duration)
                    .SetEase(_ease));
            }

            sequence.AppendInterval(_interval);
            sequence.Append(transform
                .DOMove(_points.First().position, _duration)
                .SetEase(_ease));

            sequence
                .SetLoops(-1)
                .SetUpdate(UpdateType.Fixed);

            _tween = sequence;
        }

        private bool IsValid() =>
            _points != null && _points.Count > 1;
    }
}