using UnityEngine;
using UnityEngine.UI;

public class CardPileUI : MonoBehaviour {
  [SerializeField] private Text textField = null;
  [SerializeField] private string prependText = "";
  [SerializeField] private GameObject cardPile = null;

  public string Title { get { return prependText; } }

  public void SetText(int cardsInPile) {
    textField.text = prependText + ": " + cardsInPile;
    DisplayDeck(cardsInPile);
  }

  public void SetText(int cardsInPile, int cardsInTotal) {
    textField.text = prependText + ": " + cardsInPile + " / " + cardsInTotal;
    DisplayDeck(cardsInPile);
  }

  private void DisplayDeck(int cardsInPile) {
    if (cardPile != null) {
      if (cardsInPile > 0) {
        cardPile.SetActive(true);
      } else {
        cardPile.SetActive(false);
      }
    }
  }
}
