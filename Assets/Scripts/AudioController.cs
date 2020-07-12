using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [SerializeField] private AudioSource controller;
    [SerializeField] private List<AudioClip> sounds;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        controller.clip = sounds[Random.Range(0, sounds.Count)];
        controller.Play();
    }

    private void Update()
    {
        if (!controller.isPlaying)
        {
            controller.clip = null;
            controller.clip = sounds[Random.Range(0, sounds.Count)];
            controller.Play();
        }
    }
}
