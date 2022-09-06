using UnityEngine;

namespace Core.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private int maxHeart;
        [SerializeField] private GameObject[] heart;
        [SerializeField] private GameObject gameOver;

        private int currentHeart;
        public int CurrentHeart { get => currentHeart; set => currentHeart = value; }

        public static UIController instance;

        void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            currentHeart = maxHeart;
            ShowHeart();
        }

        void Update()
        {
            ShowGameOver();
        }

        private void ShowGameOver()
        {
            if (CurrentHeart <= 0)
            {
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void ShowHeart()
        {
            //esconde todos os pontos de vida
            for (int i = 0; i < heart.Length; i++)
            {
                heart[i].SetActive(false);
            }

            //mostra os pontos de vida atualizado
            for (int i = 0; i < CurrentHeart; i++)
            {
                heart[i].SetActive(true);
            }
        }
    }
}

