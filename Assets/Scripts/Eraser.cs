using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public bool eraserMode;
    // Start is called before the first frame update
    void Start()
    {
        eraserMode = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (eraserMode)
        {
            eraserMode = false;
            GetComponent<Renderer>().material = (Material)Resources.Load("WindowDarkGrayMaterial");
        }
        else
        {
            eraserMode = true;
            GetComponent<Renderer>().material = (Material)Resources.Load("EraserMaterial");
        }

        //print("In contact with hand");

        //GameObject.Find("Stamper").GetComponent<Stamp>().size -= 0.02;
        //GameObject.Find("Drawer").GetComponent<Draw>().lineWidth -= 0.02;
    }
}
