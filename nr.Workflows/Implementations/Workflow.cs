using System;
using System.Collections.Generic;
using System.Text;

namespace nr.Workflows
{
    /// <summary>
    /// Definizione di un workflow.
    /// </summary>
    /// <typeparam name="D">TIpo di dato gestito nel workflow.</typeparam>
    public class Workflow<D> : IWorkflow<D>
    {
        /// <summary>
        /// Dato gestito.
        /// </summary>
        public D Data { get; set; }
        public IWorkflowTransition<D> DefaultTransition { get; set; }
        /// <summary>
        /// Stato corrente.
        /// </summary>
        public IWorkflowState<D> CurrentState { get; set; }

        /// <summary>
        /// Genera un evento sullo stato corrente e passa ad un nuovo stato.
        /// </summary>
        /// <param name="e">Evento da generare.</param>
        public void BroadcastEvent(IWorkflowEvent e)
        {
            CurrentState.Data = Data;
            var s = CurrentState.ReceiveEvent(e);
            if (s != null) CurrentState = s;
        }
        /// <summary>
        /// Costruttore.
        /// </summary>
        public Workflow()
        {
            DefaultTransition = WorkflowTransition<D>.Default;
            CurrentState = new WorkflowState<D>() { Name = "Default" };
            CurrentState.Transitions.Add(DefaultTransition);
        }
    }
}
