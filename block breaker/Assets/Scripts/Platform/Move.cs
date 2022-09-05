using System.Collections;
using UnityEngine;

namespace Core.Platform
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float speed;

        private float saveSpeed;

        [Header("BIG PLATFORM CONFIG")]
        [SerializeField] private Color colorAlpha;
        [SerializeField] private Color color;
        private GameObject bigPlatform;

        void Awake()
        {
            saveSpeed = speed;
            bigPlatform = GameObject.FindGameObjectWithTag("BigPlatform");
            
            DisabledBigPlatform();
        }

        // Update is called once per frame
        void Update()
        {
            ToMove();
            DetectPowerUp();
        }

        void ToMove()
        {
            //
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)
            && transform.position.x > -5.94f + transform.localScale.x)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)
            && transform.position.x < 5.94f - transform.localScale.x)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        void DetectPowerUp()
        {
            GameObject powerUp = Controller.PowerUpController.instance.CurrentPowerUp;
            if (powerUp != null)
            {
                if (Vector2.Distance(powerUp.transform.position, transform.position) <= 0.8f
                && powerUp.transform.position.y - 0.35f <= transform.position.y)
                {
                    if (powerUp.name == "PowerUp-big" + "(Clone)")
                    {
                        ActiveBigPlatform();
                        Destroy(powerUp.gameObject);
                    }
                    if (powerUp.name == "PowerUp-speed" + "(Clone)")
                    {
                        speed = speed * 2;
                        Destroy(powerUp.gameObject);
                    }
                    if (powerUp.name == "PowerUp-small" + "(Clone)")
                    {
                        transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y, transform.localScale.z);
                        Destroy(powerUp.gameObject);
                    }

                    StartCoroutine(Call());
                }
            }
        }

        void RestartStates()
        {
            DisabledBigPlatform();
            speed = saveSpeed;
        }

        IEnumerator Call()
        {
            yield return new WaitForSeconds(7);
            RestartStates();
        }

        //power up - big platform
        private void ActiveBigPlatform()
        {
            bigPlatform.GetComponent<Collider2D>().enabled = true;
            bigPlatform.GetComponent<SpriteRenderer>().color = color;
        }

        private void DisabledBigPlatform()
        {
            bigPlatform.GetComponent<Collider2D>().enabled = false;
            bigPlatform.GetComponent<SpriteRenderer>().color = colorAlpha;
        }

    }
}
