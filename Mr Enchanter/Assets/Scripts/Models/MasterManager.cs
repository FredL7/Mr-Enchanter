using UnityEngine;

public enum ApplicationState {
  HOME, PLAY, TURORIAL, HIGHSCORES
}

public class MasterManager : MonoBehaviour {
  [SerializeField] private VueManager vue = null;
  [SerializeField] private GameManager game = null;
  [SerializeField] private HighScoresManager highscores = null;

  public static ApplicationState appState = ApplicationState.HOME;

  void Awake() {
    GotoHome();
  }

  public void GotoHome() {
    GameManager.gameState = GameState.PAUSE;
    appState = ApplicationState.HOME;
    vue.OpenHomeScreen();
  }

  public void GotoPlay() {
    appState = ApplicationState.PLAY;
    vue.OpenGameScreen();
    game.NewGame();
  }

  public void GotoTutorial() {
    appState = ApplicationState.TURORIAL;
    vue.OpenTutorialScreen();
  }

  public void GotoHighscores() {
    appState = ApplicationState.HIGHSCORES;
    vue.OpenHighScoresScreen();
    highscores.DisplayScores();
  }

  public void Quit() {
    Application.Quit();
  }
}
