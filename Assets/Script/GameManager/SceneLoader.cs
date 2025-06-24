using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource;       // Œø‰Ê‰¹‚ğÄ¶‚·‚éAudioSource
    public AudioClip clickSound;          // ƒNƒŠƒbƒN‰¹

    private bool isClicked = false;       // “ñd‰Ÿ‚µ–h~

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
            // Œø‰Ê‰¹‚ªİ’è‚³‚ê‚Ä‚¢‚È‚¢ê‡‚Í‚·‚®‚É‘JˆÚ
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
