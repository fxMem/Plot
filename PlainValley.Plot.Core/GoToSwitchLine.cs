using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class GoToSwitchLine: UtilityLine
    {
        public EntityId Variable { get; set; }

        public Dictionary<string, GlobalLineId> Targets { get; set; }

        public bool AllowFallthrough { get; set; }

        public override void Invoke(LineContext context)
        {
            base.Invoke(context);
            var variable = context.Progress.Variables[Variable];
            GlobalLineId target;
            Targets.TryGetValue(variable.Value, out target);

            if (target == null && !AllowFallthrough)
            {
                throw new InvalidOperationException($"GoTo Switch ({Id}) branch for variable {Variable} value ({variable.Value} not found!)");
            }

            if (target != null)
            {
                context.MoveTo(target);
            }
            else
            {
                context.MoveToNextLine();
            }
        }
    }
}
