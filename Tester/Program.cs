using nr.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {

        static void Main(string[] args)
        {
            TestStateMachine();
            Console.ReadKey();
        }
        class Calculator
        {
            public double Accumulator { get; set; }
            public char Operation { get; set; }
            public bool MustClearDisplay { get; set; }
            public double Value { get => double.TryParse(Display.Replace('.', ',').ToString(), out double v) ? v : 0; }
            public StringBuilder Display { get; set; }
            public Calculator()
            {
                Display = new StringBuilder();
                Operation = '=';
                MustClearDisplay = true;
            }
        }
        class DigitEvent : WorkflowEvent
        {
            public char Digit { get; set; }
            public DigitEvent() : base() { Name = "digit"; }
        }

        class OperationEvent : WorkflowEvent
        {
            public char Operation { get; set; }
            public OperationEvent() : base() { Name = "operation"; }
        }
        private static void TestStateMachine()
        {
            var wf = new Workflow<Calculator>();

            var stateDisplay = new WorkflowState<Calculator>() { Name = "display" };
            stateDisplay.Transitions.Add(new WorkflowTransition<Calculator>()
            {
                Action = (c, e) =>
                {
                    if (c.MustClearDisplay) { c.Display.Clear(); c.MustClearDisplay = false; }
                    c.Display.Append((e as DigitEvent).Digit.ToString());
                },
                Guard = (c, e) =>
                    (e as DigitEvent).Digit != '0',
                Event = (WorkflowEvent)"digit",
                To = stateDisplay
            });
            stateDisplay.Transitions.Add(new WorkflowTransition<Calculator>()
            {
                Action = (c, e) =>
                {
                    if (c.MustClearDisplay) { c.Display.Clear(); c.MustClearDisplay = false; }
                    c.Display.Append('0');
                },
                Guard = (c, e) =>
                    (e as DigitEvent).Digit == '0' && c.Display.Length > 0,
                Event = (WorkflowEvent)"digit",
                To = stateDisplay
            });
            stateDisplay.Transitions.Add(new WorkflowTransition<Calculator>()
            {
                Action = (c, e) =>
                {
                    if (c.MustClearDisplay) { c.Display.Clear(); c.MustClearDisplay = false; }
                    c.Display.Append('.');
                },
                Guard = (c, e) => c.Display.Length > 0 && !c.Display.ToString().Contains('.'),
                Event = (WorkflowEvent)"comma",
                To = stateDisplay
            });
            stateDisplay.Transitions.Add(new WorkflowTransition<Calculator>()
            {
                Action = (c, e) => { c.Display.Clear(); c.MustClearDisplay = false; },
                Event = (WorkflowEvent)"clear",
                To = stateDisplay
            });
            stateDisplay.Transitions.Add(new WorkflowTransition<Calculator>()
            {
                Action = (c, e) =>
                {
                    switch (c.Operation)
                    {
                        case '=':
                            c.Accumulator = c.Value;
                            break;
                        case '+':
                            c.Accumulator += c.Value;
                            break;
                        case '*':
                            c.Accumulator *= c.Value;
                            break;
                        case '/':
                            c.Accumulator /= c.Value;
                            break;
                    }
                    c.Display.Clear();
                    c.Display.Append(c.Accumulator);
                    c.MustClearDisplay = true;
                    c.Operation = (e as OperationEvent).Operation;
                },
                Event = (WorkflowEvent)"operation",
                To = stateDisplay
            });

            wf.Data = new Calculator();
            wf.DefaultTransition.To = stateDisplay;
            wf.BroadcastEvent(WorkflowEvent.Start);
            wf.BroadcastEvent(new DigitEvent() { Digit = '0' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '1' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '2' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '3' });
            wf.BroadcastEvent((WorkflowEvent)"comma");
            wf.BroadcastEvent(new DigitEvent() { Digit = '0' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '1' });
            Console.WriteLine("Display: {0}", wf.Data.Display);
            Console.WriteLine("Clearing display...");
            wf.BroadcastEvent((WorkflowEvent)"clear");
            Console.WriteLine("Display: {0}", wf.Data.Display);
            Console.WriteLine("Perform 3 * 2 + 4...");
            wf.BroadcastEvent(new DigitEvent() { Digit = '3' });
            Console.WriteLine("Display: {0}", wf.Data.Display);
            wf.BroadcastEvent(new OperationEvent() { Operation = '*' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '2' });
            Console.WriteLine("Display: {0}", wf.Data.Display);
            wf.BroadcastEvent(new OperationEvent() { Operation = '+' });
            wf.BroadcastEvent(new DigitEvent() { Digit = '4' });
            Console.WriteLine("Display: {0}", wf.Data.Display);
            wf.BroadcastEvent(new OperationEvent() { Operation = '=' });
            Console.WriteLine("Display: {0}", wf.Data.Display);
            Console.WriteLine("Value: {0}", wf.Data.Value);
            Console.WriteLine("Accumulator: {0}", wf.Data.Accumulator);
        }
    }
}
