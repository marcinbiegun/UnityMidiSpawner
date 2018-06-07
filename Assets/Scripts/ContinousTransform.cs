using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousTransform : MonoBehaviour {

    public Vector3 positionAdd;
    public Vector3 rotationAdd;
    public Vector3 scaleAdd;

    void Update()
    {
        transform.Translate(positionAdd * Time.deltaTime);
        transform.Rotate(rotationAdd * Time.deltaTime);
        transform.localScale += scaleAdd * Time.deltaTime;
    }
}
