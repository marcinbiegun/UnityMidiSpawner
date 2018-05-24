// MidiAnimImporter - MIDI animation importer
// https://github.com/keijiro/MidiAnimImporter

using UnityEngine;

namespace MidiAnim
{
    // Placeholder for MIDI parameters
    public class MidiState : MonoBehaviour
    {
        public float BeatCount;
        public float BeatClock;

        public float BarCount;
        public float BarClock;

        // HACK: fix accessing array properties
        public float Note24;
        public float Note36;
        public float Note38;
        public float Note40;
        public float Note43;
        public float Note45;
        public float Note48;
        public float Note50;

        public float [] CC = new float [128];
        public float [] Note = new float [128];

        public float ReadNoteValue(int noteId)
        {
            switch (noteId)
            {
                case 24:
                    return Note24;
                case 36:
                    return Note36;
                case 38:
                    return Note38;
                case 40:
                    return Note40;
                case 43:
                    return Note43;
                case 45:
                    return Note45;
                case 48:
                    return Note48;
                case 50:
                    return Note50;
            }
            return 0f;
        }
    }
}
