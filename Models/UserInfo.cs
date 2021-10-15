using System;
using System.Collections;
using System.Collections.Generic;

namespace SignalRtcModels
{
    public class RoomInfo
    {
        public string RoomId { get; set; }
        public List<object> peerConnections { get; set; }
    }
}
