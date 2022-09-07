using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private GameObject[] powerUps;

        [Header("CONTROLLER MAX DISTANCE")]
        [SerializeField] private int maxX;
        [SerializeField] private int minX;

        private bool create = true;
        private int numDrawn;

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
                CurrentPowerUp = Instantiate(powerUps[NumberDrawn()], new Vector2(Random.Range(minX, maxX), 4), Quaternion.identity);
                create = true;
                StartCoroutine(Call());
            }
        }

        private int NumberDrawn()
        {
            numDrawn = Random.Range(0, 10);

            if (numDrawn <= 3)
            {
                return 0;
            }
            if (numDrawn <= 6)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        IEnumerator Call()
        {
            yield return new WaitForSeconds(13);
            create = false;
        }
    }
}
