using UnityEngine;
using UnityEngine.UI;

public class FactionUI : MonoBehaviour, FactionObserver, CardDragObserver {
  [SerializeField] private Text nameField = null;
  [SerializeField] private Text valueField = null;
  [SerializeField] private Text deltaField = null;
  [SerializeField] private Factions faction = Factions.NIL;

  public void SetName(FactionManager faction) {
    nameField.text = faction.Name;
  }

  public void UpdateFaction(FactionManager faction) {
    ResetDeltaText();
    valueField.text = TextHelper.Bold(faction.Renown);
  }

  public void UpdateDrag(CardData card) {
    if (card != null) {
      if (card.Costs != null && card.Costs.Length != 0) {
        CheckForSetDelta(card.Costs);
      }
      if (card.Effects != null && card.Effects.Length != 0) {
        CheckForSetDelta(card.Effects);
      }
    } else {
      ResetDeltaText();
    }
  }

  void CheckForSetDelta(CardEffect[] effects) {
    foreach (CardEffect effect in effects) {
      if (effect.GetType() == typeof(ChangeRenownEffect)) {
        ChangeRenownEffect factionEffect = (ChangeRenownEffect)effect;
        if (factionEffect.Faction == faction) {
          SetDelta(effect);
        }
      }
    }
  }

  void SetDelta(CardEffect effect) {
    int delta = effect.GetDelta();
    string text = "(" + (delta > 0 ? "+" : "") + delta + ")";
    if (delta < 0) text = TextHelper.Warning(text);
    deltaField.text = text;
  }

  void ResetDeltaText() {
    deltaField.text = "";
  }
}
