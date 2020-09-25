public class SelectNewCardEffect : CardEffect {

  public bool ConditionsMet(GameManager mngr) { return true; }
  public int GetDelta() { return -1; }

  public void ExecuteEffect(GameManager mngr) {
    mngr.overlay.DisplaySelectNewCard();
  }

  public void UndoEffect(GameManager mngr) { }
}
