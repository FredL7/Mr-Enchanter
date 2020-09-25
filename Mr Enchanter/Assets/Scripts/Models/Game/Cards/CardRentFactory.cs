public class CardRentFactory {
  public static CardData Rent {
    get {
      return new CardData(
        "Rent",
        "You must Pay " + TextHelper.Gold(45) + " for your rent. Failing to play this card will result in the " + TextHelper.Highlight("Overdue Rent") + " Card, " + TextHelper.Highlight("Automatic") + ".",
        CardEffectFactory.goldEffect_Remove45,
        null,
        null,
        0,
        true,
        CardPlayedOrigin.RENT,
        OverdueRent,
        new CardKeyword[] { CardKeywords.Automatic }
      );
    }
  }
  public static CardData OverdueRent {
    get {
      return new CardData(
        "Overdue rent",
        "You must Pay " + TextHelper.Gold(65) + " for your rent, " + TextHelper.Highlight("Automatic") + " and " + TextHelper.Highlight("Dealbreaker") + ".",
        CardEffectFactory.goldEffect_Remove65,
        null,
        null,
        0,
        true,
        CardPlayedOrigin.RENT,
        null,
        new CardKeyword[] { CardKeywords.Automatic, CardKeywords.Dealbreaker }
      );
    }
  }

}
