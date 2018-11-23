using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public int amount = 10;
    public float space = .1f;

    private GameObject[] spawnedObjects;

	// Use this for initialization
	void Start () {
        spawnedObjects = new GameObject[amount];
        for (int i=0; i < amount; i++) {
            spawnedObjects[i] = Instantiate(spawnPrefab, transform);
            spawnedObjects[i].transform.Translate(Vector3.forward * space * (float) i);
        }
        transform.Translate(Vector3.forward * space * (float) (-amount/2));
	}

	
	// Update is called once per frame
	void Update () {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }
}
