using QNgo.EK.Abstractions;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class CardResolver : ICardResolver
    {
        public Task<ICard> GetCardAsync(int cardId)
        {
            return new FakeCardRepo().GetCardAsync(cardId);
        }
    }
}
