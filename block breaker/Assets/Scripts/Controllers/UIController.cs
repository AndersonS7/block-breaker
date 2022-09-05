using UnityEngine;

namespace Core.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private int maxHeart;
        [SerializeField] private GameObject[] heart;

        private int currentHeart;

        public static UIController instance;

        public int CurrentHeart { get => currentHeart; set => currentHeart = value; }

        void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            ShowHeart(maxHeart);
        }

        public void ShowHeart(int maxHeart)
        {
            //esconde todos os pontos de vida
            for (int i = 0; i < heart.Length; i++)
            {
                heart[i].SetActive(false);
            }

            //mostra os pontos de vida atualizado
            for (int i = 0; i < maxHeart; i++)
            {
                heart[i].SetActive(true);
            }
        }
    }
}

