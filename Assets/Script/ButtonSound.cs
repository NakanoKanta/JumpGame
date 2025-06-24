using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;      // 再生用AudioSource
    public AudioClip clickSound;         // 再生するクリック音

    private bool isClicked = false;

    public void OnClickButton()
    {
        if (isClicked) return;  // 二重クリック防止
        isClicked = true;

        // 音を鳴らす
        audioSource.PlayOneShot(clickSound);
    }
}
