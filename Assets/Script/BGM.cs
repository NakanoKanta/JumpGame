using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGM : MonoBehaviour
{
    [SerializeField] AudioClip bgmClip; // BGMの音源をセット

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true; // ループ再生
        audioSource.Play();
    }
}
