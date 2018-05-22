using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject spawnsHolder;

    public float spawnThurst = 1f;

	// Use this for initialization
	void Start () {
	}

    void OnEnable() {
        Vector3 randomDirection = Random.insideUnitSphere;
        Quaternion randomRotation = Random.rotation;

        GameObject newObject = Instantiate(spawnPrefab, transform.position, randomRotation);
        newObject.transform.SetParent(spawnsHolder.transform);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.AddForce(randomDirection * spawnThurst);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
