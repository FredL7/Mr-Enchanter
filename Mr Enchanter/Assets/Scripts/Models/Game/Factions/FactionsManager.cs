using UnityEngine;

public class FactionsManager : MonoBehaviour {
  [SerializeField] private RedFaction redFaction = null;
  [SerializeField] private BlueFaction blueFaction = null;
  [SerializeField] private GreenFaction greenFaction = null;
  [SerializeField] private YellowFaction yellowFaction = null;

  public int GetRenown(Factions faction) {
    switch (faction) {
      case Factions.RED:
        return redFaction.Renown;
      case Factions.BLUE:
        return blueFaction.Renown;
      case Factions.GREEN:
        return greenFaction.Renown;
      case Factions.YELLOW:
        return yellowFaction.Renown;
      default:
        return -1;
    }
  }

  public void AddRenown(Factions faction, int n) {
    switch (faction) {
      case Factions.RED:
        redFaction.AddRenown(n);
        break;
      case Factions.BLUE:
        blueFaction.AddRenown(n);
        break;
      case Factions.GREEN:
        greenFaction.AddRenown(n);
        break;
      case Factions.YELLOW:
        yellowFaction.AddRenown(n);
        break;
    }
  }

  public void Reset() {
    redFaction.Reset();
    blueFaction.Reset();
    greenFaction.Reset();
    yellowFaction.Reset();
  }
}
