using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.Backend
{
    public static class EventsManagerLib
    {
        public delegate void EventHandBroadcastHandler(string arg_strval, int arg_intval, bool arg_Bool0);
        public static event EventHandBroadcastHandler OnHandBroadcast;

        public static void CallHandBroadcast(string srg_str, int arg_int, bool arg_bool)
        {
            OnHandBroadcast?.Invoke(srg_str, arg_int, arg_bool);
        }
    }
}
