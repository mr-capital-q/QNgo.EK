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
                new Card(1, CardFamily.Skip, "Skip", "End your turn immediately without drawing a card."),
                new Card(2, CardFamily.Skip, "Skip", "End your turn immediately without drawing a card."),
                new Card(3, CardFamily.Skip, "Skip", "End your turn immediately without drawing a card."),
                new Card(5, CardFamily.Filler1, "Test Card 1", "Does nothing"),
                new Card(6, CardFamily.Filler1, "Test Card 1", "Does nothing"),
                new Card(7, CardFamily.Filler1, "Test Card 1", "Does nothing"),
                new Card(8, CardFamily.Bomb, "You lose", "Good bye")
            });
        }

        public async Task<ICard> GetCardAsync(int id)
        {
            var cards = await GetAllCardsAsync();

            return cards.FirstOrDefault(c => c.CardId == id);
        }
    }
}
