using System;
using System.Collections.Generic;
using System.Text;

namespace nr.Workflows
{
    /// <summary>
    /// Stato del dato all'interno del workflow.
    /// </summary>
    /// <typeparam name="D"></typeparam>
    public  interface IWorkflowState<D>
    {
        /// <summary>
        /// Dato gestito.
        /// </summary>
        D Data { get; set; }
        /// <summary>
        /// Nome dello stato.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Transizioni di stato ammesse per questo stato.
        /// </summary>
        ICollection<IWorkflowTransition<D>> Transitions { get; set; }
        /// <summary>
        /// Riceve e gestisce un evento.
        /// </summary>
        /// <param name="e">Evento da gestire.</param>
        /// <returns>Restituisce lo stato ottenuto dopo l'esecuzione della
        /// transizione sollevata dall'evento.</returns>
        IWorkflowState<D> ReceiveEvent(IWorkflowEvent e);
    }
}
