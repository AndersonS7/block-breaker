using UnityEngine.UI;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Text score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreData data = SaveSystem.LoadScore();
        score.text = data != null ? score.text = data.score.ToString() : score.text = "00";
    }
}
