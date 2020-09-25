using UnityEngine;

public class VueManager : MonoBehaviour {
  [SerializeField] private Screen homeScreen = null;
  [SerializeField] private Screen gameScreen = null;
  [SerializeField] private Screen highscoresScreen = null;
  [SerializeField] private Screen TutorialScreen = null;

  public void OpenHomeScreen() {
    CloseAll();
    homeScreen.Open();
  }

  public void OpenGameScreen() {
    CloseAll();
    gameScreen.Open();
  }

  public void OpenHighScoresScreen() {
    CloseAll();
    highscoresScreen.Open();
  }

  public void OpenTutorialScreen() {
    CloseAll();
    TutorialScreen.Open();
  }

  void CloseAll() {
    homeScreen.Close();
    gameScreen.Close();
    highscoresScreen.Close();
    TutorialScreen.Close();
  }
}
