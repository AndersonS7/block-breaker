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


        [Header("MODO DE CRIAÇÃO----")]
        [Tooltip("cria blocos intercalados (max 2 blocos)")][SerializeField] private bool op1;
        [Tooltip("cria blocos saltando para o próximo bloco")][SerializeField] private bool op2;

        public static CreateBlock instance;

        public int totalBlocksCreated;
        public int TotalBlocksCreated { get => totalBlocksCreated; set => totalBlocksCreated = value; }

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            if (op1)
            {
                GenerateBlocks01(1);
            }
            else if (op2)
            {
                GenerateBlocks01(2);
            }
            else if (!op1 && !op2)
            {
                GenerateBlocks01(1);
            }
            //----
            TotalBlocksCreated = maxColum * maxLine;
        }

        void GenerateBlocks01(int op) // 1 = op1 | 2 = op2
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

                if (op == 1)
                {
                    indexBlock = indexBlock == 0 ? indexBlock = 1 : indexBlock = 0;
                }
                if (op == 2 && indexBlock <= prefabBlock.Length)
                {
                    indexBlock++;
                }
            }
        }
    }
}
