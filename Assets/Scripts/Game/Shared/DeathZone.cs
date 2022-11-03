using UnityEngine;
using UnityEngine.SceneManagement;

namespace P3D.Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
