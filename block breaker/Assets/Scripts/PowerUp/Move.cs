using UnityEngine;

namespace Core.PowerUp
{
    public class Move : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 11.5f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down * Random.Range(0.5f, 1f) * Time.deltaTime);
        }
    }
}

