using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickHandler : MonoBehaviour, IPointerClickHandler {
  public void OnPointerClick(PointerEventData pointerEventData) {
    CardClickManager.instance.CardBeingClicked = gameObject;
  }
}
