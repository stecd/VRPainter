using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSize : MonoBehaviour
{
    public bool smaller;
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
        Debug.Log("In contact with hand");

        if (smaller)
        {
            if (GameObject.Find("Stamper").GetComponent<Stamp>().size >= 0.02f ) {
                GameObject.Find("Stamper").GetComponent<Stamp>().size -= 0.02f;
                GameObject.Find("Drawer").GetComponent<Draw>().lineWidth -= 0.02f;
            }
        }
        if (!smaller)
        {
            if (GameObject.Find("Stamper").GetComponent<Stamp>().size <= 1.0f)
            {
                GameObject.Find("Stamper").GetComponent<Stamp>().size += 0.02f;
                GameObject.Find("Drawer").GetComponent<Draw>().lineWidth += 0.02f;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        GetComponent<Renderer>().material = (Material)Resources.Load("WindowBlueMaterial");
        Debug.Log("No longer in contact with hand");
    }
}
