using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ChoiceLine: Line
    {
        public EntityId CharacterId { get; set; }

        public EntityId VariableId { get; set; }

        public List<Choice> Choices { get; set; }

        public MultiLangText Text { get; set; }

        public ChoiceLine()
        {
            Text = new MultiLangText();
        }

        public void Select(EntityId choiceId, LineContext context)
        {
            var selectedChoice = Choices.FirstOrDefault(c => c.Id == choiceId);
            if (selectedChoice == null)
            {
                throw new ArgumentException($"Choice with id = {choiceId} not found in line {Id}");
            }

            if (VariableId != null && selectedChoice.VariableValue != null)
            {
                context.Progress.Variables[VariableId].Value = selectedChoice.VariableValue; 
            }

            if (selectedChoice.TargetGoto != null)
            {
                context.MoveTo(selectedChoice.TargetGoto.Target);
            }
            else
            {
                context.MoveToNextLine();
            }
        }

        internal override void Visit(LineVisiter visiter)
        {
            visiter.Visit(this);
        }
    }
}
