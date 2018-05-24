using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject spawnsHolder;
    public bool spawningEnabled = false;
    public float spawnThurst = 1f;

    public int[] notes;
    private float[] lastNoteValues = new float[10];

    public void ToggleSpawning()
    {
        bool newState = !spawningEnabled;
        spawningEnabled = newState;

        if (newState == true)
        {
            GetComponent<AudioSource>().volume = 1;
        } else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }

    void Start()
    {
        //Debug.Log("animator " + GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.wrapMode);
        for (int index = 0; index < notes.Length; index++)
        {
            lastNoteValues[index] = 0f;
        }
    }

	void Update () {
        //Debug.Log("wrapmode " + GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.wrapMode);
        if (spawningEnabled == false) { return; }

        for (int index = 0; index < notes.Length; index++)
        {
            int note = notes[index];
            float noteValue = GetComponent<MidiAnim.MidiState>().ReadNoteValue(note);
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
        Vector3 randomDirection = Random.insideUnitSphere;
        Quaternion randomRotation = Random.rotation;

        float offset = 2f;
        Vector3 positionOffset = new Vector3(0f, 0f, (offset * index) - (notes.Length / 2) * offset);

        GameObject newObject = Instantiate(spawnPrefab, transform.position + positionOffset, randomRotation);
        newObject.transform.SetParent(spawnsHolder.transform);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.AddForce(randomDirection * spawnThurst);
    }
	
}
