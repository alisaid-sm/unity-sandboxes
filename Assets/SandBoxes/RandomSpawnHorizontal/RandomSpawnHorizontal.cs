using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnHorizontal : MonoBehaviour
{
    public float radius = 20f;
    public float _delay = 10f;
    public GameObject prefab;
    private float _cdCounter;

    // Start is called before the first frame update
    void Start()
    {
        _cdCounter = _delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cdCounter > 0)
        {
            // reduce counter with delta time every frame
            _cdCounter -= Time.deltaTime;

            if (_cdCounter <= 0)
            {
                // when counter is zero doing somethings there
                Vector3 randomPos = GetRandomPosition(radius);

                if (prefab) {
                    Instantiate(prefab, randomPos, Quaternion.identity);
                }

                // last step, refill the counter with determined delay
                // the something action will doing every determined delay
                _cdCounter = _delay;
            }
        }
    }

    public Vector3 GetRandomPosition(float maxRadius)
    {
        // Generate a random angle between 0 and 2π radians (360 degrees)
        float angle = Random.Range(0f, Mathf.PI * 2);

        float radius = Random.Range(0f, maxRadius);

        // Calculate the X and Z positions based on the angle
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Assuming you want the random position at a specific height (Y value)
        // For example, let's keep it at the same height as the sphere's center
        float y = transform.position.y; // Adjust Y as needed

        // Return the random position
        return new Vector3(x, y, z);
    }
}
