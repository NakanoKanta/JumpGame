using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;      // �Đ��pAudioSource
    public AudioClip clickSound;         // �Đ�����N���b�N��

    private bool isClicked = false;

    public void OnClickButton()
    {
        if (isClicked) return;  // ��d�N���b�N�h�~
        isClicked = true;

        // ����炷
        audioSource.PlayOneShot(clickSound);
    }
}
