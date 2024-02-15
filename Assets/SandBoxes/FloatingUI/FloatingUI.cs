using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    private Transform worldSpaceCanvas, unit;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        unit = transform.parent;
        worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        if (unit != null)
        {
            transform.position = unit.position + offset;
            transform.LookAt(transform.position + Camera.main.transform.forward, Camera.main.transform.up);
        }
    }
}
