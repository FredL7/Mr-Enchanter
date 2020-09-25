using UnityEngine;

public class HandUI : MonoBehaviour {
  [SerializeField] private RectTransform parent = null;
  [SerializeField] private GameObject cardPrefab = null;

  private int cardWidth = 210;
  private int cardHeight = 300;
  private int padding = 10;

  public void DisplayCards(CardData[] cards, int[] indexes) {
    SceneHelper.DestroyChildrenInParent(parent);
    for (int i = 0; i < cards.Length; i++) {
      GameObject card = Instantiate(cardPrefab);
      CardUI script = card.GetComponent<CardUI>();
      script.Data = cards[i];
      card.transform.position = new Vector3(i * (cardWidth + padding), 0f, 0f);
      card.transform.SetParent(parent, false);
    }

    parent.sizeDelta = new Vector2((cardWidth + padding) * cards.Length - padding, cardHeight);
  }
}
