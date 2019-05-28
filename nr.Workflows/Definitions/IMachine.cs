using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// State machine definition.
    /// </summary>
    /// <typeparam name="D">Type of the handled state.</typeparam>
    public interface IMachine<D>
    {
        /// <summary>
        /// Handled data.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// Stato corrente.
        /// </summary>
        IState<D> CurrentState { get; set; }
        /// <summary>
        /// Genera un evento sullo stato corrente e passa ad un nuovo stato.
        /// </summary>
        /// <param name="e">Evento da generare.</param>
        void BroadcastEvent(IMachineEvent e);
    }
}
