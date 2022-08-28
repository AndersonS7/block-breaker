using UnityEngine;

namespace Core.Platform
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float speed;

        // Update is called once per frame
        void Update()
        {
            ToMove();
        }

        void ToMove()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
