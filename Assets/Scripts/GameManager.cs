using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public UIManager uiManager;
    public AudioManager audioManager;
    public SpawnerManager spawnerManager;
    public StageManager stageManager;

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
        spawnerManager = GetComponent<SpawnerManager>();
        stageManager = GetComponent<StageManager>();

        Setup();
    }

    void Setup()
    {
        uiManager.Setup();
        audioManager.Setup();
        stageManager.Setup();
        spawnerManager.Setup();
    }

    public void ToggleTrackState(int index) {
        bool newState = !spawnerManager.GetSpawnerState(index);

        spawnerManager.SetSpawnerState(index, newState);
        uiManager.SetSpawnerButtonState(index, newState);
        audioManager.SetAudioState(index, newState);
    }

    public void ChangeStage(int index)
    {
        stageManager.ChangeActiveStage(index);
        uiManager.SetStageDropdownValue(index);
        spawnerManager.Setup();
        for (int i = 0; i < uiManager.spawnerButtons.Length; i++) {
            spawnerManager.SetSpawnerState(i, uiManager.GetSpawnerButtonState(i));
        }
    }

    void Update()
    {
        // Close the app on ESC key
        if (Input.GetKeyDown("escape"))
            Application.Quit();

    }
}
