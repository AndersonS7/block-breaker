using UnityEngine.SceneManagement;
using UnityEngine;

namespace Core.Block
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private int maxLife;
        private int currentLife;

        private void Start()
        {
            currentLife = maxLife;
        }

        private void SubtractLife()
        {
            currentLife--;

            if (currentLife <= 0)
            {
                Core.Controller.GameController.instance.AddScore();
                Core.Block.CreateBlock.instance.TotalBlocksCreated--;

                //pula para a próxima scena
                if (Core.Block.CreateBlock.instance.TotalBlocksCreated <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

                Destroy(gameObject, 0.25f);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ball"))
            {
                SubtractLife();
            }
        }
    }
}

