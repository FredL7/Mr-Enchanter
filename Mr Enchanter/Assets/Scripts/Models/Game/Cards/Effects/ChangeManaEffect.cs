using UnityEngine;

public class ChangeManaEffect : CardEffect {
  public int changeValue;

  public int GetDelta() { return changeValue; }

  public ChangeManaEffect(int n) {
    changeValue = n;
  }

  public bool ConditionsMet(GameManager mngr) {
    if (changeValue > 0) {
      return true;
    } else {
      if (Mathf.Abs(changeValue) > mngr.mana.Mana) {
        return false;
      } else {
        return true;
      }
    }
  }

  public void ExecuteEffect(GameManager mngr) {
    mngr.mana.AddMana(changeValue);
  }

  public void UndoEffect(GameManager mngr) {
    mngr.mana.AddMana(-changeValue);
  }
}
