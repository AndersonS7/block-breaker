using UnityEngine.UI;
using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Text scoreTXT;

        [Header("TESTE----")]
        public GameObject ball;
        public GameObject platform;
        
        [SerializeField] private Vector3 posBall;
        [SerializeField] private Vector3 posPlatform;

        private int scoreNumber;
        public static GameController instance;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            StartCoroutine(RestartPos());
            LoadScore(scoreTXT);
        }

        public void AddScore()
        {
            scoreNumber++;
            scoreTXT.text = scoreNumber.ToString();

            SaveScore(scoreNumber);
        }

        public void SaveScore(int score)
        {
            SaveSystem.SaveData(score);
        }

        public void LoadScore(Text scoreTXT)
        {
            ScoreData data = SaveSystem.LoadScore();

            if (data != null)
            {
                scoreTXT.text = data.score.ToString();
                scoreNumber = data.score;
            }
            else
            {
                scoreTXT.text = "0";
            }
        }

        public void IRestartPos()
        {
            ball.gameObject.SetActive(false);
            platform.gameObject.SetActive(false);
            
            ball.gameObject.transform.position = posBall;
            platform.gameObject.transform.position = posPlatform;

            StartCoroutine(RestartPos());
        }

        IEnumerator RestartPos()
        {
            yield return new WaitForSeconds(1);
            ball.gameObject.SetActive(true);
            platform.gameObject.SetActive(true);
        }
    }
}
//C:/Users/ander/AppData/LocalLow/DefaultCompany/block breaker
