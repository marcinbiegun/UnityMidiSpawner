using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SpawnerRx : MonoBehaviour {

    public int trackId;
    public int centerNote = 40;
    public Vector3 noteSpread = new Vector3(0f, 0.1f, 0f);
    public GameObject spawnPrefab;
    public float forwardThurst = 250f;
    public float randomThurst = 0f;

    private System.IDisposable subscription;

    void Awake()
    {
        Subscribe();
    }

    void OnEnable()
    {
        Subscribe();
    }

    void OnDisable()
    {
        Unsubscribe();
    }

    void OnDestroy()
    {
        Unsubscribe();
    }

    void Subscribe()
    {
        if (subscription != null) { return; }
        subscription = MessageBroker.Default.Receive<NoteEvent>()
            .Where(e => e.Track == trackId)
            .Subscribe(e => Spawn(e.Note, e.Power));
    }

    void Unsubscribe()
    {
        if (subscription == null) { return; }
        subscription.Dispose();
        subscription = null;
    }

    private void Spawn(int note, float power)
    {
        Quaternion randomRotation = Random.rotation;
        Vector3 positionOffset = (centerNote - note) * noteSpread;

        GameObject newObject = Instantiate(spawnPrefab, transform.position + positionOffset, randomRotation);
        newObject.transform.SetParent(GameManager.instance.spawnerManager.spawnsHolder.transform);

        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * forwardThurst);
        rigidbody.AddForce(Random.insideUnitSphere * randomThurst);
    }
	
}
