using System.Collections.Generic;
using UnityEngine;
/**
 * Cards of a deck are shared between piles
 * Used for the total card count UI
 */
public class Deck : MonoBehaviour {
  [Tooltip("First element is considered the main Deck, where the card total will be displayed")]
  [SerializeField] protected CardPile[] piles = null;
  [SerializeField] private string title = "";

  public string Title { get { return title; } }

  protected List<CardData> cardList;
  public int Count { get { return cardList.Count; } }

  void Awake() {
    cardList = new List<CardData>();
  }

  public void Reset() {
    cardList.Clear();
    foreach (CardPile pile in piles)
      pile.Reset();
  }

  public void AddCard(CardData card, CardPile pile) {
    cardList.Add(card);
    card.indexInDeck = cardList.Count - 1;
    pile.AddCard(cardList.Count - 1);
    SetTotalCardsInDeck();
  }

  public void AddCard(CardData card) {
    AddCard(card, piles[0]);
  }

  public void AddCards(CardData[] cards, CardPile pile) {
    // TODO: Find a less repetitive way of doing that (reduce amount of UpdateVue called in pile)?
    foreach (CardData card in cards) {
      AddCard(card, pile);
    }
  }

  public void AddCards(CardData[] cards) {
    AddCards(cards, piles[0]);
  }

  public void RemoveCard(CardData card) {
    int index = cardList.IndexOf(card);
    cardList.RemoveAt(index);
    foreach(CardData data in cardList)
      if (data.indexInDeck > index)
        data.indexInDeck--;
    foreach (CardPile pile in piles)
      pile.RemoveCard(index);
    SetTotalCardsInDeck();
    UpdateVue();
  }

  public CardData GetCard(int index) {
    return cardList[index];
  }

  public CardData[] GetCardsSorted() {
    CardData[] cards = cardList.ToArray();
    System.Array.Sort(cards, (x, y) => x.Title.CompareTo(y.Title));
    return cards;
  }

  public void UpdateVue() {
    foreach (CardPile pile in piles)
      pile.UpdateVue();
  }

  protected void SetTotalCardsInDeck() {
    piles[0].SetTotalCardsInDeck(cardList.Count);
  }
}
