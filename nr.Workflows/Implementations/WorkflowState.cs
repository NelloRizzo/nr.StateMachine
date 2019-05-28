using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Definizione di uno stato del workflow.
    /// </summary>
    /// <typeparam name="D">Dati gestiti.</typeparam>
    public class WorkflowState<D> : IState<D>
    {
        /// <summary>
        /// Dati gestiti.
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Transizioni di stato.
        /// </summary>
        public ICollection<IWorkflowTransition<D>> Transitions { get; set; }
        /// <summary>
        /// Nome dello stato.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Costruttore.
        /// </summary>
        public WorkflowState()
        {
            Transitions = new List<IWorkflowTransition<D>>();
        }
        /// <summary>
        /// Gestisce un evento che scateni una transizione.
        /// </summary>
        /// <param name="e">Evento da gestire.</param>
        /// <returns>Restituisce il nuovo stato dopo la gestione dell'evento.</returns>
        public IState<D> ReceiveEvent(IMachineEvent e)
        {
            var transition = Transitions.FirstOrDefault(t => t.Event.Equals(e) && (t.Guard?.Invoke(Data, e) ?? true));
            if (transition == null) return null;
            transition.Data = Data;
            // TODO: Gestione della guardia spostata nel filtro della lambda expression... Controllare se corretto.
            //if (transition.Guard != null && !transition.Guard(Data, e)) return null;
            transition.Action?.Invoke(Data, e);
            return transition.To;
        }
    }
}
