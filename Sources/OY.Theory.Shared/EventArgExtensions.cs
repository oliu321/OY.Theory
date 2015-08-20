﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
        {
            // Copy a reference to the delegate field now into a temporary field for thread safety
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

            // If any methods registered interest with our event, notify them
            if (temp != null) temp(sender, e);
        }
    }
}
