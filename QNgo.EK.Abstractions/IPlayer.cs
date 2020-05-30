using System.Collections.Generic;
using System.Threading.Tasks;

namespace QNgo.EK.Abstractions
{
    public interface IGetPlayerAction
    {
        Task<IPlayerAction> GetPlayerActionAsync();
    }

    public interface IGetPlayerQuickAction
    {
        Task<IPlayerQuickAction> GetPlayerQuickActionAsync();
    }

    public interface IPlayerHand
    {
        ICollection<ICard> Cards { get; }
    }

    public interface IPlayerCardDisplay
    {
        Task<ICollection<ICard>> ShowCardsAsync(ICollection<ICard> cards, bool allowReorder = false);
    }

    public interface IPlayerCardPicker
    {
        Task<ICard> PickCardAsync(ICollection<ICard> cards);
    }

    public interface IPlayerTargetPlayer
    {
        Task<int> ChoosePlayerAsync();
    }

    public interface IPlayer : IPlayerHand, IGetPlayerAction, IGetPlayerQuickAction, IPlayerCardDisplay, IPlayerCardPicker, IPlayerTargetPlayer
    {
        int PlayerId { get; }
        bool IsEliminated { get; set; }
    }
}
