using UnityEngine;

public class RevealCardsInKnowledgeEffect : CardEffect {
  private int revealAmount;

  public int GetDelta() { return -1; }

  public RevealCardsInKnowledgeEffect(int n) {
    revealAmount = n;
  }

  public bool ConditionsMet(GameManager mngr) {
    return true;
  }

  public void ExecuteEffect(GameManager mngr) {
    mngr.knowledgePile.SetCardKnown(revealAmount);
    // CardPileClickManager.instance.PileClicked = mngr.knowledgePile.gameObject;
  }

  public void UndoEffect(GameManager mngr) {
    mngr.knowledgePile.SetCardKnown(0);
  }
}
