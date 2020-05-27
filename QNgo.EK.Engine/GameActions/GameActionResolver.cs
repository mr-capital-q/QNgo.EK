using Microsoft.Extensions.DependencyInjection;
using QNgo.EK.Abstractions;
using QNgo.EK.Engine.GameActions.CardActions;
using QNgo.EK.Engine.GameActions.PlayerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions
{
    public class GameActionResolver : IGameActionResolver
    {
        private readonly ICardResolver _cardResolver;
        private readonly IServiceProvider _services;

        public GameActionResolver(ICardResolver cardResolver, IServiceProvider services)
        {
            _cardResolver = cardResolver ?? throw new ArgumentNullException(nameof(cardResolver));
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public async Task<IGameAction> GetGameActionAsync(IPlayerAction playerAction)
        {
            if (playerAction.ActionType == PlayerActionType.DrawCard || !playerAction.CardIds.Any())
                return _services.GetRequiredService<DrawPlayerAction>();

            var playedCards = await Task.WhenAll(playerAction.CardIds.Select(id => _cardResolver.GetCardAsync(id)));
            var distinctCardTypeCount = playedCards.Select(c => c.Family).Distinct().Count();

            if (distinctCardTypeCount == 1 && playedCards.Length == 3)
                return _services.GetRequiredService<ThreeOfAKindCardAction>();

            if (distinctCardTypeCount == 1 && playedCards.Length == 2)
                return _services.GetRequiredService<TwoOfAKindCardAction>();

            if (playerAction.CardIds.Count == 1)
                return GetCardAction(playedCards.Single().Family);

            throw new NotImplementedException();
        }

        private IGameAction GetCardAction(CardFamily family)
        {
            switch (family)
            {
                case CardFamily.Bomb:
                    throw new NotImplementedException();
                case CardFamily.Defuse:
                    throw new NotImplementedException();
                case CardFamily.Nope:
                    throw new NotImplementedException();
                case CardFamily.Skip:
                    return _services.GetRequiredService<SkipCardAction>();
                case CardFamily.Attack:
                    throw new NotImplementedException();
                case CardFamily.Shuffle:
                    return _services.GetRequiredService<ShuffleCardAction>();
                case CardFamily.Favor:
                    throw new NotImplementedException();
                case CardFamily.PeekDeck:
                    return ActivatorUtilities.CreateInstance<PeekDeckCardAction>(_services, 3);
                case CardFamily.ImplodingBomb:
                    throw new NotImplementedException();
                case CardFamily.TargetedAttack:
                    throw new NotImplementedException();
                case CardFamily.AlterDeck:
                    return ActivatorUtilities.CreateInstance<AlterDeckCardAction>(_services, 3);
                case CardFamily.DrawBottom:
                    throw new NotImplementedException();
                case CardFamily.Reverse:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
