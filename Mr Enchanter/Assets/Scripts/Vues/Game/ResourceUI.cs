using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour, ResourceObserver, CardDragObserver {
  [SerializeField] private Text nameField = null;
  [SerializeField] private Text valueField = null;
  [SerializeField] private Text deltaField = null;
  [SerializeField] private EResources resource = EResources.NIL;

  public void SetName(ResourceManager resource) {
    nameField.text = resource.Name;
  }

  public void UpdateResource(ResourceManager resource) {
    ResetDeltaText();
    valueField.text = TextHelper.Color(TextHelper.Bold(resource.Value), resource.Color);
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
      if (effect.GetType() == typeof(ChangeResourceEffect)) {
        ChangeResourceEffect resourceEffect = (ChangeResourceEffect)effect;
        if (resourceEffect.Resource == resource) {
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
