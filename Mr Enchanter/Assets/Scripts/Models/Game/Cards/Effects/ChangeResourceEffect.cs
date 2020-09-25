using UnityEngine;

public class ChangeResourceEffect : CardEffect {
  private int changeValue;
  private EResources resource;
  public EResources Resource { get { return resource; } }

  public int GetDelta() { return changeValue; }

  public ChangeResourceEffect(EResources resource, int n) {
    this.resource = resource;
    changeValue = n;
  }

  public bool ConditionsMet(GameManager mngr) {
    if (changeValue > 0) {
      return true;
    } else {
      if (Mathf.Abs(changeValue) > mngr.resources.GetValue(resource)) {
        return false;
      } else {
        return true;
      }
    }
  }

  public void ExecuteEffect(GameManager mngr) {
    mngr.resources.AddResources(resource, changeValue);
  }

  public void UndoEffect(GameManager mngr) {
    mngr.resources.AddResources(resource, -changeValue);
  }
}
