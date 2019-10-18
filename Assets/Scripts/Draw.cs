using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    public Material lineMat;
    public GameObject hand;
    public float lineWidth = 0.1f;
    public GameObject drawingParent;
    private LineRenderer line;
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

        float triggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (triggerVal < 0.5 && triggerVal > 0.3) 
        {
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            go.transform.SetParent(drawingParent.transform);
            currLine = go.AddComponent<MeshLineRenderer>();
            //currLine.gameObject.AddComponent<Water>();
            currLine.lmat = new Material(lineMat);
            currLine.setWidth(lineWidth);

            numClicks = 0;
        }
        else if (triggerVal > 0.8)
        {
            currLine.AddPoint(hand.transform.position);
            numClicks++;
        }

        if (currLine != null)
        {
            currLine.lmat.color = Color.black;
        }
    }
}
