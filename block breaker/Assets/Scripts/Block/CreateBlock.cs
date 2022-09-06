using UnityEngine;

namespace Core.Block
{
    public class CreateBlock : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabBlock;
        [SerializeField] private int maxColum;
        [SerializeField] private int maxLine;
        private float jumpColum;
        private float jumpLine;
        private int indexBlock; //controla qual bloco vai ser usado.

        void Start()
        {
            GenerateBlocks();
        }

        void GenerateBlocks()
        {
            for (int l = 0; l < maxLine; l++)
            {
                for (int c = 0; c < maxColum; c++)
                {
                    GameObject obj = Instantiate(prefabBlock[indexBlock], transform.position, Quaternion.identity);
                    obj.transform.SetParent(gameObject.transform);
                    obj.transform.position = new Vector3(transform.position.x + jumpColum, transform.position.y + jumpLine, transform.position.z);
                    jumpColum += 1; //1f
                }
                jumpLine -= 0.3f; //0.3f
                jumpColum = 0;

                indexBlock = indexBlock == 0 ? indexBlock = 1 : indexBlock = 0;
            }
        }
    }
}
