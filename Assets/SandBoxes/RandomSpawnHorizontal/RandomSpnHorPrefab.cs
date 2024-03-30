using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpnHorPrefab : MonoBehaviour
{
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity != Vector3.zero) _rb.velocity = Vector3.zero;
    }
}
