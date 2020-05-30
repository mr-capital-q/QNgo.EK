using System.Threading.Tasks;

namespace QNgo.EK.Abstractions
{
    public interface IGameAction
    {
        Task ExecuteActionAsync(int playerId, IGameState gameState, IActionCost actionCost = null);
    }

    public interface ICard
    {
        int CardId { get; }
        CardFamily Family { get; }
        string Name { get; }
        string Description { get; }
    }
}
