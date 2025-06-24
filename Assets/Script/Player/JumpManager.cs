using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpManager : MonoBehaviour
{
    public Slider gaugeSlider;

    [SerializeField] PlayerMove Player;

    public float decreaseSpeed = 1f;
    CountManager countManager;
    void Start()
    {
        countManager = FindObjectOfType<CountManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!countManager.isGameTimer)
        {
            gaugeSlider.value = 0;
            return; // タイマー開始前はゲージ無効
        }
        if (Player.JumpFrag)
        {
            float normalized = Mathf.Clamp01(Player.JumpCount / 2f);
            gaugeSlider.value = normalized;
        }
        else
        {
            // 徐々に減らす
            gaugeSlider.value -= decreaseSpeed * Time.deltaTime;
            gaugeSlider.value = Mathf.Clamp01(gaugeSlider.value);
        }
    }
}
