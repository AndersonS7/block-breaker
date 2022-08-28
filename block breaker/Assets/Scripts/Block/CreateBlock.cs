using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Block
{
    public class CreateBlock : MonoBehaviour
    {
        [SerializeField] private GameObject prefabBlock;
        [SerializeField] private int maxBlock;
        [SerializeField] private float jumpBlock;

        // Start is called before the first frame update
        void Start()
        {
            GenerateBlocks();
        }

        void GenerateBlocks()
        {
            for (int i = 0; i < maxBlock; i++)
            {
                GameObject obj = Instantiate(prefabBlock, transform.position, Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.transform.position = new Vector3(transform.position.x + jumpBlock, transform.position.y, transform.position.z);
                jumpBlock += 1f;
            }
        }
    }
}
