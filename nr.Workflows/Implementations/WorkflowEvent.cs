using System;
using System.Collections.Generic;
using System.Text;

namespace nr.StateMachine
{
    /// <summary>
    /// Definizione di un evento che attiva una transizione di stato.
    /// </summary>
    public class WorkflowEvent : IMachineEvent
    {
        /// <summary>
        /// Nome dell'evento.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ottiene il codice hash dell'istanza.
        /// </summary>
        /// <returns>Restituisce il codice hash dell'istanza.</returns>
        public override int GetHashCode() => Name.ToLowerInvariant().GetHashCode();
        /// <summary>
        /// Ottiene la rappresentazione sotto forma di stringa.
        /// </summary>
        /// <returns>Restituisce la rappresentazione sotto forma di stringa
        /// dell'istanza.</returns>
        public override string ToString() => Name;
        /// <summary>
        /// Confronta due istanze.
        /// </summary>
        /// <param name="obj">Istanza con la quale effettuare il confronto.</param>
        /// <returns>Restituisce un valore booleano che indica se le istanze sono uguali.</returns>
        public override bool Equals(object obj) =>
            obj is IMachineEvent ? GetHashCode() == obj.GetHashCode() : false;
        /// <summary>
        /// Conversione verso stringa.
        /// </summary>
        /// <param name="e">Istanza dell'evento da convertiere in stringa.</param>
        public static explicit operator string(WorkflowEvent e)
            => e.Name;
        /// <summary>
        /// Conversione da stringa.
        /// </summary>
        /// <param name="e">Stringa da convertire.</param>
        public static explicit operator WorkflowEvent(string e)
            => new WorkflowEvent() { Name = e };
        /// <summary>
        /// Evento di avvio del workflow.
        /// </summary>
        public static IMachineEvent Start { get => new WorkflowEvent() { Name = "evStart" }; }
    }
}
