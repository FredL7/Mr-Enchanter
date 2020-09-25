using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour, ManaObserver, CardDragObserver {
  [SerializeField] private Text manaText = null;
  [SerializeField] private Text deltaText = null;

  public void UpdateMana(int value) {
    ResetDeltaText();
    SetManaText(value);
  }

  public void UpdateDrag(CardData data) {
    // Mana cost
    if (data == null || data.ManaCost == 0) {
      deltaText.text = "";
    } else {
      deltaText.text = TextHelper.Warning("( -" + data.ManaCost + ")");
    }

    // Other mana effect
    if (data != null && data.Effects != null && data.Effects.Length != 0) {
      foreach (CardEffect effect in data.Effects) {
        if (effect.GetType() == typeof(ChangeManaEffect)) {
          int delta = effect.GetDelta();
          string text = "(" + (delta > 0 ? "+" : "") + delta + ")";
          if (delta < 0) text = TextHelper.Warning(text);
          deltaText.text = text;
        }
      }
    }
  }

  void ResetDeltaText() {
    deltaText.text = "";
  }

  void SetManaText(int value) {
    manaText.text = GetText(value);
  }

  string GetText(int value) {
    return TextHelper.Bold(TextHelper.Color(value.ToString(), value == 0 ? ColorHelper.Muted : ColorHelper.ManaColor));
  }
}
