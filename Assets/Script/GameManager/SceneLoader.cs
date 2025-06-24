using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource;       // ���ʉ����Đ�����AudioSource
    public AudioClip clickSound;          // �N���b�N��

    private bool isClicked = false;       // ��d�����h�~

    public void LoadScene(string sceneName)
    {
        if (isClicked) return;
        isClicked = true;

        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            StartCoroutine(LoadSceneAfterDelay(sceneName, clickSound.length));
        }
        else
        {
            // ���ʉ����ݒ肳��Ă��Ȃ��ꍇ�͂����ɑJ��
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
