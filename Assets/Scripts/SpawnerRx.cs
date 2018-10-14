using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SpawnerRx : MonoBehaviour {

    public int track;
    public int centerNote = 40;
    public Vector3 noteSpread = new Vector3(0f, 0.1f, 0f);
    public GameObject spawnPrefab;
    public float forwardThurst = 250f;
    public float randomThurst = 0f;

    private System.IDisposable noteSubscription;
    private System.IDisposable trackSubscription;

    void Awake()
    {
        Debug.Log("AWAKE");
        noteSubscription = MessageBroker.Default.Receive<NoteEvent>()
            .Where(e => e.Track == track)
            .Subscribe(e => Spawn(e.Note, e.Power));
        trackSubscription = MessageBroker.Default.Receive<TrackEvent>()
            .Where(e => e.Track == track)
            .Subscribe(e => UpdateEnabled(e.State));
    }

    private void UpdateEnabled(bool state)
    {
        gameObject.SetActive(state);
        Debug.Log("received event on track update, setting " + state);
    }

    private void Spawn(int note, float power)
    {
        if (gameObject.activeInHierarchy == false) { return;  }

        Quaternion randomRotation = Random.rotation;
        Vector3 positionOffset = (centerNote - note) * noteSpread;

        GameObject newObject = Instantiate(spawnPrefab, transform.position + positionOffset, randomRotation);
        newObject.transform.SetParent(GameManager.instance.spawnsHolder.transform);

        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * forwardThurst);
        rigidbody.AddForce(Random.insideUnitSphere * randomThurst);
    }
	
}
