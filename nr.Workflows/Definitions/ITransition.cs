using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// A state's transition.
    /// </summary>
    /// <typeparam name="D">Type of the handled data.</typeparam>
    public interface IWorkflowTransition<D>
    {
        /// <summary>
        /// Current state.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// Starting state.
        /// </summary>
        IState<D> From { get; set; }
        /// <summary>
        /// Ending state.
        /// </summary>
        IState<D> To { get; set; }
        /// <summary>
        /// Event that fires the transition.
        /// </summary>
        IMachineEvent Event { get; set; }
        /// <summary>
        /// Atomic action to run for transition completion.
        /// </summary>
        Action<D, IMachineEvent> Action { get; set; }
        /// <summary>
        /// Guard to limit transition execution.
        /// </summary>
        Func<D, IMachineEvent, bool> Guard { get; set; }
    }
}
