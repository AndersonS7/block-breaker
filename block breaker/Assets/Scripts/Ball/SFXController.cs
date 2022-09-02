using UnityEngine;

namespace Core.Ball
{
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioS;
        [SerializeField] private AudioClip sfxCollision;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Wall") || other.collider.CompareTag("Block"))
            {
                audioS.PlayOneShot(sfxCollision);
            }
        }
    }
}
