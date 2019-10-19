using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
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
        GetComponent<Renderer>().material =(Material)Resources.Load("RainbowMaterialLighter");
        //print("In contact with hand");


        Sprite imageSprite = this.transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        Sprite[] arr = { imageSprite };

        GameObject stamper = GameObject.Find("Stamper");
        stamper.GetComponent<Stamp>().isSelected = true;
        GameObject.Find("Drawer").GetComponent<Draw>().isSelected = false;

        stamper.GetComponent<Stamp>().spriteImage = imageSprite;
    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = (Material)Resources.Load("WindowDarkGrayMaterial");
        //print("No longer in contact with hand");
    }


}
