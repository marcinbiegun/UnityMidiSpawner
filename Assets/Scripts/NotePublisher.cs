using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotePublisher : MonoBehaviour {

    public int Track = 0;
    private float[] lastNoteValues = new float[128];

    void Update () {
        for (int note = 0; note < 128; note++)
        {
            float noteValue = GetComponent<MidiAnim.MidiState>().ReadNoteValue(note);
            float lastNoteValue = lastNoteValues[note];
            if (noteValue > 0f && lastNoteValue == 0f)
                EmitNote(note, noteValue);
            lastNoteValues[note] = noteValue;
        }

    }
	
	void EmitNote (int note, float power) {
        var msg = new NoteEvent { Note = note, Power = power, Track = Track };
        MessageBroker.Default.Publish(msg);
    }
}
