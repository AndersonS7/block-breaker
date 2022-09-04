using UnityEngine;

namespace Core.Ball
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rig;
        [SerializeField] private float speed;

        private Vector3 direction = new Vector3(1, 1, 0);

        private bool shoot;

        private void OnEnable()
        {
            rig.drag = 0;
            shoot = true;
            ToMove();
        }

        private void OnDisable()
        {
            rig.drag = 1000;
        }

        private void ToMove()
        {
            if (shoot)
            {
                direction.Normalize();
                rig.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
                shoot = false;
            }
        }
    }
}
