using UnityEngine;

public class CardOverlay : OverlayPanel {
  [SerializeField] private CardUI mainCard = null;
  [SerializeField] private CardUI associatedCard = null;

  [SerializeField] private GameObject keywordPanelPrefab = null;
  [SerializeField] private Transform mainKeywordParent = null;
  [SerializeField] private Transform associatedKeywordParent = null;

  private int keywordPanelHeight = 90;
  private int padding = 10;

  private CardData cardData;
  public CardData CardData {
    set {
      cardData = value;
      UpdateVue();
    }
  }

  void Awake() {
    Disable(mainCard);
    Disable(associatedCard);
  }

  void Disable(CardUI card) {
    card.GetComponent<CardDragHandler>().enabled = false;
    card.GetComponent<CardClickHandler>().enabled = false;
  }

  void UpdateVue() {
    SceneHelper.DestroyChildrenInParent(mainKeywordParent);
    SceneHelper.DestroyChildrenInParent(associatedKeywordParent);

    SetCard(mainCard, cardData, mainKeywordParent);

    if (cardData.AssociatedCard == null) {
      associatedCard.gameObject.SetActive(false);
    } else {
      SetCard(associatedCard, cardData.AssociatedCard, associatedKeywordParent);
      associatedCard.gameObject.SetActive(true);
    }
  }

  void SetCard(CardUI vue, CardData data, Transform parent) {
    vue.Data = data;
    if (data.Keywords != null && data.Keywords.Length != 0) {
      for (int i = 0; i < data.Keywords.Length; i++) {
        GameObject keywordPanel = Instantiate(keywordPanelPrefab);
        KeywordUI script = keywordPanel.GetComponent<KeywordUI>();
        script.SetText(data.Keywords[i]);
        keywordPanel.transform.position = new Vector3(0, -i * (keywordPanelHeight + padding), 0);
        keywordPanel.transform.SetParent(parent, false);
      }
    }
  }
}
