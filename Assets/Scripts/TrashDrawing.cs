using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDrawing : MonoBehaviour
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
        GetComponent<Renderer>().material = (Material)Resources.Load("RainbowMaterialLighter");
        //print("In contact with hand");

        GameObject drawingParent = GameObject.Find("DrawingParent");

        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[drawingParent.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in drawingParent.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            Destroy(child.gameObject);
        }

        Debug.Log(transform.childCount);
    }

    void OnTriggerExit(Collider collision)
    {
        GetComponent<Renderer>().material = (Material)Resources.Load("WindowDarkGrayMaterial");
        //print("No longer in contact with hand");
    }
}
