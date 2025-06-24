using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    [SerializeField] Text GameCount; // Game��Start�̃J�E���g�_�E����Text
    [SerializeField]GameObject StartCount; // Game�̌o�ߎ��Ԃ�Text
    public float GameTimer = 0f;
    public float StartTimer = 4f;
    private int S_Timer;    
    bool isTimer = false;

    public bool isGameTimer = false;
    
    void Start()
    {
        StartCount.SetActive(false);
    }
    void Update()
    {
        if (isTimer)
        {
            //<Game��Start�̃J�E���g�_�E��>
            StartTimer -= Time.deltaTime;
            S_Timer = (int)StartTimer;
            StartCount.GetComponent<Text>().text = S_Timer.ToString();
            if (StartTimer <= 0)
            {
                StartTimer = 0;
                StartCount.SetActive(false);
                isGameTimer = true;
                isTimer = false;
            }
        }
        if (isGameTimer)
        {
            //<Game�̌o�ߎ���>
            GameTimer += Time.deltaTime;
            GameCount.text = GameTimer.ToString("F2");
        }
    }

    public void OnClick()
    {
        isTimer = true;
        StartCount.SetActive(true);
    }
    public void StopTimer()
    {
        isGameTimer = false;
        Debug.Log("�^�C���ۑ�: " + GameTimer);
        PlayerPrefs.SetFloat("LastScore", GameTimer);
        PlayerPrefs.SetInt("ScoreRegistered", 0); // ���̓o�^������
        PlayerPrefs.Save();
    }
}
