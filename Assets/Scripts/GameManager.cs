﻿using System.Collections;using System.Collections.Generic;using UnityEngine;public class GameManager : MonoBehaviour{    //public MapManager mapManager;    //public PlayerManager playerManager;    public static GameManager instance = null;    public GameObject spawner7;    public GameObject spawner8;    public GameObject spawner9;    public void ToggleSpawnerId(int spawnerId)    {        switch (spawnerId)        {            case 7:                ToggleSpawner(spawner7);                break;            case 8:                ToggleSpawner(spawner8);                break;            case 9:                ToggleSpawner(spawner9);                break;        }    }    private void ToggleSpawner(GameObject spawner)    {        spawner.GetComponent<Spawner>().ToggleSpawning();    }    void Awake()    {        if (instance == null)        {            instance = this;        }        else if (instance != this)        {            Destroy(gameObject);        }        DontDestroyOnLoad(gameObject);        //mapManager = GetComponent<MapManager>();        //playerManager = GetComponent<PlayerManager>();        InitGame();    }    void InitGame()    {        //mapManager.SetupScene(level);        //playerManager.SetupPlayer();    }    // Update is called once per frame    void Update()    {        // Close the app on ESC key        if (Input.GetKeyDown("escape"))        {            Application.Quit();        }    }}