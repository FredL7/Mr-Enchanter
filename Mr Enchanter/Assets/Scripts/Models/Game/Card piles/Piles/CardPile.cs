using System.Collections.Generic;
using UnityEngine;

/**
 * First card on top
 */
public class CardPile : MonoBehaviour {
  private static System.Random rng = new System.Random();

  [SerializeField] protected CardPileUI vue = null;
  [SerializeField] private Deck deck = null;

  private int totalCardsInDeck = -1;

  public string Title { get { return vue.Title; } }

  private int cardKnown = 0; // -1 == Open face pile
  public int CardKnown { get { return cardKnown; } }
  protected void SetCardKnownAll() { cardKnown = -1; }
  public void SetCardKnown(int n) {
    if (cardKnown != -1) {
      cardKnown = n;
      if (cardKnown > Count)
        cardKnown = Count;
    }
  }

  protected List<int> cardList = new List<int>();
  public int Count { get { return cardList.Count; } }
  protected int TopCardIndex { get { return cardList.Count - 1; } }
  public int TopCard {
    get {
      return cardList.Count == 0 ? -1 : cardList[cardList.Count - 1];
    }
  }

  public void UpdateVue() {
    if (vue != null) {
      if (totalCardsInDeck == -1) {
        vue.SetText(cardList.Count);
      } else {
        vue.SetText(cardList.Count, totalCardsInDeck);
      }
    }
  }

  void Start() {
    UpdateVue();
  }

  public void Reset() {
    cardList.Clear();
    totalCardsInDeck = -1;
    // cardKnown = 0;
    UpdateVue();
  }

  public void SetTotalCardsInDeck(int n) {
    totalCardsInDeck = n;
    UpdateVue();
  }

  public void AddCard(int card) {
    cardList.Add(card);
    UpdateVue();
  }

  public void AddCards(int[] cards) {
    cardList.AddRange(cards);
    UpdateVue();
  }

  public void RemoveCard(int cardId) {
    if (cardList.Contains(cardId)) {
      int index = cardList.IndexOf(cardId);
      cardList.RemoveAt(index);
    }

    for (int i = 0; i < cardList.Count; i++) {
      if (cardList[i] > cardId) {
        cardList[i] = cardList[i] - 1;
      }
    }
    UpdateVue();
  }

  public void Shuffle() {
    int n = cardList.Count;
    while (n > 1) {
      n--;
      int k = rng.Next(n + 1);
      int card = cardList[k];
      cardList[k] = cardList[n];
      cardList[n] = card;
    }
  }

  public int DrawCard() {
    if (Count == 0)
      return -1;

    cardKnown--;
    if (cardKnown < 0)
      cardKnown = 0;

    int card = cardList[TopCardIndex];
    cardList.RemoveAt(TopCardIndex);
    UpdateVue();
    return card;
  }

  public int[] Empty() {
    int[] cards = cardList.ToArray();
    cardList.Clear();
    UpdateVue();
    return cards;
  }

  public int GetCard(int index) {
    return cardList[TopCardIndex - index];
  }

  public CardData[] GetCardsAsData() {
    CardData[] cards = new CardData[cardList.Count];
    for (int i = 0; i < cardList.Count; i++) {
      cards[i] = deck.GetCard(cardList[i]);
    }
    return cards;
  }

  public CardData GetCardAsData(int i = 0) {
    if (TopCardIndex - i < 0)
      return null;
    return deck.GetCard(cardList[TopCardIndex - i]);
  }

  public int[] GetCardsRevealed() {
    if (cardKnown == 0)
      return null;

    int[] cards = new int[cardKnown];

    for (int i = 0; i < cardKnown; i++)
      cards[i] = GetCard(i);

    return cards;
  }

}
