using System.Threading.Tasks;

namespace QNgo.EK.Abstractions
{
    public interface ICardResolver
    {
        Task<ICard> GetCardAsync(int cardId);
    }
}
