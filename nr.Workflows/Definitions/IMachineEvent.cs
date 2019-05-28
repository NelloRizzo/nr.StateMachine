using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// An event that begin a state transition.
    /// </summary>
    public interface IMachineEvent
    {
        /// <summary>
        /// Event's name.
        /// </summary>
        string Name { get; set; }
    }
}
