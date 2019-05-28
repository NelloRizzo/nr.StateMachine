using System;
using System.Collections.Generic;
using System.Text;

namespace nr.Workflows
{
    /// <summary>
    /// Definizione di un evento che attiva una transizione di stato.
    /// </summary>
    public interface IWorkflowEvent
    {
        /// <summary>
        /// Nome dell'evento.
        /// </summary>
        string Name { get; set; }
    }
}
