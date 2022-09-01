using UnityEngine.UI;
using UnityEngine;

namespace Core.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Text scoreTXT;

        private int scoreNumber;

        public static GameController instance;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        private void Start()
        {
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
    }
}
//C:/Users/ander/AppData/LocalLow/DefaultCompany/block breaker
