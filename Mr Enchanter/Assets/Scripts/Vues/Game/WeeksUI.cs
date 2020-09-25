using UnityEngine;
using UnityEngine.UI;

public class WeeksUI : MonoBehaviour, WeeksObserver {
  [SerializeField] private Text timeText = null;
  public void UpdateWeeks(WeeksManager weeks) {
    SetTextTime(weeks.Weeks);
  }

  void SetTextTime(int value) {
    timeText.text = "Week: " + value % WeeksManager.WEEK_IN_YEAR + ", Year: " + ((value - (value % WeeksManager.WEEK_IN_YEAR)) / WeeksManager.WEEK_IN_YEAR);
  }
}
