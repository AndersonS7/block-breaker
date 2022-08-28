using UnityEngine;

namespace Core.Block
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ball"))
            {
                Destroy(gameObject);
                Core.Controller.GameController.instance.AddScore();
            }
        }
    }
}

