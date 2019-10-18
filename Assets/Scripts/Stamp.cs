using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{

    public Sprite spriteImage;
    public Sprite[] sprites;
    public GameObject drawingParent;
    public GameObject hand;
    public float size;
    public float spread;

    private SpriteRenderer sprite;
    private int numClicks = 0;
    private GameObject currStamp;
    private Quaternion stampRotation;
    private int listSize;

    // Start is called before the first frame update
    void Start()
    {
        listSize = sprites.Length;
        currStamp = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        if (triggerVal < 0.5 && triggerVal > 0.3)
        {
            currStamp = new GameObject();
            currStamp.transform.SetParent(drawingParent.transform);
            stampRotation = hand.transform.rotation;
            numClicks = 0;
        }

        else if (triggerVal > 0.8)
        {
            GameObject go = new GameObject();
            go.transform.position = hand.transform.position;
            go.transform.localScale = new Vector3(size, size, size);
            sprite = go.AddComponent<SpriteRenderer>();
            go.transform.SetParent(currStamp.transform);
            sprite.sprite = sprites[numClicks % listSize];
            numClicks++;
        }

    }
}
