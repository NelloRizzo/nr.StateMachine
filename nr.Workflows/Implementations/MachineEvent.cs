using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Base event to define all events to fire transitions.
    /// </summary>
    public class MachineEvent : IMachineEvent
    {
        /// <summary>
        /// Event name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get the hash code for the current instance.
        /// </summary>
        /// <returns>Returns the hash code for the current instance.</returns>
        public override int GetHashCode() => Name.ToLowerInvariant().GetHashCode();
        /// <summary>
        /// Gets the string representation for the current instance.
        /// </summary>
        /// <returns>Returns the string representation for the current instance.</returns>
        public override string ToString() => Name;
        /// <summary>
        /// Compare this instance with another.
        /// </summary>
        /// <param name="obj">Other instance.</param>
        /// <returns>Returns a boolean value that indicates if the current instance
        /// is equal to another.</returns>
        public override bool Equals(object obj) =>
            obj is IMachineEvent ? GetHashCode() == obj.GetHashCode() : false;
        /// <summary>
        /// Cast to string.
        /// </summary>
        /// <param name="e">Machine event to convert in string.</param>
        public static explicit operator string(MachineEvent e)
            => e.Name;
        /// <summary>
        /// Cast from string.
        /// </summary>
        /// <param name="eventName">String to convert in machine event.</param>
        public static explicit operator MachineEvent(string eventName)
            => new MachineEvent() { Name = eventName };
        /// <summary>
        /// Istance of event to fire default transition.
        /// </summary>
        public static IMachineEvent Start { get => new MachineEvent() { Name = "evStart" }; }
    }
}
