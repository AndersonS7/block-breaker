using UnityEngine;

namespace Core.Ball
{
    public class LifeSystem : MonoBehaviour
    {
        [Header("LIFE CONTROL")]
        private int currentLife;
        private bool gameOver;

        public bool GameOver { get => gameOver; }

        private void Start()
        {
            currentLife = Controller.UIController.instance.CurrentHeart;
        }

        private void SubtractLife()
        {
            currentLife--;
            Controller.UIController.instance.ShowHeart(currentLife);
            Controller.GameController.instance.IRestartPos(true);

            if (currentLife <= 0)
            {
                gameOver = true;
                Time.timeScale = 0;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor"))
            {
                SubtractLife();
            }
        }
    }
}

