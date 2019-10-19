using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    private LineRenderer teleportLine;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public Material lineMaterial;
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 triggerVal = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (triggerVal[1] > 0.8)
        {
            GameObject go = new GameObject();
            teleportLine = go.AddComponent<LineRenderer>();
            teleportLine.material = new Material(lineMaterial);
            teleportLine.widthMultiplier = 0.2f;
            // A simple 2 color gradient with a fixed alpha of 1.0f.
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            teleportLine.colorGradient = gradient;

            var t = Time.time;

            teleportLine.SetPosition(0, hand.transform.forward);

            //RaycastHit hit;
            //if ( Physics.Raycast(hand.transform.position, hand.transform.forward, out hit, 100.0f)) {
            //    print("Found an object - distance: " + hit.distance);
            //    teleportLine.SetPosition(1, hit.point);

            //}

        }

    }
}
