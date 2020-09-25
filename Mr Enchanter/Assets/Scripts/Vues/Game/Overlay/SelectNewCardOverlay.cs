using UnityEngine;
using UnityEngine.UI;

public class SelectNewCardOverlay : OverlayPanel {
  [SerializeField] private GameManager manager = null;
  [SerializeField] private GameObject cardPrefab = null;
  [SerializeField] private GameObject buttonPrefab = null;
  [SerializeField] private Text overlaytitle = null;
  [SerializeField] private RectTransform cardParent = null;
  [SerializeField] private RectTransform cardWrapper = null;

  [SerializeField] private SelectNewCardButtons btns = null;

  private string title = "Select a card to add to your deck";

  private int cardObjectWidth = 210;
  private int cardObjectHeight = 300;
  private int padding = 10;
  private int cardsPerRow = 7;
  private int buttonHeight = 40;

  private CardData[] cards;

  int Col(int i) { return i % cardsPerRow; }
  int Row(int i) { return (i - i % cardsPerRow) / cardsPerRow; }
  float ContentHeight(int n) { return Mathf.Ceil((float)n / (float)cardsPerRow) * (cardObjectHeight + padding + buttonHeight + 2 * padding) + padding; }

  void Awake() {
    cards = CardDataFactory.SelectableNewCards;
    UpdateVue();
  }

  void UpdateVue() {
    SceneHelper.DestroyChildrenInParent(cardParent);
    overlaytitle.text = title;

    for (int i = 0; i < cards.Length; i++) {
      AddCard(cards[i], i);
      AddButton(cards[i], i);
    }

    cardWrapper.sizeDelta = new Vector2(0f, ContentHeight(cards.Length));
  }

  void AddCard(CardData data, int i) {
    GameObject card = Instantiate(cardPrefab);
    CardUI script = card.GetComponent<CardUI>();
    card.GetComponent<CardDragHandler>().enabled = false;
    card.GetComponent<CardClickHandler>().enabled = false;
    script.Data = data;
    card.transform.position = new Vector3(Col(i) * (cardObjectWidth + padding), -(Row(i) + 1) * (cardObjectHeight + padding + buttonHeight + 2 * padding) + ContentHeight(cards.Length) + (padding + buttonHeight));
    card.transform.SetParent(cardParent, false);
  }

  void AddButton(CardData data, int i) {
    GameObject btn = Instantiate(buttonPrefab);
    SelectNewCardButton script = btn.GetComponent<SelectNewCardButton>();
    btns.AddButton(script);
    script.Manager = manager;
    script.Card = data;
    btn.transform.position = new Vector3(Col(i) * (cardObjectWidth + padding), -(Row(i) + 1) * (cardObjectHeight + padding + buttonHeight + 2 * padding) + ContentHeight(cards.Length));
    btn.transform.SetParent(cardParent, false);
  }
}
