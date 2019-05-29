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
        /// Fired when entering in the state.
        /// </summary>
        public event EventHandler<D> Enter;
        /// <summary>
        /// Fired when wxiting in the state.
        /// </summary>
        public event EventHandler<D> Exit;
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
            OnEnter(Data);
            var transition = Transitions.FirstOrDefault(t => t.Event.Equals(e) && (t.Guard?.Invoke(Data, e) ?? true));
            if (transition == null) return null;
            transition.Data = Data;
            transition.Action?.Invoke(Data, e);
            OnExit(Data);
            return transition.To;
        }
        /// <summary>
        /// Fire the event <see cref="Enter"/>.
        /// </summary>
        /// <param name="data">Parameters for this event.</param>
        protected virtual void OnEnter(D data)
        {
            Enter?.Invoke(this, data);
        }
        /// <summary>
        /// Fire the event <see cref="Exit"/>.
        /// </summary>
        /// <param name="data">Parameters for this event.</param>
        protected virtual void OnExit(D data)
        {
            Exit?.Invoke(this, data);
        }
    }
}
