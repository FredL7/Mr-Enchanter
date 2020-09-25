public class Library : Deck {
  public void AddCardToHand(CardData card, Hand hand) {
    cardList.Add(card);
    hand.AddCard(cardList.Count - 1);
    SetTotalCardsInDeck();
  }

  public void SetCard(int index, CardData card) {
    CardData oldCard = cardList[index];
    card.indexInDeck = oldCard.indexInDeck;
    card.handIndex = oldCard.handIndex;
    cardList[index] = card;
  }

  public void ResetIndexes() {
    foreach (CardData card in cardList)
      card.ResetIndexes();
  }
}
