using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class LifeSystem : MonoBehaviour
    {
        [SerializeField] private int maxLife;
        [SerializeField] private GameObject[] heart;
        [SerializeField] private GameObject ball;
        [SerializeField] private GameObject platform;
        private Vector3 startPosBall = new Vector3(0, -3.5f, 0);
        private Vector3 startPosPlatform = new Vector3(0, -4, 0);

        private GameObject platformTemp;
        public GameObject PlatformTemp { get => platformTemp; set => platformTemp = value; }

        public static LifeSystem instance;


        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            StartPosObjcts();
            ShowHeart();
        }

        public void SubtractLife()
        {
            maxLife--;
            ShowHeart();
            StartCoroutine(RestartBall());

            //gameover -> mostrar tela com pontuação e opção de reinicar ou sair do jogo
            if (maxLife <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void ShowHeart()
        {
            //esconde todos os pontos de vida
            for (int i = 0; i < heart.Length; i++)
            {
                heart[i].SetActive(false);
            }

            //mostra os pontos de vida atualizado
            for (int i = 0; i < maxLife; i++)
            {
                heart[i].SetActive(true);
            }
        }

        private void StartPosObjcts()
        {
            Instantiate(ball, startPosBall, Quaternion.identity);
            platformTemp = Instantiate(platform, startPosPlatform, Quaternion.identity);
        }

        IEnumerator RestartBall()
        {
            yield return new WaitForSeconds(0.2f);
            StartPosObjcts();
        }
    }
}
