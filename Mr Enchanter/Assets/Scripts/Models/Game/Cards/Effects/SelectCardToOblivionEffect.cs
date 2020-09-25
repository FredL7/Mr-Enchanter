public class SelectCardToOblivionEffect : SelectCardEffect {
  private GameManager manager;

  override public void ExecuteEffect(GameManager mngr) {
    manager = mngr;
    manager.waitForCardEffect = true;
    manager.overlay.DisplaySelectCardsOverlay(mngr.hand.GetCardIndexes(), this, "Select a card to send to oblivion", mngr.library, true);
  }

  override public void UndoEffect(GameManager mngr) { /* ... */ }

  override public void SelectCard(int card) {
    CardData data = manager.library.GetCard(card);
    manager.AfterCardPlay(null, data);
    manager.overlay.Hide();
  }
}
