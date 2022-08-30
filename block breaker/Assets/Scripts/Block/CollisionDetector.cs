using UnityEngine;

namespace Core.Block
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ball"))
            {
                Destroy(gameObject, 0.25f);
                Core.Controller.GameController.instance.AddScore();
            }
        }
    }
}

