using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionTracker : MonoBehaviour
{
    public float[] intersectionID = new float[2];
    public int instanceID;

    // Start is called before the first frame update
    void Start()
    {
        intersectionID[0] = transform.position.x / 10;
        intersectionID[1] = transform.position.z / 10;
        //instanceID = GetInstanceID();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
