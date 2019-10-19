using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    public Material lineMat;
    public GameObject hand;
    public float lineWidth = 0.1f;
    public GameObject drawingParent;
    public bool isWater;
    public bool isSelected;
    private MeshLineRenderer currLine;
    private int numClicks = 0;
     

    // Start is called before the first frame update
    void Start()
    {
        currLine = new MeshLineRenderer();
        isWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSelected)
            return;

        float triggerVal = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (triggerVal < 0.5 && triggerVal > 0.3) 
        {
            GameObject go = new GameObject("Stroke");
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            go.AddComponent<MeshLineRenderer>();
            //BoxCollider collider = go.AddComponent<BoxCollider>();
            //collider.isTrigger = true;
            //go.isStatic = true;
            currLine = go.GetComponent<MeshLineRenderer>();
            currLine.lmat = new Material(lineMat);
            currLine.setWidth(lineWidth);
            //Debug.Log("start line");
            //Debug.Log(currLine);
            numClicks = 0;

            go.transform.position = hand.transform.position;
            go.transform.SetParent(drawingParent.transform);

        }
        else if (triggerVal > 0.8)
        {
            //Debug.Log("cont line");
            //Debug.Log(currLine);
            //currLine.AddPoint(hand.transform.position);
            
            if (isWater && (numClicks % 10 == 0))
            {
                currLine.AddPoint(hand.transform.position);
            }
            else if (!isWater)
            {
                currLine.AddPoint(hand.transform.position);
            }
            
            
            numClicks++;
        }

        if (currLine != null)
        {
            currLine.lmat.color = Color.black;
        }
    }
}
