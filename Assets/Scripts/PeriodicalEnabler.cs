using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicalEnabler : MonoBehaviour {
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Update()
    {
        Debug.Log("siema  " + Time.time + "    " + nextActionTime + "   period: " + period);
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Debug.Log("TOGGLE");
            gameObject.SetActive(!gameObject.activeInHierarchy);

        }
    }
}
