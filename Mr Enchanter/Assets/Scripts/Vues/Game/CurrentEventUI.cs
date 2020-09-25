using UnityEngine;

public class CurrentEventUI : CardPileUI {
  [SerializeField] private Transform parent = null;
  [SerializeField] private GameObject cardPrefab = null;

  public void DisplayCard(CardData data) {
    if (data == null) {
      SceneHelper.DestroyChildrenInParent(parent);
    } else {
      SceneHelper.DestroyChildrenInParent(parent);
      GameObject card = Instantiate(cardPrefab);
      CardUI script = card.GetComponent<CardUI>();
      script.Data = data;
      card.transform.SetParent(parent, false);
    }
  }
}
