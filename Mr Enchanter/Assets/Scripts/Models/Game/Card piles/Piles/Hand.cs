using UnityEngine;

public class Hand : CardPile {
  [SerializeField] private Library library = null;
  [SerializeField] private HandUI HandVue = null;

  new public void UpdateVue() {
    HandVue.DisplayCards(GetCardsAsData(), cardList.ToArray());
  }

  new public void Reset() {
    base.Reset();
    UpdateVue();
  }

  new public void AddCard(int card) {
    cardList.Add(card);
    CardData data = library.GetCard(card);
    data.handIndex = cardList.Count - 1;
    UpdateVue();
  }

  new public void AddCards(int[] cards) {
    for (int i = 0; i < cards.Length; i++) {
      if (cards[i] != -1) { // Meaning ran out of cards to draw
        cardList.Add(cards[i]);
        library.GetCard(cards[i]).handIndex = cardList.Count - 1;
      }
    }
    UpdateVue();
  }

  public void DiscardCard(CardData card) {
    foreach (CardData c in GetCardsAsData())
      if (c.handIndex > card.handIndex)
        c.handIndex--;

    cardList.RemoveAt(card.handIndex);
    UpdateVue();
  }

  public int[] GetCardIndexes() {
    return cardList.ToArray();
  }
}
