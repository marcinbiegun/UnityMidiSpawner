using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManagerPrefab;

    // Use this for initialization
    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManagerPrefab);
    }
}
