using UnityEngine;

public class CurrentEvent : CardPile {
  [SerializeField] private Deck eventDeck = null;

  void Awake() {
    SetCardKnownAll();
  }

  new public void UpdateVue() {
    base.UpdateVue();
    ((CurrentEventUI)vue).DisplayCard(eventDeck.GetCard(TopCard));
  }

  public void CardPlayed() {
    ((CurrentEventUI)vue).DisplayCard(null);
  }
}
