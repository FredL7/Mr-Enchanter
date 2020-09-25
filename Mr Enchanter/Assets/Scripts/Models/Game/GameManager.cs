using UnityEngine;

public enum GameState {
  PLAY, PAUSE
}

public class GameManager : MonoBehaviour {
  [SerializeField] private HighScoresManager highScores = null;

  public Overlay overlay = null;

  public Library library = null;
  public Knowledge knowledgePile = null;
  public Memories memoriesPile = null;
  public Hand hand = null;

  public Deck oblivionDeck = null;
  public Oblivion oblivionPile = null;

  [SerializeField] private Deck events = null;
  [SerializeField] private Events eventsPile = null;
  [SerializeField] private CurrentEvent currentEventPile = null;

  [SerializeField] private RentManager rent = null;

  public ResourcesManager resources;
  public WeeksManager weeks;
  public ManaManager mana;
  public FactionsManager factions;

  public int handSize = 4;
  public int powerToWin = 10;

  public static GameState gameState = GameState.PAUSE;

  public void NewGame() {
    overlay.Hide();

    resources.Reset();
    weeks.Reset();
    mana.Reset();
    factions.Reset();

    library.Reset();
    rent.Reset();
    events.Reset();
    hand.Reset();

    library.AddCards(CardDataFactory.OpeningHand);
    knowledgePile.Shuffle();

    events.AddCards(CardEventFactory.EventDeck);
    eventsPile.Shuffle();
    DrawEvent();

    DrawHand();

    gameState = GameState.PLAY;
  }

  void DrawHand() {
    DrawCards(handSize);
  }

  public void DrawCards(int n) {
    int[] cards = new int[n];
    for (int i = 0; i < n; i++) {
      int cardDrawn = DrawCard();
      cards[i] = cardDrawn;
    }
    hand.AddCards(cards);
  }

  int DrawCard() {
    int cardDrawn = knowledgePile.DrawCard();
    if (cardDrawn == -1) {
      int[] tempPile = memoriesPile.Empty();
      if (tempPile != null && tempPile.Length != 0) {
        knowledgePile.AddCards(tempPile);
        knowledgePile.Shuffle();
        cardDrawn = knowledgePile.DrawCard();
      } else {
        // Ran out of cards to draw
        return -1;
      }
    }
    return cardDrawn;
  }

  void DrawEvent() {
    // Undo last event (for those that take a general effect)
    if (currentEventPile.Count != 0) {
      CardData lastEventCard = events.GetCard(currentEventPile.GetCard(0));
      if (lastEventCard.ManaCost == -1) // Indicate passive effect
        lastEventCard.Undo(this);
    }

    if (eventsPile.Count == 0) {
      eventsPile.AddCards(currentEventPile.Empty());
      eventsPile.Shuffle();
    }

    int cardDrawn = eventsPile.DrawCard();
    currentEventPile.AddCard(cardDrawn);

    CardData newEventCard = events.GetCard(cardDrawn);
    if (newEventCard.ManaCost == -1) // Indicate passive effect
      PlayCardSubtle(cardDrawn, events);

    currentEventPile.UpdateVue();
    hand.UpdateVue();
  }

  public bool CanPlayCard(int card, Deck deck) {
    return deck.GetCard(card).CanPlay(this);
  }

  public bool CanPlayCard(CardData card) {
    return card.CanPlay(this);
  }

  public void PlayCard(int card, Deck deck) {
    if (CanPlayCard(card, deck))
      PlayCardSubtle(card, deck);
  }

  public void PlayCard(CardData card) {
    if (CanPlayCard(card))
      PlayCardSubtle(card);
  }

  void PlayCardSubtle(int card, Deck deck) {
    PlayCardSubtle(deck.GetCard(card));
  }

  public bool waitForCardEffect = false;
  public CardData lastCardPlayed = null;
  void PlayCardSubtle(CardData card) {
    card.Play(this);

    lastCardPlayed = card;

    if (!waitForCardEffect) {
      AfterCardPlay(card);
    }
  }

  public void AfterCardPlay(CardData card, CardData cardToOblivion = null) {
    if (card == null) // From SelectCardToOblivionEffect
      card = lastCardPlayed;

    waitForCardEffect = false;
    switch (card.CardPlayedOrigin) {
      case CardPlayedOrigin.HAND:
        hand.DiscardCard(card);
        if (card.DestroyAfterPlay || card == cardToOblivion) {
          library.RemoveCard(card);
          oblivionDeck.AddCard(card);
        } else {
          memoriesPile.AddCard(card.indexInDeck);
        }

        if (cardToOblivion != null && card != cardToOblivion) {
          hand.DiscardCard(cardToOblivion);
          library.RemoveCard(cardToOblivion);
          oblivionDeck.AddCard(cardToOblivion);
        }
        break;
      case CardPlayedOrigin.RENT:
        rent.RemoveCard();
        break;
      case CardPlayedOrigin.EVENTS:
        currentEventPile.CardPlayed();
        break;
    }

    card.ResetIndexes();

    if (LoseConditionsMet())
      GameOverLose();
    else if (WinConditionsMet())
      GameOverWin();
  }

  public void BuyCard(ShopCard item) {
    if (resources.GetValue(EResources.GOLD) >= item.price) {
      resources.AddResources(EResources.GOLD, -item.price);
      library.AddCard(item.card.Clone(), memoriesPile);
    }
  }

  public void NextTurn() {
    // Rent
    if (rent.RentDue) {
      PlayCard(rent.RentCard, rent);
    } else if (rent.RentOverdue) {
      PlayCardSubtle(rent.OverdueRentCard, rent);
    }

    // Other
    resources.NextTurn();
    if (!LoseConditionsMet()) {
      weeks.NextTurn();
      mana.NextTurn();
      int[] discardedCards = hand.Empty();
      memoriesPile.AddCards(discardedCards);
      library.ResetIndexes();
      DrawEvent();
      DrawHand();
    } else {
      if (gameState == GameState.PLAY) // Otherwise already lost by playing a card
        GameOverLose();
    }
  }

  bool LoseConditionsMet() {
    return !resources.ValidateResources();
  }

  bool WinConditionsMet() {
    return resources.GetValue(EResources.POWER) >= powerToWin;
  }

  void GameOverLose() {
    gameState = GameState.PAUSE;
    overlay.DisplayGameOverLose();
    highScores.AddScore(resources.GetValue(EResources.POWER), weeks.Weeks);
  }

  void GameOverWin() {
    gameState = GameState.PAUSE;
    overlay.DisplayGameOverWin();
    highScores.AddScore(resources.GetValue(EResources.POWER), weeks.Weeks);
  }
}
