using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {
  [SerializeField] private Text buttonText = null;

  private ShopManager manager;
  public ShopManager Manager {
    set {
      manager = value;
      Button btn = GetComponent<Button>();
      btn.onClick.AddListener(BuyCard);
    }
  }

  private ShopCard data;
  public ShopCard Data {
    get { return data; }
    set {
      data = value;
      SetUI();
    }
  }

  void SetUI() {
    buttonText.text = "Buy " + TextHelper.Bold(data.card.Title) + " (" + data.price + ")";
  }

  void BuyCard() {
    manager.Buy(data);
  }
}
