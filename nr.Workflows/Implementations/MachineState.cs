using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Base implementation for a state.
    /// </summary>
    /// <typeparam name="D">Type of handled data.</typeparam>
    public class MachineState<D> : IState<D>
    {
        /// <summary>
        /// Handled data.
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Transitions in the state.
        /// </summary>
        public ICollection<ITransition<D>> Transitions { get; set; }
        /// <summary>
        /// State's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MachineState()
        {
            Transitions = new List<ITransition<D>>();
        }
        /// <summary>
        /// Handle an event.
        /// </summary>
        /// <param name="e">Event to handle.</param>
        /// <returns>Returns the new state of the machine.</returns>
        public IState<D> ReceiveEvent(IMachineEvent e)
        {
            var transition = Transitions.FirstOrDefault(t => t.Event.Equals(e) && (t.Guard?.Invoke(Data, e) ?? true));
            if (transition == null) return null;
            transition.Data = Data;
            transition.Action?.Invoke(Data, e);
            return transition.To;
        }
    }
}
