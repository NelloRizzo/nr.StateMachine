using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// A state transition.
    /// </summary>
    /// <typeparam name="D">Type of the handled data.</typeparam>
    public class Transition<D> : ITransition<D>
    {
        /// <summary>
        /// Current state of handled data.
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Start state.
        /// </summary>
        public IState<D> From { get; set; }
        /// <summary>
        /// End state.
        /// </summary>
        public IState<D> To { get; set; }
        /// <summary>
        /// Action to perform transition.
        /// </summary>
        public Action<D, IMachineEvent> Action { get; set; }
        /// <summary>
        /// Guard to limit transition.
        /// </summary>
        public Func<D, IMachineEvent, bool> Guard { get; set; }
        /// <summary>
        /// Event that fire this transition.
        /// </summary>
        public IMachineEvent Event { get; set; }
        /// <summary>
        /// Default transition.
        /// </summary>
        /// <remarks>This transition is fired at start of the machine.</remarks>
        public static ITransition<D> Default
        {
            get => new Transition<D>() { From = null, Event = MachineEvent.Start };
        }
    }
}
