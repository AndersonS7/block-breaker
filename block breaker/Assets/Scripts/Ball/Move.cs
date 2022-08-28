using UnityEngine;

namespace Core.Ball
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rig;
        [SerializeField] private float speed;
        private Vector2 starDirection = new Vector2(1, 1);

        // Start is called before the first frame update
        void Start()
        {
            rig.AddForce(starDirection.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}

