using UnityEngine;

public class ShopOverlay : OverlayPanel {
  [SerializeField] private RectTransform cardsParent = null;
  [SerializeField] private GameObject cardPrefab = null;
  [SerializeField] private RectTransform buttonsParent = null;
  [SerializeField] private GameObject buttonPrefab = null;

  private int cardWidth = 210;
  private int cardHeight = 300;
  private int buttonHeight = 40;
  private int padding = 10;

  public void CreateShop(ShopManager manager) {
    for (int i = 0; i < manager.shopCards.Length; i++) {
      ShopCard data = manager.shopCards[i];
      int price = manager.shopCards[i].price;
      AddCard(data, i);
      AddButton(data, i, price, manager);
    }

    int width = (cardWidth + padding) * manager.shopCards.Length - padding;
    cardsParent.sizeDelta = new Vector2(width, cardHeight);
    buttonsParent.sizeDelta = new Vector2(width, buttonHeight);
  }

  void AddCard(ShopCard data, int i) {
    GameObject card = Instantiate(cardPrefab);
    CardUI script = card.GetComponent<CardUI>();
    card.GetComponent<CardDragHandler>().enabled = false;
    // card.GetComponent<CardClickHandler>().enabled = false; ?
    script.Data = data.card;
    card.transform.position = new Vector3(i * (cardWidth + padding), 0f, 0f);
    card.transform.SetParent(cardsParent, false);
  }

  void AddButton(ShopCard data, int i, int price, ShopManager manager) {
    GameObject btn = Instantiate(buttonPrefab);
    ShopButton script = btn.GetComponent<ShopButton>();
    script.Manager = manager;
    script.Data = data;
    btn.transform.position = new Vector3(i * (cardWidth + padding), 0f, 0f);
    btn.transform.SetParent(buttonsParent, false);
  }
}
