using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private GameObject[] powerUps;
        [SerializeField] private int maxX;
        [SerializeField] private int minX;

        private bool create = true;

        private GameObject currentPowerUp;
        public GameObject CurrentPowerUp { get => currentPowerUp; set => currentPowerUp = value; }

        public static PowerUpController instance;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            StartCoroutine(Call());
        }

        void Update()
        {
            if (!create)
            {
                //Random.Range(0, powerUps.Length)
                CurrentPowerUp = Instantiate(powerUps[0], new Vector2(Random.Range(minX, maxX), 4), Quaternion.identity);
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
