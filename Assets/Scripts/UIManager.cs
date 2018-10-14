using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UIManager : MonoBehaviour
{
    public Dropdown stageDropdown;

    public void Setup()
    {
        stageDropdown.onValueChanged.AddListener(delegate {
            GameManager.instance.ChangeStage(stageDropdown.value);
        });
    }

    public void SetStageDropdownValue(int value) {
        stageDropdown.value = value;
    }


}