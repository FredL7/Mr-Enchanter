using UnityEngine;
using UnityEngine.UI;

public class DeckOverlay : OverlayPanel {
  [SerializeField] private GameObject cardPrefab = null;
  [SerializeField] private Text deckTitle = null;
  [SerializeField] private RectTransform cardParent = null;
  [SerializeField] private RectTransform cardWrapper = null;

  private int cardObjectWidth = 210;
  private int cardObjectHeight = 300;
  private int padding = 10;
  private int cardsPerRow = 7;

  int Col(int i) { return i % cardsPerRow; }
  int Row(int i) { return (i - i % cardsPerRow) / cardsPerRow; }
  float ContentHeight(int n) { return Mathf.Ceil((float)n / (float)cardsPerRow) * (cardObjectHeight + padding) + 10; }

  private Deck deck;
  public Deck Deck {
    set {
      deck = value;
      UpdateVue();
    }
  }

  void UpdateVue() {
    SceneHelper.DestroyChildrenInParent(cardParent);
    deckTitle.text = deck.Title;

    CardData[] cards = deck.GetCardsSorted();

    for (int i = 0; i < cards.Length; i++)
      AddCard(cards[i], i, cards.Length);

    cardWrapper.sizeDelta = new Vector2(0f, ContentHeight(cards.Length));
  }

  void AddCard(CardData data, int i, int n) {
    GameObject card = Instantiate(cardPrefab);
    CardUI script = card.GetComponent<CardUI>();
    card.GetComponent<CardDragHandler>().enabled = false;
    script.Data = data;
    card.transform.position = new Vector3(Col(i) * (cardObjectWidth + padding), -(Row(i) + 1) * (cardObjectHeight + padding) + ContentHeight(n) - 10);
    card.transform.SetParent(cardParent, false);
  }
}
