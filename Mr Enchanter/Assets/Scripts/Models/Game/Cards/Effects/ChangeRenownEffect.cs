using UnityEngine;

public class ChangeRenownEffect : CardEffect {
  private int changeValue;
  private Factions faction;
  public Factions Faction { get { return faction; } }

  public int GetDelta() { return changeValue; }

  public ChangeRenownEffect(Factions faction, int n) {
    this.faction = faction;
    changeValue = n;
  }

  public bool ConditionsMet(GameManager mngr) {
    if (changeValue > 0) {
      return true;
    } else {
      if (Mathf.Abs(changeValue) > mngr.factions.GetRenown(faction)) {
        return false;
      } else {
        return true;
      }
    }
  }

  public void ExecuteEffect(GameManager mngr) {
    mngr.factions.AddRenown(faction, changeValue);
  }

  public void UndoEffect(GameManager mngr) {
    mngr.factions.AddRenown(faction, -changeValue);
  }
}
