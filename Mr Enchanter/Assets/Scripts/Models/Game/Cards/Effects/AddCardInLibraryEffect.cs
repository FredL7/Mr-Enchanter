public class AddCardInLibraryEffect : CardEffect {
  private CardData newCard;

  public AddCardInLibraryEffect(CardData newCard) {
    this.newCard = newCard;
  }

  public int GetDelta() { return -1; }
  public bool ConditionsMet(GameManager mngr) { return true; }

  public void ExecuteEffect(GameManager mngr) {
    mngr.library.AddCard(newCard.Clone(), mngr.memoriesPile);
    mngr.library.UpdateVue();
  }

  public void UndoEffect(GameManager mngr) {
    mngr.library.RemoveCard(newCard);
  }
}
