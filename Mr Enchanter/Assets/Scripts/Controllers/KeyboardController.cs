using UnityEngine;

public class KeyboardController : MonoBehaviour {
  [SerializeField] private GameManager manager = null;

  void Update() {
    // Playing
    if (MasterManager.appState == ApplicationState.PLAY) {
      if (GameManager.gameState == GameState.PLAY) {
        // Next turn shortcut
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
          manager.NextTurn();
        }
      }
    }
  }

}
