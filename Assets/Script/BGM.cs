using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGM : MonoBehaviour
{
    [SerializeField] AudioClip bgmClip; // BGM�̉������Z�b�g

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true; // ���[�v�Đ�
        audioSource.Play();
    }
}
