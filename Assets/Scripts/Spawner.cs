using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public int trackId;
    public GameObject spawnPrefab;
    public bool state = false;
    public float forwardThurst = 250f;
    public float randomThurst = 0f;

    public int[] notes;
    private float[] lastNoteValues = new float[10];

    void Start()
    {
        state = false;
        for (int index = 0; index < notes.Length; index++)
            lastNoteValues[index] = 0f;
    }

	void Update () {
        if (state == false) { return; }

        for (int index = 0; index < notes.Length; index++)
        {
            int noteId = notes[index];
            float noteValue = GetComponent<MidiAnim.MidiState>().ReadNoteValue(noteId);
            float lastNoteValue = lastNoteValues[index];
            if (noteValue > 0 && lastNoteValue == 0)
                Spawn(index);
            lastNoteValues[index] = noteValue;
        }
	}

    private void Spawn(int index)
    {
        Quaternion randomRotation = Random.rotation;
        float offset = 2f;
        Vector3 positionOffset = new Vector3(0f, 0f, (offset * index) - (notes.Length / 2) * offset);

        GameObject newObject = Instantiate(spawnPrefab, transform.position + positionOffset, randomRotation);
        newObject.transform.SetParent(GameManager.instance.spawnerManager.spawnsHolder.transform);

        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * forwardThurst);
        rigidbody.AddForce(Random.insideUnitSphere * randomThurst);
    }
	
}
