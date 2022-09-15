using UnityEngine;

namespace Core.Block
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private int maxLife;
        [SerializeField] private int scoreBlock;
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
                Core.Controller.GameController.instance.AddScore(scoreBlock);
                Core.Block.CreateBlock.instance.TotalBlocksCreated--;

                //pula para a próxima scena
                if (Core.Block.CreateBlock.instance.TotalBlocksCreated <= 0)
                {
                    Core.Controller.NextLvl.instance.ActiveNextLevel();
                }

                Destroy(gameObject);
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
