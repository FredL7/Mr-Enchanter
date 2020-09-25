using UnityEngine;

public static class SceneHelper {
  public static void DestroyChildrenInParent(Transform parent) {
    foreach (Transform child in parent)
      GameObject.Destroy(child.gameObject);
  }
}
