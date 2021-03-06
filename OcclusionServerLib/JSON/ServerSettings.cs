using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.JSON
{
    public class ServerSettings
    {
        public int ServerPort { get; set; } = 9755;

        public string GameIP { get; set; } = "";

        public string GamePort { get; set; } = "";

        public float HearingDistance { get; set; } = 78;

        public bool EnableVoiceIconMeterOnClients { get; set; } = true;
    }
}
