using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragSlot : MonoBehaviour, IDropHandler {
  [SerializeField] GameManager gameManager = null;

  public void OnDrop(PointerEventData eventData) {
    if (GameManager.gameState == GameState.PLAY) {
      GameObject draggedItem = CardDragManager.instance.CardBeingDragged;
      CardDragManager.instance.CardBeingDragged = null;
      CardData card = draggedItem.GetComponent<CardUI>().Data;
      gameManager.PlayCard(card);
    }
  }
}
