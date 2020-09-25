using UnityEngine;
using UnityEngine.UI;

public class ScoreRow : MonoBehaviour {
  [SerializeField] private Text powerText = null, timeText = null;

  public void SetText(int power, int time) {
    powerText.text = power.ToString();
    timeText.text = time % WeeksManager.WEEK_IN_YEAR + " week(s) and " + ((time - (time % WeeksManager.WEEK_IN_YEAR)) / WeeksManager.WEEK_IN_YEAR) + " year(s)";
  }
}
