using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PokemonTcgSdk;

namespace PokemonTest
{
    [TestFixture]
    public class EnergyCardTests
    {
        [Test]
        public void GetEnergyCards()
        {
            var cards = Card.Get<Trainer>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Trainer>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [Test]
        public void GetEnergyCardWithNoTextEntry()
        {
            var query = new Dictionary<string, string>
            {
                {"id", "ex13-110" }
            };

            var cardWithText = Card.Get<Energy>(query).Cards[0];

            Assert.IsNull(cardWithText.Text);
        }

        [Test]
        public void GetEnergyCardWithSingleTextEntry()
        {
            var query = new Dictionary<string, string>
            {
                {"id", "sm8-194" }
            };

            var cardWithText = Card.Get<Energy>(query).Cards[0];

            Assert.IsNotNull(cardWithText.Text);
            Assert.AreEqual(cardWithText.Text[0], "This card provides Colorless Energy. The Pokémon this card is attached to can use any attack from its previous Evolutions. (You still need the necessary Energy to use each attack.)");
        }
        
    }
}
