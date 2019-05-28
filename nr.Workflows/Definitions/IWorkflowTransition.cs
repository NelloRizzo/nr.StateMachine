using System;
using System.Collections.Generic;
using System.Text;

namespace nr.Workflows
{
    /// <summary>
    /// Una transizione di stato nel workflow.
    /// </summary>
    /// <typeparam name="D">Tipo di dato delle informazioni gestite nel workflow.</typeparam>
    public interface IWorkflowTransition<D>
    {
        /// <summary>
        /// Stato attuale dell'informazione soggetta a workflow.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// Stato iniziale della transizione.
        /// </summary>
        IWorkflowState<D> From { get; set; }
        /// <summary>
        /// Stato finale della transizione.
        /// </summary>
        IWorkflowState<D> To { get; set; }
        /// <summary>
        /// Evento che scatena la transizione.
        /// </summary>
        IWorkflowEvent Event { get; set; }
        /// <summary>
        /// Azione da eseguire durante la transizione.
        /// </summary>
        Action<D, IWorkflowEvent> Action { get; set; }
        /// <summary>
        /// Guardia che determina se attivare la transizione.
        /// </summary>
        Func<D, IWorkflowEvent, bool> Guard { get; set; }
    }
}
