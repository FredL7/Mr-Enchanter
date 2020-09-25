public class DrawCardEffect : CardEffect {
  private int drawAmount;

  public int GetDelta() { return -1; }

  public DrawCardEffect(int n) {
    drawAmount = n;
  }

  public bool ConditionsMet(GameManager mngr) {
    return true;
  }

  public void ExecuteEffect(GameManager mngr) {
    mngr.DrawCards(drawAmount);
  }

  public void UndoEffect(GameManager mngr) {
    // TODO;
  }
}
