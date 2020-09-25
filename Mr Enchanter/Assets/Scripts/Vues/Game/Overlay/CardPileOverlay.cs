using UnityEngine;
using UnityEngine.UI;

public class CardPileOverlay : OverlayPanel {
  [SerializeField] private GameObject cardPrefab = null;
  [SerializeField] private GameObject cardBackPrefab = null;
  [SerializeField] private Text cardPileTitle = null;
  [SerializeField] private RectTransform cardParent = null;
  [SerializeField] private RectTransform cardWrapper = null;

  private int cardObjectWidth = 210;
  private int padding = 10;

  private CardPile pile;
  public CardPile Pile {
    set {
      pile = value;
      UpdateVue();
    }
  }

  void UpdateVue() {
    SceneHelper.DestroyChildrenInParent(cardParent);
    cardPileTitle.text = pile.Title;

    for (int i = 0; i < pile.Count; i++)
      AddCard(pile.GetCardAsData(i), i);

    cardWrapper.sizeDelta = new Vector2(pile.Count * (cardObjectWidth + padding) + padding, 350);
  }

  void AddCard(CardData data, int i) {
    if (pile.CardKnown == -1 || i < pile.CardKnown) {
      GameObject card = Instantiate(cardPrefab);
      CardUI script = card.GetComponent<CardUI>();
      card.GetComponent<CardDragHandler>().enabled = false;
      script.Data = data;
      card.transform.position = new Vector3(i * (cardObjectWidth + padding), 0f, 0f);
      card.transform.SetParent(cardParent, false);
    } else {
      GameObject card = Instantiate(cardBackPrefab);
      card.transform.position = new Vector3(i * (cardObjectWidth + padding), 0f, 0f);
      card.transform.SetParent(cardParent, false);
    }
  }
}
