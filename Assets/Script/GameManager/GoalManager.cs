using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] GameObject TitleButton;
    public CountManager CountManager;

    void Start()
    {
        TitleButton.SetActive(false);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        TitleButton.SetActive(true);
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            Debug.Log("GOAL");
           
            if (CountManager != null)
            { 
                CountManager.StopTimer();
            }
        }
    }
}
