using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{

    public Sprite spriteImage;
    //public Sprite[] sprites;
    public GameObject drawingParent;
    public GameObject hand;
    public float size;
    public float spread;
    public bool isSelected;

    private SpriteRenderer sprite;
    private int numClicks = 0;
    private GameObject currStamp;
    private Quaternion stampRotation;
    private int listSize;

    // Start is called before the first frame update
    void Start()
    {
        //listSize = sprites.Length;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isSelected)
            return;

        float triggerVal = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        currStamp = new GameObject("Stroke");
        currStamp.transform.SetParent(drawingParent.transform);

        if (triggerVal < 0.5 && triggerVal > 0.3)
        {
            currStamp.transform.position = hand.transform.position;
            stampRotation = hand.transform.rotation;
            numClicks = 0;
        }

        else if (triggerVal > 0.8)
        {
            GameObject go = new GameObject("ChildOfStroke");
            go.transform.position = hand.transform.position;
            go.transform.localScale = new Vector3(size, size, size);
            sprite = go.AddComponent<SpriteRenderer>();
            go.transform.SetParent(currStamp.transform);
            BoxCollider collider = go.AddComponent<BoxCollider>();
            collider.size = new Vector3(4.0f, 3.0f, 1.0f);
            collider.isTrigger = true;
            go.isStatic = true;
            sprite.sprite = spriteImage;
            //sprite.sprite = sprites[numClicks % listSize];
            numClicks++;
        }

    }
}
