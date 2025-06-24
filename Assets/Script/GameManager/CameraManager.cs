using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position;

        if (target.transform.position.y > 0)
        {
            cameraPos.y = target.transform.position.y;
        }
        else 
        {
            cameraPos.y = 0;
        }
        cameraPos.z = -10;
        cameraPos.x = 0;
        Camera.main.transform.position = cameraPos;
        
    }
}
