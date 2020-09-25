using UnityEngine;

public class Screen : MonoBehaviour {
  public void Open() {
    gameObject.SetActive(true);
  }

  public void Close() {
    gameObject.SetActive(false);
  }
}
