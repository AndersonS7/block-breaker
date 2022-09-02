using UnityEngine;

namespace Core.Ball
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rig;
        [SerializeField] private float speed;

        private Vector3 direction = new Vector3(1, 1, 0);


        // Start is called before the first frame update
        void Start()
        {
            direction.Normalize();
            rig.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
