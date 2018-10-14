using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public UIManager uiManager;
    public AudioManager audioManager;
    public StageManager stageManager;
    public GameObject spawnsHolder;

    void Awake()
    {
        Application.targetFrameRate = 60;

        // Make self a publicly available singleton
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }

        // Never destroy gameManager (on scene changes)
        DontDestroyOnLoad(gameObject);

        // Store reference to other manager intances
        uiManager = GetComponent<UIManager>();
        audioManager = GetComponent<AudioManager>();
        stageManager = GetComponent<StageManager>();

        if (spawnsHolder == null)
        {
            spawnsHolder = new GameObject(name: "SpawnsHolder") as GameObject;
            spawnsHolder.transform.SetParent(null);
        }

        Setup();
    }

    void Setup()
    {
        uiManager.Setup();
        audioManager.Setup();
        stageManager.Setup();
        //ChangeStage(0);
    }

    public void ChangeStage(int index)
    {
        stageManager.ChangeActiveStage(index);
        uiManager.SetStageDropdownValue(index);
        audioManager.Restart();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            Application.Quit();

    }
}
