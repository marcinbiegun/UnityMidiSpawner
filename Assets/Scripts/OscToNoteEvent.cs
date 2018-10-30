using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UniRx;

public class OscToNoteEvent : MonoBehaviour {
    public OSC oscReference;
    public int OscTrack;
    public int EmitTrack;
    private float[] lastNoteValues = new float[128];

    // Use this for initialization
    void Start() {
        oscReference.SetAllMessageHandler(OnReceive);
        //oscReference.SetAddressHandler("/ch1n62", OnReceive);
    }

    void OnReceive(OscMessage message) {
        int track = 0;
        int note = 0;

        Match match = Regex.Match(message.address, @"\d+");

        if (match.Success) {
            track = System.Convert.ToInt32(match.Value);
        }
        match = match.NextMatch();
        if (match.Success) {
            note = System.Convert.ToInt32(match.Value);
        }

        // No data
        if (track == 0 || note == 0) {
            return;
        }

        if (track != OscTrack) {
            return;
        }

        float value = message.GetFloat(0);
        float lastNoteValue = lastNoteValues[note];

        if (value > 0f && lastNoteValue == 0f) {
            EmitNote(note, value);
        }

        //if (value > 0f) {
        //    EmitNote(note, value);
        //}

        lastNoteValues[note] = value;
        //float scaled = Mathf.Lerp(0.1f, 4f, data); // Scale to new range
    }


    void EmitNote(int note, float power) {
        var msg = new NoteEvent { Note = note, Power = power, Track = EmitTrack };
        MessageBroker.Default.Publish(msg);
        Debug.Log("track " + OscTrack + ", note " + note);  
    }    // Update is called once per frame
}
