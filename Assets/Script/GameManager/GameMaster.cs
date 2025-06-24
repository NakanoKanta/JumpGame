using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] CountManager countManager;
    [SerializeField] PlayerMove playerMove;

    bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countManager.StartTimer <= 0)
        {
            isPlayer = true;
            if (isPlayer)
            {
                playerMove.PlayerJumpPower = 10;
            }
        }
    }
}
