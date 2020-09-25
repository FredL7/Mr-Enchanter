public abstract class SelectCardEffect : CardEffect {
  public bool ConditionsMet(GameManager mngr) { return true; }
  public int GetDelta() { return -1; }

  public abstract void ExecuteEffect(GameManager mngr);
  public abstract void UndoEffect(GameManager mngr);
  public abstract void SelectCard(int card);
}
