using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Implementation of a state machine.
    /// </summary>
    /// <typeparam name="D">Type of the handled data.</typeparam>
    public class Machine<D> : IMachine<D>
    {
        /// <summary>
        /// Handled data.
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Default transition for state machine.
        /// </summary>
        /// <remarks>This transition is fired when the machine starts.</remarks>
        public ITransition<D> DefaultTransition { get; set; }
        /// <summary>
        /// Current state.
        /// </summary>
        public IState<D> CurrentState { get; set; }

        /// <summary>
        /// Fire an event on the current state to raise a state transition.
        /// </summary>
        /// <param name="e">Event to fire.</param>
        public void BroadcastEvent(IMachineEvent e)
        {
            CurrentState.Data = Data;
            var s = CurrentState.ReceiveEvent(e);
            if (s != null) CurrentState = s;
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Machine()
        {
            DefaultTransition = Transition<D>.Default;
            CurrentState = new MachineState<D>() { Name = "Default" };
            CurrentState.Transitions.Add(DefaultTransition);
        }
    }
}
