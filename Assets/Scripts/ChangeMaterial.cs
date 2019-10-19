using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private Material storedMat;
    // Start is called before the first frame update
    void Start()
    {
        storedMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        GetComponent<Renderer>().material = (Material)Resources.Load("RainbowMaterialLighter");
        //Debug.Log("In contact with hand---------------");

        GameObject drawer = GameObject.Find("Drawer");
        drawer.GetComponent<Draw>().isSelected = true;
        GameObject.Find("Stamper").GetComponent<Stamp>().isSelected = false;

        drawer.gameObject.SetActive(true);

        if (storedMat.name == "Water")
            drawer.GetComponent<Draw>().isWater = true;
        else
            drawer.GetComponent<Draw>().isWater = false;

        drawer.GetComponent<Draw>().lineMat = storedMat;
        //Debug.Log("material: " + storedMat.name);

    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = storedMat;
        //Debug.Log("No longer in contact with hand");
    }
}
