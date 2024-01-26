using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeriodeWithoutIEnumerator : MonoBehaviour
{
    public float _delay = 1f;
    private float _cdCounter;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        // init value counter
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
                int textInt = int.Parse(text.text);
                text.text = $"{textInt + 1}";

                // last step, refill the counter with determined delay
                // the something action will doing every determined delay
                _cdCounter = _delay;
            }
        }
    }
}
