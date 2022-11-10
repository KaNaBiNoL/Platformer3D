using System;
using Cinemachine;
using UnityEngine;

namespace P3D.Game
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private PlayerMovement _playerMovement;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_playerMovement.Velocity.sqrMagnitude > 0)
            {
                transform.rotation = Quaternion.Euler(0, _freeLook.m_XAxis.Value, 0);
            }
        }
    }
}