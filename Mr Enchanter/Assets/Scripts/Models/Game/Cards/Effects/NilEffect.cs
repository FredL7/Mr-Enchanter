public class NilEffect : CardEffect {
  public bool ConditionsMet(GameManager mngr) { return true; }
  public void ExecuteEffect(GameManager mngr) { return; }
  public void UndoEffect(GameManager mngr) { return; }
  public int GetDelta() { return -1; }
  public CardEffect Clone() { return new NilEffect(); }
}
