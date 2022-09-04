using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private GameObject[] powerUps;
        [SerializeField] private int maxX;
        [SerializeField] private int minX;

        private bool create;

        private GameObject currentPowerUp;
        public GameObject CurrentPowerUp { get => currentPowerUp; set => currentPowerUp = value; }

        public static PowerUpController instance;

        void Awake()
        {
            instance = this;
        }

        void Update()
        {
            if (!create)
            {
                CurrentPowerUp = Instantiate(powerUps[Random.Range(0, powerUps.Length)], new Vector2(Random.Range(minX, maxX), 4), Quaternion.identity);
                create = true;
                StartCoroutine(Call());
            }
        }

        IEnumerator Call()
        {
            yield return new WaitForSeconds(13);
            create = false;
        }
    }
}
