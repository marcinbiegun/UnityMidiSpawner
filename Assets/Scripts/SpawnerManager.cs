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
        spawners.Sort((x, y) => x.GetComponent<SpawnerRx>().trackId.CompareTo(y.GetComponent<SpawnerRx>().trackId));
    }

    public bool GetSpawnerState(int index)
    {
        return spawners[index].activeInHierarchy;
    }

    public void SetSpawnerState(int index, bool state)
    {
        spawners[index].SetActive(state);
    }

    public void Restart() {
        // Nothing to do currently
    }

}
