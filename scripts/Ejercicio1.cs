using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    public AudioClip sound;  
    private AudioSource sound_manager;

    void Start()
    {
        sound_manager = gameObject.AddComponent<AudioSource>();
        sound_manager.clip = sound;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spider")) {
            sound_manager.Play();
        }
    }
}