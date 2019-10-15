using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    public Material lineMat;
    public GameObject hand;
    private LineRenderer line;
    private MeshLineRenderer currLine;
    private int numClicks = 0;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (triggerVal < 0.3) 
        {
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();

            currLine.lmat = new Material(lineMat);
            currLine.setWidth(0.1f);

            numClicks = 0;
        }
        else
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
