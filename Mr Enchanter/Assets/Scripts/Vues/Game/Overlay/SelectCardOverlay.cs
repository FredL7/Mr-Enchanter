using UnityEngine;
using UnityEngine.UI;

public class SelectCardOverlay : OverlayPanel {
  [SerializeField] private GameObject cardPrefab = null;
  [SerializeField] private GameObject buttonPrefab = null;
  [SerializeField] private Text titleField = null;
  [SerializeField] private RectTransform cardParent = null;
  [SerializeField] private RectTransform cardWrapper = null;
  [SerializeField] private GameObject optionalButton = null;

  private int cardObjectWidth = 210;
  private int padding = 10;
  private int buttonHeight = 40;

  public string Title { set { titleField.text = value; } }

  private SelectCardEffect effect;
  public SelectCardEffect Effect { set { effect = value; } }

  private Deck deck;
  public Deck Deck {
    set {
      deck = value;
    }
  }

  private int[] cardIndexes;
  public int[] CardIndexes {
    set {
      cardIndexes = value;
      UpdateVue();
    }
  }

  void UpdateVue() {
    SceneHelper.DestroyChildrenInParent(cardParent);

    for (int i = 0; i < cardIndexes.Length; i++) {
      CardData card = deck.GetCard(cardIndexes[i]);
      AddCard(card, i);
      AddButton(card.Title, cardIndexes[i], i);
    }

    cardWrapper.sizeDelta = new Vector2(cardIndexes.Length * (cardObjectWidth + padding) + padding, 400);
  }

  void AddCard(CardData data, int i) {
    GameObject card = Instantiate(cardPrefab);
    CardUI script = card.GetComponent<CardUI>();
    script.Data = data;
    card.transform.position = new Vector3(i * (cardObjectWidth + padding), buttonHeight + padding, 0f);
    card.transform.SetParent(cardParent, false);
  }

  void AddButton(string cardTitle, int cardIndex, int i) {
    GameObject btn = Instantiate(buttonPrefab);
    SelectCardButton script = btn.GetComponent<SelectCardButton>();
    script.CardTitle = cardTitle;
    script.Effect = effect;
    script.CardIndex = cardIndex;
    btn.transform.position = new Vector3(i * (cardObjectWidth + padding), 0f, 0f);
    btn.transform.SetParent(cardParent, false);
  }

  new public void Hide() {
    base.Hide();
    optionalButton.SetActive(false);
  }

  public void DisplayCancelButton() {
    optionalButton.SetActive(true);
  }
}
