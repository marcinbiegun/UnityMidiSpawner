using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TrackToggleController : MonoBehaviour {

    public int Track = 0;

    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(delegate { ToggleTrack(); });
    }

    void ToggleTrack()
    {
        EmitTrackChange(!GetButtonState());
        gameObject.GetComponent<Button>().colors = BuildColorBlock(!GetButtonState());
    }

    void SetButtonState(int index, bool newState)
    {
        gameObject.GetComponent<Button>().colors = BuildColorBlock(newState);
    }

    bool GetButtonState()
    {
        return gameObject.GetComponent<Button>().colors == BuildColorBlock(true);
    }

    void EmitTrackChange(bool state)
    {
        var msg = new TrackEvent { Track = Track, State = state };
        MessageBroker.Default.Publish(msg);
    }

    ColorBlock BuildColorBlock(bool state)
    {
        if (state)
        {
            return ColorBlock.defaultColorBlock;
        }
        else
        {
            var disabledColors = ColorBlock.defaultColorBlock;
            disabledColors.normalColor = Color.gray;
            disabledColors.highlightedColor = Color.gray;
            disabledColors.pressedColor = Color.gray;
            return disabledColors;
        }
    }
}
