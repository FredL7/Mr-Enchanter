using UnityEngine;
using UnityEngine.UI;

public class GameOverLoseUI : OverlayPanel {
  [SerializeField] private GameManager mngr = null;
  [SerializeField] private Text reasonOfDeathText = null, powerText = null;

  new public void Display() {
    bool deathByHunger = mngr.resources.GetValue(EResources.FOOD) < 0;
    bool deathByGold = mngr.resources.GetValue(EResources.GOLD) < 0;
    string deathText;
    if(deathByHunger & deathByGold) {
      deathText = "You ran out of Food and Gold.";
    } else if (deathByHunger) {
      deathText = "You ran out of food.";
    } else {
      deathText = "You ran out of gold.";
    }
    reasonOfDeathText.text = deathText;

    powerText.text = mngr.resources.GetValue(EResources.POWER).ToString();

    gameObject.SetActive(true);
  }
}
