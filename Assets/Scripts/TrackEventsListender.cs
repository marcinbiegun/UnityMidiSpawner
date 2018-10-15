using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TrackEventsListender : MonoBehaviour {

    public int track = 0;

	void Awake() {
        MessageBroker.Default.Receive<TrackEvent>()
            .Where(e => e.Track == track)
            .Subscribe(e => SetTrackVolume(e.State));
    }
	
	void SetTrackVolume(bool state) {
        float volume = state == true ? 1f : 0f;
        GetComponent<AudioSource>().volume = volume;
	}
}
