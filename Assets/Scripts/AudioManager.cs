﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<GameObject> audioTracks;

    public void Setup()
    {
        // Find audio tracks
        audioTracks.Clear();
        foreach (var audioTrack in GameObject.FindGameObjectsWithTag("AudioTrack"))
            audioTracks.Add(audioTrack);
        audioTracks.Sort((x, y) => x.transform.GetSiblingIndex().CompareTo(y.transform.GetSiblingIndex()));

        // Disable all by default
        for (int index = 0; index < audioTracks.Count; index++)
            SetAudioState(index, false);
    }

    public void SetAudioState(int index, bool state)
    {
        audioTracks[index].GetComponent<AudioSource>().volume = state ? 1 : 0;
    }

}
