using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    public GameObject drawing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool scaleUp = OVRInput.Get(OVRInput.Button.Four);
        bool scaleDown = OVRInput.Get(OVRInput.Button.Three);


        if (scaleUp)
        {
            Debug.Log("scaled up");
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f, 1.1f, 1.1f));
            
            /*
            foreach (Transform child in drawing.transform)
            {
                if (null == child)
                    continue;
                child.localScale = Vector3.Scale(child.localScale, new Vector3(1.1f, 1.1f, 1.1f));
            }*/
        }

        if (scaleDown)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.9f, 0.9f, 0.9f));
            /*
            foreach (Transform child in drawing.transform)
            {
                if (null == child)
                    continue;
                child.localScale = Vector3.Scale(child.localScale, new Vector3(0.9f, 0.9f, 0.9f));
            }
            */
        }

    }
}
