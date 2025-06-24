using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Ranking : MonoBehaviour
{
    public Text[] rankingTexts;
    private const int MaxRanking = 5;

    void Start()
    {
        ShowRanking();
    }

    public static void SaveScore(float newScore)
    {
        Debug.Log("SaveScore called with: " + newScore);
        List<float> scores = new List<float>();

        //�����̃X�R�A��ǂݍ���
        for (int i = 0; i < MaxRanking; i++)
        {
            //Debug.Log("����");
            scores.Add(PlayerPrefs.GetFloat("Score" + i, float.MaxValue));
        }

        //�V�X�R�A��ǉ�����
        scores.Add(newScore);
        scores = scores.OrderBy(s => s).ToList();

        //���5������ۑ�
        for (int i = 0; i < MaxRanking; i++)
        {
            //Debug.Log("���");
            PlayerPrefs.SetFloat("Score" + i, scores[i]);
        }
        PlayerPrefs.Save();
        //ShowRanking();
    }

    public void ShowRanking()
    {
        for (int i = 0; i < MaxRanking; i++)
        {
            //Debug.Log("ShowRanking");
            float score = PlayerPrefs.GetFloat("Score" + i, float.MaxValue);
            //rankingTexts[i].text = $"{i + 1}. {score:F2}";
            if (score == float.MaxValue)
            {
                rankingTexts[i].text = $"{i + 1}. ---";
            }
            else
            {
                rankingTexts[i].text = $"{i + 1}. {score:F2} �b";
            }
        }
    }
    public void ResetRanking()
    {
        for (int i = 0; i < MaxRanking; i++)
        {
            PlayerPrefs.DeleteKey("Score" + i);
        }
        PlayerPrefs.DeleteKey("LastScore");
        PlayerPrefs.DeleteKey("ScoreRegistered");

        PlayerPrefs.Save();
        Debug.Log("�����L���O�����Z�b�g���܂���");

        ShowRanking(); // �\�����X�V
    }
}
