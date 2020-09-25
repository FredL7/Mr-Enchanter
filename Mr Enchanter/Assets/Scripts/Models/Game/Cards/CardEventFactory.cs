public class CardEventFactory {
  public static CardData[] EventDeck {
    get {
      return new CardData[] {
        SunnyDay, SunnyDay, SunnyDay,
        WindyDay, WindyDay, WindyDay,
        RainyDay, RainyDay, RainyDay,
        Overtime,
        MissingIngredients,
        Drought,
        StarMisaligned,
        Gift,
        BountyfulHarvest,
        MarketDay, MarketDay,
        Invitation
      };
    }
  }

  // Effect on Work
  public static CardData Overtime {
    get {
      return new CardData(
        "Overtime",
        "Work gives " + TextHelper.Bold(10) + " more " + TextHelper.Gold() + ".",
        null,
        CardEffectFactory.cardToVariant_Overtime,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }
  public static CardData MissingIngredients {
    get {
      return new CardData(
        "Missing Ingredients",
        "Work gives " + TextHelper.Bold(10) + " less " + TextHelper.Gold() + ".",
        null,
        CardEffectFactory.cardToVariant_MissingIngredients,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }

  // Effect on Shopping
  public static CardData Drought {
    get {
      return new CardData(
        "Drought",
        "Shopping gives only " + TextHelper.Food(1) + ".",
        null,
        CardEffectFactory.cardToVariant_Drought,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }

  // Effect on Ritual
  public static CardData StarMisaligned {
    get {
      return new CardData(
        "Star Misalignment",
        "Ritual has no effect.",
        null,
        CardEffectFactory.cardToVariant_StarsMisaligned,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }

  // Bonus resources
  public static CardData Gift {
    get {
      return new CardData(
        "Gift",
        "Gain " + TextHelper.Gold(10) + ".",
        null,
        CardEffectFactory.goldEffect_Add10,
        null,
        0,
        false,
        CardPlayedOrigin.EVENTS
      );
    }
  }
  public static CardData BountyfulHarvest {
    get {
      return new CardData(
        "Bountyful Harvest",
        "Gain " + TextHelper.Food(1) + ".",
        null,
        CardEffectFactory.foodEffect_Add1,
        null,
        0,
        false,
        CardPlayedOrigin.EVENTS
      );
    }
  }

  // Shop
  public static CardData MarketDay {
    get {
      return new CardData(
        "Market Day",
        "Buy " + TextHelper.Food(5) + " at the price of " + TextHelper.Gold(20) + ".",
        CardEffectFactory.goldEffect_Remove20,
        CardEffectFactory.foodEffect_Add5,
        null,
        1,
        false,
        CardPlayedOrigin.EVENTS
      );
    }
  }

  // New Cards
  public static CardData Invitation {
    get {
      return new CardData(
        "Invitation",
        "Add the " + TextHelper.Highlight("Public Event") + " Card to your memories at the cost of " + TextHelper.Gold(10) + " and " + TextHelper.Apprentices(1) + ".",
        new CardEffect[] { CardEffectFactory.goldEffect_Remove10, CardEffectFactory.apprenticesEffect_Remove1 },
        new CardEffect[] { CardEffectFactory.addCard_PublicEvent },
        null,
        1,
        false,
        CardPlayedOrigin.EVENTS,
        CardDataFactory.PublicEvent
      );
    }
  }

  // Nothing Happens
  public static CardData SunnyDay {
    get {
      return new CardData(
        "Sunny Day",
        "Nothing happens",
        null,
        CardEffectFactory.nilEffect,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }
  public static CardData WindyDay {
    get {
      return new CardData(
        "Windy Day",
        "Nothing happens",
        null,
        CardEffectFactory.nilEffect,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }
  public static CardData RainyDay {
    get {
      return new CardData(
        "Rainy Day",
        "Nothing happens",
        null,
        CardEffectFactory.nilEffect,
        null,
        -1,
        false,
        CardPlayedOrigin.EVENTS,
        null,
        new CardKeyword[] { CardKeywords.Passive }
      );
    }
  }

}
