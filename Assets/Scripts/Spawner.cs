using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject spawnsHolder;

    public float spawnThurst = 1f;

    public int spawnCounter = 0;
    public int succSpawnCounter = 0;

    public int[] notes;
    private float[] lastNoteValues = new float[10];

    void Start()
    {
        for (int index = 0; index < notes.Length; index++)
        {
            Debug.Log("initalizing array at index " + index);
            lastNoteValues[index] = 0f;
        }
    }

	void Update () {
        for (int index = 0; index < notes.Length; index++)
        {
            int note = notes[index];
            float noteValue = GetComponent<MidiAnim.MidiState>().ReadNoteValue(note);
            Debug.Log("Writing at index: " + index);
            float lastNoteValue = lastNoteValues[index];

            if (noteValue > 0 && lastNoteValue == 0)
            {
                Spawn(index);
            }

            lastNoteValues[index] = noteValue;
        }
	}

    private void Spawn(int index)
    {
        spawnCounter += 1;

        Vector3 randomDirection = Random.insideUnitSphere;
        Quaternion randomRotation = Random.rotation;

        float offset = 2f;
        Vector3 positionOffset = new Vector3(0f, 0f, (offset * index) - (notes.Length / 2) * offset);

        GameObject newObject = Instantiate(spawnPrefab, transform.position + positionOffset, randomRotation);
        newObject.transform.SetParent(spawnsHolder.transform);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.AddForce(randomDirection * spawnThurst);

        succSpawnCounter += 1;
    }
	
}
