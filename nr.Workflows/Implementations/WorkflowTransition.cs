using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Una transizione di stato nel workflow.
    /// </summary>
    /// <typeparam name="D">Tipo di dato delle informazioni gestite nel workflow.</typeparam>
    public class WorkflowTransition<D> : IWorkflowTransition<D>
    {
        /// <summary>
        /// Stato attuale dell'informazione soggetta a workflow.
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Stato iniziale della transizione.
        /// </summary>
        public IState<D> From { get; set; }
        /// <summary>
        /// Stato finale della transizione.
        /// </summary>
        public IState<D> To { get; set; }
        /// <summary>
        /// Azione da eseguire durante la transizione.
        /// </summary>
        public Action<D, IMachineEvent> Action { get; set; }
        /// <summary>
        /// Guardia che determina se attivare la transizione.
        /// </summary>
        public Func<D, IMachineEvent, bool> Guard { get; set; }
        /// <summary>
        /// Evento che scatena la transizione.
        /// </summary>
        public IMachineEvent Event { get; set; }
        /// <summary>
        /// Transizione di default.
        /// </summary>
        public static IWorkflowTransition<D> Default
        {
            get => new WorkflowTransition<D>() { From = null, Event = WorkflowEvent.Start };
        }
    }
}
