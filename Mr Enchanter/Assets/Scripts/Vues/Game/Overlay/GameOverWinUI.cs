using UnityEngine;
using UnityEngine.UI;

public class GameOverWinUI : OverlayPanel {
  [SerializeField] private GameManager mngr = null;
  [SerializeField] private Text timeTakenText = null;

  new public void Display() {
    int weeks = mngr.weeks.Weeks % WeeksManager.WEEK_IN_YEAR;
    int years = (mngr.weeks.Weeks - weeks) / WeeksManager.WEEK_IN_YEAR;

    if (years > 0) {
      timeTakenText.text = years.ToString() + " and " + weeks.ToString() + " weeks";
    } else {
      timeTakenText.text = weeks.ToString() + " weeks";
    }

    gameObject.SetActive(true);
  }
}
