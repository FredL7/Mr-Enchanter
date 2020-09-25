using UnityEngine;

public class ResourcesManager : MonoBehaviour {
  [SerializeField] private Apprentices apprentices = null;
  [SerializeField] private Food food = null;
  [SerializeField] private Gold gold = null;
  [SerializeField] private Power power = null;

  public int GetValue(EResources resource) {
    switch (resource) {
      case EResources.APPRENTICES:
        return apprentices.Value;
      case EResources.FOOD:
        return food.Value;
      case EResources.GOLD:
        return gold.Value;
      case EResources.POWER:
        return power.Value;
      default:
        return -1;
    }
  }

  public void AddResources(EResources resource, int n) {
    switch (resource) {
      case EResources.APPRENTICES:
        apprentices.AddResource(n);
        break;
      case EResources.FOOD:
        food.AddResource(n);
        break;
      case EResources.GOLD:
        gold.AddResource(n);
        break;
      case EResources.POWER:
        power.AddResource(n);
        break;
    }
  }

  public void Reset() {
    apprentices.Reset();
    food.Reset();
    gold.Reset();
    power.Reset();
  }

  public bool ValidateResources() {
    return food.Value >= 0 && gold.Value >= 0;
  }

  public void NextTurn() {
    AddResources(EResources.FOOD, -(apprentices.Value + 1));
  }
}
