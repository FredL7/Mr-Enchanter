public interface CardEffect {
  bool ConditionsMet(GameManager mngr);
  void ExecuteEffect(GameManager mngr);
  void UndoEffect(GameManager mngr);
  int GetDelta();
}
