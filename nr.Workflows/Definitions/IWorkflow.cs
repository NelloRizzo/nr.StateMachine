using System;
using System.Collections.Generic;
using System.Text;

namespace nr.Workflows
{
    /// <summary>
    /// Definizione di un workflow.
    /// </summary>
    /// <typeparam name="D">Tipo di dato gestito nel workflow.</typeparam>
    public interface IWorkflow<D>
    {
        /// <summary>
        /// Dato gestito.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// Stato corrente.
        /// </summary>
        IWorkflowState<D> CurrentState { get; set; }
        /// <summary>
        /// Genera un evento sullo stato corrente e passa ad un nuovo stato.
        /// </summary>
        /// <param name="e">Evento da generare.</param>
        void BroadcastEvent(IWorkflowEvent e);
    }
}
