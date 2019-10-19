using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        Eraser eraser = GameObject.Find("Eraser button").GetComponentInChildren<Eraser>();
        if (eraser.eraserMode)
        {
            GameObject parent = collision.gameObject.transform.parent.gameObject;
            string parentName = parent.name;
            //Debug.Log("touching object with parent named " + parentName);
            if (parentName == "Stroke")
            {
                Destroy(parent);
            }
        }

    }
}
