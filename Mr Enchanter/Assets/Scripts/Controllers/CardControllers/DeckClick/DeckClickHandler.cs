using UnityEngine;
using UnityEngine.EventSystems;

public class DeckClickHandler : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private Deck deck = null;
  public void OnPointerClick(PointerEventData pointerEventData) {
    DeckClickManager.instance.DeckClicked = deck;
  }
}
