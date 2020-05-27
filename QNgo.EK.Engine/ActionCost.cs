using QNgo.EK.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QNgo.EK.Engine
{
    public class ActionCost : IActionCost
    {
        public ActionCost(IEnumerable<ICard> cards)
        {
            Cards = (cards ?? Enumerable.Empty<ICard>()).ToList().AsReadOnly();
        }

        public ICollection<ICard> Cards { get; }
    }
}
