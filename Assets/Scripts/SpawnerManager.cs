using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    public GameObject spawnsHolder;
    public List<GameObject> spawners;

    public void Setup()
    {
        // Create a holder for instantiated spawns
        if (spawnsHolder == null)
            spawnsHolder = new GameObject(name: "SpawnsHolder") as GameObject;

        // Find spawners
        spawners.Clear();
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
            spawners.Add(spawner);
        //spawners.Sort((x, y) => x.transform.GetSiblingIndex().CompareTo(y.transform.GetSiblingIndex()));
        spawners.Sort((x, y) => x.GetComponent<Spawner>().trackId.CompareTo(y.GetComponent<Spawner>().trackId));
    }

    public bool GetSpawnerState(int index)
    {
        return spawners[index].GetComponent<Spawner>().state;
    }

    public void SetSpawnerState(int index, bool state)
    {
        spawners[index].GetComponent<Spawner>().state = state;
    }

    public void Restart() {
        // Nothing to do currently
    }

}
