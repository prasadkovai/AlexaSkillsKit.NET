﻿using Newtonsoft.Json.Linq;
using System;

namespace AlexaSkillsKit.Speechlet
{
    /// <summary>
    /// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#playbackfailed
    /// </summary>
    public class PlaybackState
    {
        public static PlaybackState FromJson(JObject json) {
            if (json == null) return null;

            PlayerActivityEnum playerActivity = PlayerActivityEnum.NONE;
            Enum.TryParse(json.Value<string>("playerActivity"), out playerActivity);
            return new PlaybackState {
                Token = json.Value<string>("token"),
                OffsetInMilliseconds = json.Value<long>("playerActivity"),
                PlayerActivity = playerActivity
            };
        }

        public string Token {
            get;
            private set;
        }

        public long? OffsetInMilliseconds {
            get;
            private set;
        }

        public PlayerActivityEnum PlayerActivity {
            get;
            private set;
        }

        public enum PlayerActivityEnum
        {
            NONE = 0, // default in case parsing fails
            PLAYING,
            PAUSED,
            FINISHED,
            BUFFER_UNDERRUN,
            IDLE
        }
    }
}