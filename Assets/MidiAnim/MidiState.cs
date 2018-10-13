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

        public float [] CC = new float [128];
        public float [] Note = new float [128];

        // HACK: fix accessing array properties
        public float Note0;
        public float Note1;
        public float Note2;
        public float Note3;
        public float Note4;
        public float Note5;
        public float Note6;
        public float Note7;
        public float Note8;
        public float Note9;
        public float Note10;
        public float Note11;
        public float Note12;
        public float Note13;
        public float Note14;
        public float Note15;
        public float Note16;
        public float Note17;
        public float Note18;
        public float Note19;
        public float Note20;
        public float Note21;
        public float Note22;
        public float Note23;
        public float Note24;
        public float Note25;
        public float Note26;
        public float Note27;
        public float Note28;
        public float Note29;
        public float Note30;
        public float Note31;
        public float Note32;
        public float Note33;
        public float Note34;
        public float Note35;
        public float Note36;
        public float Note37;
        public float Note38;
        public float Note39;
        public float Note40;
        public float Note41;
        public float Note42;
        public float Note43;
        public float Note44;
        public float Note45;
        public float Note46;
        public float Note47;
        public float Note48;
        public float Note49;
        public float Note50;
        public float Note51;
        public float Note52;
        public float Note53;
        public float Note54;
        public float Note55;
        public float Note56;
        public float Note57;
        public float Note58;
        public float Note59;
        public float Note60;
        public float Note61;
        public float Note62;
        public float Note63;
        public float Note64;
        public float Note65;
        public float Note66;
        public float Note67;
        public float Note68;
        public float Note69;
        public float Note70;
        public float Note71;
        public float Note72;
        public float Note73;
        public float Note74;
        public float Note75;
        public float Note76;
        public float Note77;
        public float Note78;
        public float Note79;
        public float Note80;
        public float Note81;
        public float Note82;
        public float Note83;
        public float Note84;
        public float Note85;
        public float Note86;
        public float Note87;
        public float Note88;
        public float Note89;
        public float Note90;
        public float Note91;
        public float Note92;
        public float Note93;
        public float Note94;
        public float Note95;
        public float Note96;
        public float Note97;
        public float Note98;
        public float Note99;
        public float Note100;
        public float Note101;
        public float Note102;
        public float Note103;
        public float Note104;
        public float Note105;
        public float Note106;
        public float Note107;
        public float Note108;
        public float Note109;
        public float Note110;
        public float Note111;
        public float Note112;
        public float Note113;
        public float Note114;
        public float Note115;
        public float Note116;
        public float Note117;
        public float Note118;
        public float Note119;
        public float Note120;
        public float Note121;
        public float Note122;
        public float Note123;
        public float Note124;
        public float Note125;
        public float Note126;
        public float Note127;


        public float ReadNoteValue(int noteId)
        {
            switch (noteId)
            {
                case 0:
                    return Note0;
                case 1:
                    return Note1;
                case 2:
                    return Note2;
                case 3:
                    return Note3;
                case 4:
                    return Note4;
                case 5:
                    return Note5;
                case 6:
                    return Note6;
                case 7:
                    return Note7;
                case 8:
                    return Note8;
                case 9:
                    return Note9;
                case 10:
                    return Note10;
                case 11:
                    return Note11;
                case 12:
                    return Note12;
                case 13:
                    return Note13;
                case 14:
                    return Note14;
                case 15:
                    return Note15;
                case 16:
                    return Note16;
                case 17:
                    return Note17;
                case 18:
                    return Note18;
                case 19:
                    return Note19;
                case 20:
                    return Note20;
                case 21:
                    return Note21;
                case 22:
                    return Note22;
                case 23:
                    return Note23;
                case 24:
                    return Note24;
                case 25:
                    return Note25;
                case 26:
                    return Note26;
                case 27:
                    return Note27;
                case 28:
                    return Note28;
                case 29:
                    return Note29;
                case 30:
                    return Note30;
                case 31:
                    return Note31;
                case 32:
                    return Note32;
                case 33:
                    return Note33;
                case 34:
                    return Note34;
                case 35:
                    return Note35;
                case 36:
                    return Note36;
                case 37:
                    return Note37;
                case 38:
                    return Note38;
                case 39:
                    return Note39;
                case 40:
                    return Note40;
                case 41:
                    return Note41;
                case 42:
                    return Note42;
                case 43:
                    return Note43;
                case 44:
                    return Note44;
                case 45:
                    return Note45;
                case 46:
                    return Note46;
                case 47:
                    return Note47;
                case 48:
                    return Note48;
                case 49:
                    return Note49;
                case 50:
                    return Note50;
                case 51:
                    return Note51;
                case 52:
                    return Note52;
                case 53:
                    return Note53;
                case 54:
                    return Note54;
                case 55:
                    return Note55;
                case 56:
                    return Note56;
                case 57:
                    return Note57;
                case 58:
                    return Note58;
                case 59:
                    return Note59;
                case 60:
                    return Note60;
                case 61:
                    return Note61;
                case 62:
                    return Note62;
                case 63:
                    return Note63;
                case 64:
                    return Note64;
                case 65:
                    return Note65;
                case 66:
                    return Note66;
                case 67:
                    return Note67;
                case 68:
                    return Note68;
                case 69:
                    return Note69;
                case 70:
                    return Note70;
                case 71:
                    return Note71;
                case 72:
                    return Note72;
                case 73:
                    return Note73;
                case 74:
                    return Note74;
                case 75:
                    return Note75;
                case 76:
                    return Note76;
                case 77:
                    return Note77;
                case 78:
                    return Note78;
                case 79:
                    return Note79;
                case 80:
                    return Note80;
                case 81:
                    return Note81;
                case 82:
                    return Note82;
                case 83:
                    return Note83;
                case 84:
                    return Note84;
                case 85:
                    return Note85;
                case 86:
                    return Note86;
                case 87:
                    return Note87;
                case 88:
                    return Note88;
                case 89:
                    return Note89;
                case 90:
                    return Note90;
                case 91:
                    return Note91;
                case 92:
                    return Note92;
                case 93:
                    return Note93;
                case 94:
                    return Note94;
                case 95:
                    return Note95;
                case 96:
                    return Note96;
                case 97:
                    return Note97;
                case 98:
                    return Note98;
                case 99:
                    return Note99;
                case 100:
                    return Note100;
                case 101:
                    return Note101;
                case 102:
                    return Note102;
                case 103:
                    return Note103;
                case 104:
                    return Note104;
                case 105:
                    return Note105;
                case 106:
                    return Note106;
                case 107:
                    return Note107;
                case 108:
                    return Note108;
                case 109:
                    return Note109;
                case 110:
                    return Note110;
                case 111:
                    return Note111;
                case 112:
                    return Note112;
                case 113:
                    return Note113;
                case 114:
                    return Note114;
                case 115:
                    return Note115;
                case 116:
                    return Note116;
                case 117:
                    return Note117;
                case 118:
                    return Note118;
                case 119:
                    return Note119;
                case 120:
                    return Note120;
                case 121:
                    return Note121;
                case 122:
                    return Note122;
                case 123:
                    return Note123;
                case 124:
                    return Note124;
                case 125:
                    return Note125;
                case 126:
                    return Note126;
                case 127:
                    return Note127;
            }
            return 0f;
        }
    }
}
