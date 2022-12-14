using UnityEngine;

namespace P3D.Game
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int SpeedHorizontal = Animator.StringToHash("SpeedHorizontal");
        private static readonly int SpeedVertical = Animator.StringToHash("SpeedVertical");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        [SerializeField] private Animator _animator;

        public void SetSpeedHorizontal(float value)
        {
            _animator.SetFloat(SpeedHorizontal, value);
        }
        
        public void SetSpeedVertical(float value)
        {
            _animator.SetFloat(SpeedVertical, value);
        }

        public void SetIsGrounded(bool value)
        {
            _animator.SetBool(Grounded, value);
        }
    }
}