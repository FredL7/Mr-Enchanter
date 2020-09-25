public class CardDataFactory {
  public static CardData[] OpeningHand {
    get {
      return new CardData[] {
        Work, Work, Work, Work, Shopping, Shopping
      };
    }
  }

  public static CardData[] SelectableNewCards {
    get {
      return new CardData[] {
        Work, Shopping, Recruit, Ritual,                      // Basics
        Speech, MarketMembership, Promotion, PowerfulRitual,  // Upgraded basics
        Forget,                                               // Others
        RedRenown, RedRitual, ResearchGrant,                  // Red faction
        BlueRenown, BlueRitual, Foresight,                    // Blue faction
        GreenRenown, GreenRitual, MarketBenefactor,           // Green faction
        YellowRenown, YellowRitual, UndergroundNetwork        // Yellow faction
      };
    }
  }

  // Apprentices
  public static CardData Recruit {
    get {
      return new CardData(
        "Recruit",
        "Recruit " + TextHelper.Apprentices(1) + ".",
        null,
        CardEffectFactory.apprenticesEffect_Add1
      );
    }
  }
  public static CardData Speech {
    get {
      return new CardData(
        "Speech",
        "Recruit " + TextHelper.Apprentices(2) + ".",
        null,
        CardEffectFactory.apprenticesEffect_Add2
      );
    }
  }
  public static CardData PublicEvent {
    get {
      return new CardData(
        "Public Event",
        "Recruit " + TextHelper.Apprentices(5) + ", " + TextHelper.Highlight("Ephemeral") + ".",
        null,
        CardEffectFactory.apprenticesEffect_Add5,
        null,
        1,
        true,
        CardPlayedOrigin.HAND,
        null,
        new CardKeyword[] { CardKeywords.Ephemeral }
      );
    }
  }

  // Food
  public static CardData Shopping {
    get {
      return new CardData(
        "Shopping",
        "Buy " + TextHelper.Food(3) + " at the price of " + TextHelper.Gold(10) + ".",
        CardEffectFactory.goldEffect_Remove10,
        CardEffectFactory.foodEffect_Add3
      );
    }
  }
  public static CardData Shopping_Drought {
    get {
      return new CardData(
        "Shopping (Drought)",
        "Buy " + TextHelper.Food(1) + " at the price of " + TextHelper.Gold(10) + ".",
        CardEffectFactory.goldEffect_Remove10,
        CardEffectFactory.foodEffect_Add1
      );
    }
  }
  public static CardData MarketMembership {
    get {
      return new CardData(
        "Market Membership",
        "Buy " + TextHelper.Food(4) + " at the price of " + TextHelper.Gold(10) + ".",
        CardEffectFactory.goldEffect_Remove10,
        CardEffectFactory.foodEffect_Add4
      );
    }
  }

  // Gold
  public static CardData Work {
    get {
      return new CardData(
        "Work",
        "Gain " + TextHelper.Gold(20) + ".",
        null,
        CardEffectFactory.goldEffect_Add20
      );
    }
  }
  public static CardData Work_Overtime {
    get {
      return new CardData(
        "Work (Overtime)",
        "Gain " + TextHelper.Gold(30) + ".",
        null,
        CardEffectFactory.goldEffect_Add30
      );
    }
  }
  public static CardData Work_MissingIngredients {
    get {
      return new CardData(
        "Work (Missing Ingredients)",
        "Gain " + TextHelper.Gold(10) + ".",
        null,
        CardEffectFactory.goldEffect_Add10
      );
    }
  }
  public static CardData Promotion {
    get {
      return new CardData(
        "Promotion",
        "Gain " + TextHelper.Gold(30) + ".",
        null,
        CardEffectFactory.goldEffect_Add30
      );
    }
  }

  // Power
  public static CardData Ritual {
    get {
      return new CardData(
        "Ritual",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(1) + ", consumes " + TextHelper.Apprentices(3) + " and " + TextHelper.Gold(25) + ".",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove3, CardEffectFactory.goldEffect_Remove25 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add1, CardEffectFactory.selectNewCard }
      );
    }
  }
  public static CardData Ritual_StarMisaligned {
    get {
      return new CardData(
        "Ritual (Star Misaligned)",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(0) + ", consumes " + TextHelper.Apprentices(3) + " and " + TextHelper.Gold(25) + ".",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove3, CardEffectFactory.goldEffect_Remove25 },
        null
      );
    }
  }
  public static CardData PowerfulRitual {
    get {
      return new CardData(
        "Powerful Ritual",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(2) + ", consumes " + TextHelper.Apprentices(5) + " and " + TextHelper.Gold(50) + ". <i>Requires power 3 or higher</i>.",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove5, CardEffectFactory.goldEffect_Remove50 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add2, CardEffectFactory.selectNewCard },
        new CardCondition[] { CardConditionFactory.resourceCondition_power3 }
      );
    }
  }

  // Other
  public static CardData Forget {
    get {
      return new CardData(
        "Forget",
        "Discard a card from your hand to " + TextHelper.Highlight("Oblivion") + ".",
        null,
        CardEffectFactory.cardEffect_SendToOblivion
      );
    }
  }

  // Red Faction
  public static CardData RedRenown {
    get {
      return new CardData(
        "Red Renown",
        "Increase your renown to the " + TextHelper.Highlight("Red") + " faction by " + TextHelper.Bold(1) + ".",
        null,
        CardEffectFactory.renownEffect_RedAdd1
      );
    }
  }
  public static CardData RedRitual {
    get {
      return new CardData(
        "Ritual of Strength",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(2) + ", consumes " + TextHelper.Apprentices(4) + " and " + TextHelper.Gold(40) + ". <i>Requires Red renown 5 or higher</i>",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove4, CardEffectFactory.goldEffect_Remove40 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add2, CardEffectFactory.selectNewCard },
        new CardCondition[] { CardConditionFactory.renownCondition_red5 }
      );
    }
  }
  public static CardData ResearchGrant {
    get {
      return new CardData(
        "Research Grant",
        "Recruit " + TextHelper.Apprentices(2) + " and gain " + TextHelper.Gold(25) + ". <i>Requires Red renown 1 or higher</i>",
        null,
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Add2, CardEffectFactory.goldEffect_Add25 },
        new CardCondition[] { CardConditionFactory.renownCondition_red1 }
      );
    }
  }

  // Blue Faction
  public static CardData BlueRenown {
    get {
      return new CardData(
        "Blue Renown",
        "Increase your renown to the " + TextHelper.Highlight("Blue") + " faction by " + TextHelper.Bold(1) + ".",
        null,
        CardEffectFactory.renownEffect_BlueAdd1
      );
    }
  }
  public static CardData BlueRitual {
    get {
      return new CardData(
        "Ritual of Knowledge",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(1) + " and Draw " + TextHelper.Bold(2) + " Card, consumes " + TextHelper.Apprentices(3) + " and " + TextHelper.Gold(25) + ". <i>Requires Blue renown 5 or higher</i>",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove3, CardEffectFactory.goldEffect_Remove25 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add1, CardEffectFactory.cardEffect_Draw2, CardEffectFactory.selectNewCard },
        new CardCondition[] { CardConditionFactory.renownCondition_blue5 }
      );
    }
  }
  public static CardData Foresight {
    get {
      return new CardData(
        "Foresight",
        "Look at the top " + TextHelper.Bold(3) + " Cards of the " + TextHelper.Highlight("Knowledge") + " pile and draw " + TextHelper.Bold(1) + " of them. <i>Requires Blue renown 1 or higher</i>.",
        null,
        CardEffectFactory.cardEffect_LookAtTop3Draw1,
        new CardCondition[] { CardConditionFactory.renownCondition_blue1 },
        0
      );
    }
  }

  // Green Faction
  public static CardData GreenRenown {
    get {
      return new CardData(
        "Green Renown",
        "Increase your renown to the " + TextHelper.Highlight("Green") + " faction by " + TextHelper.Bold(1) + ".",
        null,
        CardEffectFactory.renownEffect_GreenAdd1
      );
    }
  }
  public static CardData GreenRitual {
    get {
      return new CardData(
        "Ritual of Power",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(1) + " and add 2 " + TextHelper.Highlight("Surge of Power") + " cards to your library, consumes " + TextHelper.Apprentices(3) + " and " + TextHelper.Gold(25) + ". <i>Requires Green renown 5 or higher</i>",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove3, CardEffectFactory.goldEffect_Remove25 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add1, CardEffectFactory.addCard_SurgeOfPower, CardEffectFactory.addCard_SurgeOfPower, CardEffectFactory.selectNewCard },
        new CardCondition[] { CardConditionFactory.renownCondition_green5 },
        1,
        false,
        CardPlayedOrigin.HAND,
        CardDataFactory.SurgeOfPower
      );
    }
  }
  public static CardData SurgeOfPower {
    get {
      return new CardData(
        "Surge of Power",
        "Gain " + TextHelper.Mana(1) + ", " + TextHelper.Highlight("Ephemeral") + ".",
        null,
        CardEffectFactory.manaEffect_Add1,
        null,
        0,
        true,
        CardPlayedOrigin.HAND,
        null,
        new CardKeyword[] { CardKeywords.Ephemeral }
      );
    }
  }
  public static CardData MarketBenefactor {
    get {
      return new CardData(
        "Market Benefactor",
        "Buy " + TextHelper.Food(5) + " at the price of " + TextHelper.Gold(10) + ". <i>Requires Green renown 1 or Higher</i>",
        CardEffectFactory.goldEffect_Remove10,
        CardEffectFactory.foodEffect_Add5,
        new CardCondition[] { CardConditionFactory.renownCondition_green1 }
      );
    }
  }

  // Yellow Faction
  public static CardData YellowRenown {
    get {
      return new CardData(
        "Yellow Renown",
        "Increase your renown to the " + TextHelper.Highlight("Yellow") + " faction by " + TextHelper.Bold(1) + ".",
        null,
        CardEffectFactory.renownEffect_YellowAdd1
      );
    }
  }
  public static CardData YellowRitual {
    get {
      return new CardData(
        "Ritual of Gold",
        "Increase your " + TextHelper.Power() + " by " + TextHelper.Bold(1) + " and add " + TextHelper.Gold(100) + ", consumes " + TextHelper.Apprentices(3) + " and " + TextHelper.Gold(25) + ". <i>Requires Yellow renown 5 or higher</i>",
        new CardEffect[] { CardEffectFactory.apprenticesEffect_Remove3, CardEffectFactory.goldEffect_Remove25 },
        new CardEffect[] { CardEffectFactory.powerEffect_Add1, CardEffectFactory.goldEffect_Add100, CardEffectFactory.selectNewCard },
        new CardCondition[] { CardConditionFactory.renownCondition_yellow5 },
        1,
        false,
        CardPlayedOrigin.HAND,
        CardDataFactory.SurgeOfPower
      );
    }
  }
  public static CardData UndergroundNetwork {
    get {
      return new CardData(
        "Underground Network",
        "Gain " + TextHelper.Gold(35) + ". <i>Requires Yellow renown 1 or higher.</i>.",
        null,
        CardEffectFactory.goldEffect_Add35,
        new CardCondition[] { CardConditionFactory.renownCondition_yellow1 }
      );
    }
  }
}
