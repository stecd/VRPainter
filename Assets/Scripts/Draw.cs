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
    private MeshLineRenderer currLine;
    private int numClicks = 0;
     

    // Start is called before the first frame update
    void Start()
    {
        currLine = new MeshLineRenderer();
    }

    // Update is called once per frame
    void Update()
    {

        float triggerVal = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (triggerVal < 0.5 && triggerVal > 0.3) 
        {
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            go.transform.SetParent(drawingParent.transform);
            currLine = go.AddComponent<MeshLineRenderer>();
            currLine.lmat = new Material(lineMat);
            currLine.setWidth(lineWidth);
            Debug.Log("PRINT");
            Debug.Log(currLine);
            numClicks = 0;

            if (isWater)
            {
                currLine.gameObject.AddComponent<Water>();
            }
        }
        else if (triggerVal > 0.8)
        {
            Debug.Log("PRINT");
            Debug.Log(currLine);

            if (isWater && (numClicks % 10 == 0))
            {
                Debug.Log("HERE");
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
