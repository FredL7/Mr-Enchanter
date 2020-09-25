public class CardData {

  public string Title { get; private set; }
  public string Description { get; private set; }
  public int ManaCost { get; private set; }
  public CardEffect[] Costs { get; private set; }
  public CardEffect[] Effects { get; private set; }
  public CardCondition[] Conditions { get; private set; }
  public bool DestroyAfterPlay { get; private set; }
  public CardPlayedOrigin CardPlayedOrigin { get; private set; }
  public CardData AssociatedCard { get; private set; }
  public CardKeyword[] Keywords { get; private set; }

  public int handIndex = -1;
  public int indexInDeck = -1;

  // TODO: Merge the 2 methods, remove redundancy
  public CardData(
    string title,
    string description,
    CardEffect[] costs,
    CardEffect[] effects,
    CardCondition[] conditions = null,
    int manaCost = 1,
    bool destroyAfterPlay = false,
    CardPlayedOrigin cardPlayedOrigin = CardPlayedOrigin.HAND,
    CardData associatedCard = null,
    CardKeyword[] keywords = null
  ) {
    Title = title;
    Description = description;
    ManaCost = manaCost;
    Costs = costs;
    Effects = effects;
    Conditions = conditions;
    DestroyAfterPlay = destroyAfterPlay;
    CardPlayedOrigin = cardPlayedOrigin;
    AssociatedCard = associatedCard;
    Keywords = keywords;
  }

  public CardData(
    string title,
    string description,
    CardEffect cost,
    CardEffect effect,
    CardCondition[] conditions = null,
    int manaCost = 1,
    bool destroyAfterPlay = false,
    CardPlayedOrigin cardPlayedOrigin = CardPlayedOrigin.HAND,
    CardData associatedCard = null,
    CardKeyword[] keywords = null
  ) {
    Title = title;
    Description = description;
    ManaCost = manaCost;
    if (cost != null) Costs = new CardEffect[] { cost };
    if (effect != null) Effects = new CardEffect[] { effect };
    Conditions = conditions;
    DestroyAfterPlay = destroyAfterPlay;
    CardPlayedOrigin = cardPlayedOrigin;
    AssociatedCard = associatedCard;
    Keywords = keywords;
  }

  public CardData Clone() {
    return new CardData(Title, Description, Costs, Effects, Conditions, ManaCost, DestroyAfterPlay, CardPlayedOrigin, AssociatedCard, Keywords);
  }

  public void Play(GameManager mngr) {
    if (ManaCost > 0)
      mngr.mana.RemoveMana(ManaCost);

    if (Costs != null)
      foreach (CardEffect effect in Costs)
        effect.ExecuteEffect(mngr);

    if (Effects != null)
      foreach (CardEffect effect in Effects)
        effect.ExecuteEffect(mngr);
  }

  public void Undo(GameManager mngr) {
    if (ManaCost > 0)
      mngr.mana.RemoveMana(-ManaCost);

    if (Costs != null)
      foreach (CardEffect effect in Costs)
        effect.UndoEffect(mngr);

    if (Effects != null)
      foreach (CardEffect effect in Effects)
        effect.UndoEffect(mngr);
  }

  public bool CanPlay(GameManager mngr) {
    if (mngr.mana.Mana < ManaCost)
      return false;

    if (Costs == null)
      return true;

    foreach (CardEffect effect in Costs)
      if (!effect.ConditionsMet(mngr))
        return false;

    return true;
  }

  public void ResetIndexes() {
    handIndex = -1;
  }
}
