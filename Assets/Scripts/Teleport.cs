using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float speed;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 triggerVal = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        player.transform.position += new Vector3(-triggerVal.y, 0.0f, triggerVal.x) * speed * Time.deltaTime;

    }
}
