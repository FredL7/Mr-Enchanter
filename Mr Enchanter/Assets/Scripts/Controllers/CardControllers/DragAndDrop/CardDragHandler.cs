using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
  Vector3 startPosition;
  Transform startParent;
  Vector3 clickOffset = Vector3.zero;

  public void OnBeginDrag(PointerEventData eventData) {
    if (GameManager.gameState == GameState.PLAY) {
      CardDragManager.instance.CardBeingDragged = gameObject;
      startPosition = transform.position;
      startParent = transform.parent;
      GetComponent<CanvasGroup>().blocksRaycasts = false;
      clickOffset = Input.mousePosition - transform.position;
    }
  }

  public void OnDrag(PointerEventData eventData) {
    if (GameManager.gameState == GameState.PLAY) {
      transform.position = new Vector3(
        Input.mousePosition.x - clickOffset.x,
        Input.mousePosition.y - clickOffset.y,
        Input.mousePosition.z - clickOffset.z
      );
    } else {
      OnEndDrag(eventData);
    }
  }

  public void OnEndDrag(PointerEventData eventData) {
    clickOffset = Vector3.zero;
    CardDragManager.instance.CardBeingDragged = null;
    GetComponent<CanvasGroup>().blocksRaycasts = true;
    if (transform.parent == startParent) {
      transform.position = startPosition;
    }
  }
}
