using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {
  [SerializeField] private Text titleText = null, descriptionText = null, manaCostText = null;

  private CardData data;
  public CardData Data {
    get { return data; }
    set {
      data = value;
      titleText.text = data.Title;
      manaCostText.text = data.ManaCost.ToString();
      descriptionText.text = data.Description;
      // descriptionText.text = "handIndex: " + data.handIndex + "\nIndexInDeck: " + data.indexInDeck;

      if (data.ManaCost == -1) {
        manaCostText.text = "-";
        CardDragHandler script = GetComponent<CardDragHandler>();
        script.enabled = false;
      }
    }
  }
}
