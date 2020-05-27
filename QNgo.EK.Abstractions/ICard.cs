using System.Threading.Tasks;

namespace QNgo.EK.Abstractions
{
    public interface IGameAction
    {
        Task ExecuteActionAsync(IGameState gameState, IActionCost actionCost = null);
    }

    public interface ICard : IGameAction
    {
        int CardId { get; }
        CardFamily Family { get; }
        string Name { get; }
        string Description { get; }
    }
}
