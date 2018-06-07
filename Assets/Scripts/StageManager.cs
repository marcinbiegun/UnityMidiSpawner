using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public List<GameObject> stages;
    
    public void Setup()
    {
    }

    public void ChangeActiveStage(int index)
    {
        for (var i = 0; i < stages.Count; i++)
            stages[i].SetActive(i == index);
    }

}
