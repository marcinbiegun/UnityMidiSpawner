using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] spawnerButtons;
    public Dropdown stageDropdown;

    public void Setup()
    {
        // Add listeners for spawner buttons
        for (int index = 0; index < spawnerButtons.Length; index++)
        {
            var button = spawnerButtons[index];
            SetSpawnerButtonState(index, false);
            var delegateIndex = index;
            button.onClick.AddListener(delegate {
                GameManager.instance.ToggleTrackState(delegateIndex);
            });
        }

        stageDropdown.onValueChanged.AddListener(delegate {
            GameManager.instance.ChangeStage(stageDropdown.value);
        });
    }

    public void SetSpawnerButtonState(int index, bool newState)
    {
        spawnerButtons[index].colors = GetButtonColorBlock(newState);
    }

    public bool GetSpawnerButtonState(int index)
    {
        return spawnerButtons[index].colors == GetButtonColorBlock(true);
    }

    public void SetStageDropdownValue(int value) {
        stageDropdown.value = value;
    }

    ColorBlock GetButtonColorBlock(bool state)
    {
        if (state)
        {
            return ColorBlock.defaultColorBlock;
        } else
        {
            var disabledColors = ColorBlock.defaultColorBlock;
            disabledColors.normalColor = Color.gray;
            disabledColors.highlightedColor = Color.gray;
            disabledColors.pressedColor = Color.gray;
            return disabledColors;
        }
    }

}