public class CardToVariantEffect : CardEffect {
  private CardData original, variant;

  public CardToVariantEffect(CardData original, CardData variant) {
    this.variant = variant;
    this.original = original;
  }

  public int GetDelta() { return -1; }
  public bool ConditionsMet(GameManager mngr) { return true; }

  public void ExecuteEffect(GameManager mngr) {
    for (int i = 0; i < mngr.library.Count; i++) {
      CardData current = mngr.library.GetCard(i);
      if (current.Title == original.Title) {
        mngr.library.SetCard(i, variant.Clone());
      }
    }

    mngr.library.UpdateVue();
  }

  public void UndoEffect(GameManager mngr) {
    for (int i = 0; i < mngr.library.Count; i++) {
      CardData current = mngr.library.GetCard(i);
      if (current.Title == variant.Title) {
        mngr.library.SetCard(i, original.Clone());
      }
    }

    mngr.library.UpdateVue();
  }
}
