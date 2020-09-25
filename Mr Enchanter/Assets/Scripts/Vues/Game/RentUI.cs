using UnityEngine;
using UnityEngine.UI;

public class RentUI : MonoBehaviour {
  [SerializeField] private Text textField = null;
  [SerializeField] private GameObject cardPile = null;
  [SerializeField] private Transform parent = null;
  [SerializeField] private GameObject cardPrefab = null;

  public void Clear() {
    SceneHelper.DestroyChildrenInParent(parent);
  }

  public void AddRentCard(CardData rentCard) {
    Clear();
    cardPile.SetActive(false);
    AddCard(rentCard);
  }

  public void AddOverdueRentCard(CardData overdueRentCard) {
    Clear();
    cardPile.SetActive(false);
    AddCard(overdueRentCard);
  }

  void AddCard(CardData data) {
    Clear();
    GameObject card = Instantiate(cardPrefab);
    CardUI script = card.GetComponent<CardUI>();
    script.Data = data;
    card.transform.SetParent(parent, false);
  }

  public void SetText(int n) {
    cardPile.SetActive(true);
    textField.text = "Rent due in\n" + n + " week(s)";
  }
}
