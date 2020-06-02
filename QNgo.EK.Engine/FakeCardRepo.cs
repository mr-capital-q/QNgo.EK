using QNgo.EK.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class FakeCardRepo
    {
        public Task<IEnumerable<ICard>> GetAllCardsAsync()
        {
            return Task.FromResult<IEnumerable<ICard>>(new List<ICard>
            {
                new Card(1, CardFamily.Lose, "{Lose}", "When this card is drawn, reveal it. If you cannot play a \"{ExtraLife}\" card, you lose."),
                new Card(2, CardFamily.Lose, "{Lose}", "When this card is drawn, reveal it. If you cannot play a \"{ExtraLife}\" card, you lose."),
                new Card(3, CardFamily.Lose, "{Lose}", "When this card is drawn, reveal it. If you cannot play a \"{ExtraLife}\" card, you lose."),
                new Card(4, CardFamily.Lose, "{Lose}", "When this card is drawn, reveal it. If you cannot play a \"{ExtraLife}\" card, you lose."),
                new Card(5, CardFamily.Lose, "{Lose}", "When this card is drawn, reveal it. If you cannot play a \"{ExtraLife}\" card, you lose."),
                new Card(6, CardFamily.LoseExtra, "{LoseExtra}", "When this card is drawn, return it to the top of the draw pile face up. When a player draws this card while face up, that player immediately loses and cannot play a \"Defuse\" card."),
                new Card(7, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(8, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(9, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(10, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(11, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(12, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(13, CardFamily.ExtraLife, "{ExtraLife}", "Play this card when an \"{Lose}\" card is drawn. Place the \"{Lose}\" card back into the draw pile anywhere you want."),
                new Card(14, CardFamily.Skip, "{Skip}", "End your turn without drawing a card."),
                new Card(15, CardFamily.Skip, "{Skip}", "End your turn without drawing a card."),
                new Card(16, CardFamily.Skip, "{Skip}", "End your turn without drawing a card."),
                new Card(17, CardFamily.Skip, "{Skip}", "End your turn without drawing a card."),
                new Card(18, CardFamily.Attack, "{Attack}", "End your turn without drawing a card. The next player must take two turns."),
                new Card(19, CardFamily.Attack, "{Attack}", "End your turn without drawing a card. The next player must take two turns."),
                new Card(20, CardFamily.Attack, "{Attack}", "End your turn without drawing a card. The next player must take two turns."),
                new Card(21, CardFamily.Attack, "{Attack}", "End your turn without drawing a card. The next player must take two turns."),
                new Card(22, CardFamily.Shuffle, "{Shuffle}", "Shuffle the draw pile."),
                new Card(23, CardFamily.Shuffle, "{Shuffle}", "Shuffle the draw pile."),
                new Card(24, CardFamily.Shuffle, "{Shuffle}", "Shuffle the draw pile."),
                new Card(25, CardFamily.Shuffle, "{Shuffle}", "Shuffle the draw pile."),
                new Card(26, CardFamily.Favor, "{Favor}", "Choose another player. That player must give you a card of their choice."),
                new Card(27, CardFamily.Favor, "{Favor}", "Choose another player. That player must give you a card of their choice."),
                new Card(28, CardFamily.Favor, "{Favor}", "Choose another player. That player must give you a card of their choice."),
                new Card(29, CardFamily.Favor, "{Favor}", "Choose another player. That player must give you a card of their choice."),
                new Card(30, CardFamily.PeekDeck, "{PeekDeck}", "View the top 3 cards of the draw pile without changing its order."),
                new Card(31, CardFamily.PeekDeck, "{PeekDeck}", "View the top 3 cards of the draw pile without changing its order."),
                new Card(32, CardFamily.PeekDeck, "{PeekDeck}", "View the top 3 cards of the draw pile without changing its order."),
                new Card(33, CardFamily.PeekDeck, "{PeekDeck}", "View the top 3 cards of the draw pile without changing its order."),
                new Card(34, CardFamily.PeekDeck, "{PeekDeck}", "View the top 3 cards of the draw pile without changing its order."),
                new Card(35, CardFamily.Filler1, "{Filler1}", "This card has no effect and cannot be played by itself."),
                new Card(36, CardFamily.Filler1, "{Filler1}", "This card has no effect and cannot be played by itself."),
                new Card(37, CardFamily.Filler1, "{Filler1}", "This card has no effect and cannot be played by itself."),
                new Card(38, CardFamily.Filler1, "{Filler1}", "This card has no effect and cannot be played by itself."),
                new Card(39, CardFamily.Filler2, "{Filler2}", "This card has no effect and cannot be played by itself."),
                new Card(40, CardFamily.Filler2, "{Filler2}", "This card has no effect and cannot be played by itself."),
                new Card(41, CardFamily.Filler2, "{Filler2}", "This card has no effect and cannot be played by itself."),
                new Card(42, CardFamily.Filler2, "{Filler2}", "This card has no effect and cannot be played by itself."),
                new Card(43, CardFamily.Filler3, "{Filler3}", "This card has no effect and cannot be played by itself."),
                new Card(44, CardFamily.Filler3, "{Filler3}", "This card has no effect and cannot be played by itself."),
                new Card(45, CardFamily.Filler3, "{Filler3}", "This card has no effect and cannot be played by itself."),
                new Card(46, CardFamily.Filler3, "{Filler3}", "This card has no effect and cannot be played by itself."),
                new Card(47, CardFamily.Filler4, "{Filler4}", "This card has no effect and cannot be played by itself."),
                new Card(48, CardFamily.Filler4, "{Filler4}", "This card has no effect and cannot be played by itself."),
                new Card(49, CardFamily.Filler4, "{Filler4}", "This card has no effect and cannot be played by itself."),
                new Card(50, CardFamily.Filler4, "{Filler4}", "This card has no effect and cannot be played by itself."),
                new Card(51, CardFamily.Filler5, "{Filler5}", "This card has no effect and cannot be played by itself."),
                new Card(52, CardFamily.Filler5, "{Filler5}", "This card has no effect and cannot be played by itself."),
                new Card(53, CardFamily.Filler5, "{Filler5}", "This card has no effect and cannot be played by itself."),
                new Card(54, CardFamily.Filler5, "{Filler5}", "This card has no effect and cannot be played by itself."),
                new Card(55, CardFamily.Nope, "{Nope}", "You can play this card in response to another player's action card to stop that action."),
                new Card(56, CardFamily.Nope, "{Nope}", "You can play this card in response to another player's action card to stop that action."),
                new Card(57, CardFamily.Nope, "{Nope}", "You can play this card in response to another player's action card to stop that action."),
                new Card(58, CardFamily.Nope, "{Nope}", "You can play this card in response to another player's action card to stop that action."),
                new Card(59, CardFamily.Nope, "{Nope}", "You can play this card in response to another player's action card to stop that action."),
                new Card(60, CardFamily.TargetedAttack, "{TargetedAttack}", "End your turn without drawing a card and choose another player. That player must take two turns."),
                new Card(61, CardFamily.TargetedAttack, "{TargetedAttack}", "End your turn without drawing a card and choose another player. That player must take two turns."),
                new Card(62, CardFamily.TargetedAttack, "{TargetedAttack}", "End your turn without drawing a card and choose another player. That player must take two turns."),
                new Card(63, CardFamily.AlterDeck, "{AlterDeck}", "View the top 3 cards of the draw pile and return them in any order."),
                new Card(64, CardFamily.AlterDeck, "{AlterDeck}", "View the top 3 cards of the draw pile and return them in any order."),
                new Card(65, CardFamily.AlterDeck, "{AlterDeck}", "View the top 3 cards of the draw pile and return them in any order."),
                new Card(66, CardFamily.AlterDeck, "{AlterDeck}", "View the top 3 cards of the draw pile and return them in any order."),
                new Card(67, CardFamily.DrawBottom, "{DrawBottom}", "End your turn and draw one card from the bottom of the draw pile."),
                new Card(68, CardFamily.DrawBottom, "{DrawBottom}", "End your turn and draw one card from the bottom of the draw pile."),
                new Card(69, CardFamily.DrawBottom, "{DrawBottom}", "End your turn and draw one card from the bottom of the draw pile."),
                new Card(70, CardFamily.DrawBottom, "{DrawBottom}", "End your turn and draw one card from the bottom of the draw pile."),
                new Card(71, CardFamily.Reverse, "{Reverse}", "End your turn without drawing a card. Continue the game in the reverse order of the current player order."),
                new Card(72, CardFamily.Reverse, "{Reverse}", "End your turn without drawing a card. Continue the game in the reverse order of the current player order."),
                new Card(73, CardFamily.Reverse, "{Reverse}", "End your turn without drawing a card. Continue the game in the reverse order of the current player order."),
                new Card(74, CardFamily.Reverse, "{Reverse}", "End your turn without drawing a card. Continue the game in the reverse order of the current player order."),
                new Card(75, CardFamily.FillerWildcard, "{FillerWildcard}", "This card can be used as any \"{Filler}\" card."),
                new Card(76, CardFamily.FillerWildcard, "{FillerWildcard}", "This card can be used as any \"{Filler}\" card."),
                new Card(77, CardFamily.FillerWildcard, "{FillerWildcard}", "This card can be used as any \"{Filler}\" card."),
                new Card(78, CardFamily.FillerWildcard, "{FillerWildcard}", "This card can be used as any \"{Filler}\" card."),
                //new Card(79, CardFamily.Destruction, "{Destruction}", "Remove all \"{Lose}\" cards from the draw pile. Shuffle the draw pile and return the \"{Lose}\" cards to the top of the draw pile face down."),
                //new Card(80, CardFamily.HideEnd, "{HideEnd}", "While this card is in your hand, you can also secretly hold 1 \"{Lose}\" card without needing to play a \"{ExtraLife}\" card."),
                //new Card(81, CardFamily.SkipAll, "{SkipAll}", "End your turn without drawing a card. All extra turns are also skipped."),
                //new Card(82, CardFamily.Return, "{Return}", "Every player with 1 or more cards must choose one card in their hand and shuffle it into the draw pile."),
                //new Card(83, CardFamily.PeekDeckExtra, "{PeekDeckExtra}", "View the top 5 cards of the draw pile without changing its order."),
                //new Card(84, CardFamily.LockCard, "{LockCard}", "Choose another player. Pick 1 random card in their hand and reveal it until it is played or changes possession."),
                //new Card(85, CardFamily.LockCard, "{LockCard}", "Choose another player. Pick 1 random card in their hand and reveal it until it is played or changes possession."),
                //new Card(86, CardFamily.LockCard, "{LockCard}", "Choose another player. Pick 1 random card in their hand and reveal it until it is played or changes possession."),
                //new Card(87, CardFamily.SwapTopBottom, "{SwapTopBottom}", "Swap the top and bottom cards of the draw pile."),
                //new Card(88, CardFamily.AlterDeckExtra, "{AlterDeckExtra}", "View the top 5 cards of the draw pile and return them in any order."),
                //new Card(89, CardFamily.Blind, "{Blind}", "Choose another player. That player must shuffle the cards in their hand face down. Cards cannot be viewed until they draw a card but can still be played blindly.")
            });
        }

        public async Task<ICard> GetCardAsync(int id)
        {
            var cards = await GetAllCardsAsync();

            return cards.FirstOrDefault(c => c.CardId == id);
        }
    }
}
