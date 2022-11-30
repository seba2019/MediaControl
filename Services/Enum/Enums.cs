using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Enum
{
    public static class ActionHex
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int VK_VOLUME_DOWN = 0xAE;
        public const int VK_VOLUME_UP = 0xAF;
    }
    public enum eMediaAction
    {
        Play_Pause = 1, Stop, NextSong, PrevSong, UpVol, DownVol
    }

    public static class MediaAction
    {
        public static byte GetValue(eMediaAction action)
        {
            byte value = new byte();

            switch (action)
            {
                case eMediaAction.Play_Pause:
                    value = ActionHex.VK_MEDIA_PLAY_PAUSE;
                    break;
                case eMediaAction.Stop:
                    break;
                case eMediaAction.NextSong:
                    value = ActionHex.VK_MEDIA_NEXT_TRACK;
                    break;
                case eMediaAction.PrevSong:
                    value = ActionHex.VK_MEDIA_PREV_TRACK;
                    break;
                case eMediaAction.UpVol:
                    value = ActionHex.VK_VOLUME_UP;
                    break;
                case eMediaAction.DownVol:
                    value = ActionHex.VK_VOLUME_DOWN;
                    break;
            }

            return value;
        }
    }
}
