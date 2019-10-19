using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Transform pathToHandR = gameObject.transform.Find("hand_right");
        if (pathToHandR)
        {
            pathToHandR.gameObject.SetActive(false);

        }
        Transform pathToHandL = gameObject.transform.Find("hand_left");
        if (pathToHandL)
        {
            pathToHandL.gameObject.SetActive(false);
        }

    }
}
