using UnityEngine;

public class ShopManager : MonoBehaviour {
  [SerializeField] private GameManager gameManager = null;
  [SerializeField] private ShopOverlay vue = null;

  public ShopCard[] shopCards;

  void Awake() {
    shopCards = new ShopCard[] {
      new ShopCard(CardDataFactory.Work, 20),
      new ShopCard(CardDataFactory.Shopping, 20),
      new ShopCard(CardDataFactory.Recruit, 30),
      new ShopCard(CardDataFactory.Ritual, 40)
    };
  }

  void Start() {
    vue.CreateShop(this);
  }

  public void Buy(ShopCard item) {
    gameManager.BuyCard(item);
  }
}

public struct ShopCard {
  public CardData card;
  public int price;

  public ShopCard(CardData card, int price) {
    this.card = card;
    this.price = price;
  }
}
