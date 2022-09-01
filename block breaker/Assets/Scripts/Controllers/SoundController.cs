using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Controller
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioS;
        [SerializeField] private AudioClip[] clips;


        // Start is called before the first frame update
        void Start()
        {
            audioS.clip = clips[Random.Range(0, clips.Length)];
            audioS.Play();
        }
    }
}

