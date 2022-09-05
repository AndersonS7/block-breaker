using UnityEngine.UI;
using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Text scoreTXT;
        [SerializeField] private Vector3 posBall;
        [SerializeField] private Vector3 posPlatform;

        public GameObject ball;
        public GameObject platform;

        private GameObject currentBall;
        private GameObject currentPlatform;

        private int scoreNumber;
        public static GameController instance;

        private bool create;

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

        public void IRestartPos(bool res)
        {
            create = res;
            Destroy(currentBall);
            Destroy(currentPlatform);

            if (create)
            {
                StartCoroutine(RestartPos());
            }
        }

        IEnumerator RestartPos()
        {
            yield return new WaitForSeconds(1);

            create = false;
            currentBall = Instantiate(ball, posBall, Quaternion.identity);
            currentPlatform = Instantiate(platform, posPlatform, Quaternion.identity);

        }
    }
}
//C:/Users/ander/AppData/LocalLow/DefaultCompany/block breaker
