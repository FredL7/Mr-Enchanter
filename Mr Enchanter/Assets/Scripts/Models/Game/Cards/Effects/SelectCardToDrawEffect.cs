public class SelectCardToDrawEffect : SelectCardEffect {
  private int revealAmount, drawAmount;
  private RevealCardsInKnowledgeEffect revealEffect;

  private GameManager manager;

  public SelectCardToDrawEffect(int reveal, int draw) {
    revealAmount = reveal;
    drawAmount = draw;
    revealEffect = new RevealCardsInKnowledgeEffect(revealAmount);
  }

  override public void ExecuteEffect(GameManager mngr) {
    manager = mngr;
    revealEffect.ExecuteEffect(mngr);
    mngr.overlay.DisplaySelectCardsOverlay(mngr.knowledgePile.GetCardsRevealed(), this, "Select a card to draw", mngr.library);
  }

  override public void UndoEffect(GameManager mngr) {
    revealEffect.UndoEffect(mngr);
  }

  override public void SelectCard(int card) {
    manager.knowledgePile.RemoveCard(card);
    manager.hand.AddCard(card);
    manager.overlay.Hide();
  }
}
