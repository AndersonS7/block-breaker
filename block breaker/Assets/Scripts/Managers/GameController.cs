using UnityEngine;

namespace Core.Controller
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore()
        {
            Debug.Log("Pontuação adicionada...");
        }
    }
}

