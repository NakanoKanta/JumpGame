using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
    public void GoToRanking()
    {
        float lastScore = PlayerPrefs.GetFloat("LastScore", -1f);
        int isRegistered = PlayerPrefs.GetInt("ScoreRegistered", 0); // 0 = ���o�^

        if (lastScore > 0f && lastScore != float.MaxValue && isRegistered == 0)
        {
            Ranking.SaveScore(lastScore);
            PlayerPrefs.SetInt("ScoreRegistered", 1); // �o�^�ς݂Ƀ}�[�N
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("�X�R�A�͊��ɓo�^�ς݁A�܂��͖����ł�");
        }

        SceneManager.LoadScene("RankingScene");
    }
}
