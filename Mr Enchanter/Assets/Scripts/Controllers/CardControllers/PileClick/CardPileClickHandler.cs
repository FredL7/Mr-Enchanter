using UnityEngine;
using UnityEngine.EventSystems;

public class CardPileClickHandler : MonoBehaviour, IPointerClickHandler {
  public GameObject reference = null;
  public void OnPointerClick(PointerEventData pointerEventData) {
    if (reference != null) {
      CardPileClickManager.instance.PileClicked = reference;
    } else {
      CardPileClickManager.instance.PileClicked = gameObject;
    }
  }
}
