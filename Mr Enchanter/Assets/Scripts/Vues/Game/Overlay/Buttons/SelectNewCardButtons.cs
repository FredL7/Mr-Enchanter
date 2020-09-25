using System.Collections.Generic;
using UnityEngine;

public class SelectNewCardButtons : MonoBehaviour, FactionObserver, ResourceObserver {
  private List<SelectNewCardButton> btns = new List<SelectNewCardButton>();

  public void AddButton(SelectNewCardButton button) {
    btns.Add(button);
  }

  public void UpdateFaction(FactionManager m) {
    foreach (SelectNewCardButton btn in btns)
      btn.CheckForConditions();
  }

  public void UpdateResource(ResourceManager m) {
    foreach (SelectNewCardButton btn in btns)
      btn.CheckForConditions();
  }
}
