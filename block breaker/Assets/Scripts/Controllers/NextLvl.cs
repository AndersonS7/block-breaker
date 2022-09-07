using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace Core.Controller
{
    public class NextLvl : MonoBehaviour
    {
        [SerializeField] private GameObject nextLvl;

        public static NextLvl instance;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        public void ActiveNextLevel()
        {
            nextLvl.SetActive(true);
            StartCoroutine(Call());
        }

        IEnumerator Call()
        {
            yield return new WaitForSeconds(1.8f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

