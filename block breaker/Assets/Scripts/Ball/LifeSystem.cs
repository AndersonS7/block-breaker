using UnityEngine;

namespace Core.Ball
{
    public class LifeSystem : MonoBehaviour
    {
        private void SubtractLife()
        {
            Controller.UIController.instance.CurrentHeart--;
            Controller.UIController.instance.ShowHeart();
            Controller.GameController.instance.IRestartPos(true);
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
