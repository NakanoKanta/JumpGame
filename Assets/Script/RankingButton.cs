using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound; // Œø‰Ê‰¹
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    public void GoToRanking()
    {
        float lastScore = PlayerPrefs.GetFloat("LastScore", -1f);
        int isRegistered = PlayerPrefs.GetInt("ScoreRegistered", 0); // 0 = –¢“o˜^

        if (lastScore > 0f && lastScore != float.MaxValue && isRegistered == 0)
        {
            Ranking.SaveScore(lastScore);
            PlayerPrefs.SetInt("ScoreRegistered", 1); // “o˜^Ï‚İ‚Éƒ}[ƒN
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ƒXƒRƒA‚ÍŠù‚É“o˜^Ï‚İA‚Ü‚½‚Í–³Œø‚Å‚·");
        }

        StartCoroutine(PlaySoundAndLoadScene());
    }
    private IEnumerator PlaySoundAndLoadScene()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length); // Œø‰Ê‰¹‚ÌÄ¶‚ªI‚í‚é‚Ü‚Å‘Ò‚Â
        }

        SceneManager.LoadScene("RankingScene");
    }
}
