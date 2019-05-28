using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// State of machine.
    /// </summary>
    /// <typeparam name="D">Type of the handled data.</typeparam>
    public  interface IState<D>
    {
        /// <summary>
        /// Handled data.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// State's name.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// List of transitions that came from this state to another.
        /// </summary>
        ICollection<IWorkflowTransition<D>> Transitions { get; set; }
        /// <summary>
        /// Management of an event in the state.
        /// </summary>
        /// <param name="e">Event to manage.</param>
        /// <returns>Returns the new state after the transition.</returns>
        IState<D> ReceiveEvent(IMachineEvent e);
    }
}
