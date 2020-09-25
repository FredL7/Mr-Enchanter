using UnityEngine;

public abstract class OverlayPanel : MonoBehaviour {
  public void Hide() {
    gameObject.SetActive(false);
  }

  public void Display() {
    gameObject.SetActive(true);
  }
}
