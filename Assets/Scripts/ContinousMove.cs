using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousMove : MonoBehaviour {

    public Vector3 velocity;

	void Update () {
        transform.Translate(velocity * Time.deltaTime);
	}
}
