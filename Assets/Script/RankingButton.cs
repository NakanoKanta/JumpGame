using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
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

        SceneManager.LoadScene("RankingScene");
    }
}
