using UnityEngine;
using UnityEngine.EventSystems;

public class Overlay : MonoBehaviour, CardClickObserver, CardPileClickObserver, DeckClickObserver {
  [SerializeField] private GameObject hardOverlay = null;
  [SerializeField] private GameObject softOverlay = null;
  private EventTrigger softOverlayClickEvent;

  [SerializeField] private GameOverLoseUI gameOverLosePanel = null;
  [SerializeField] private GameOverWinUI gameOverWinPanel = null;
  [SerializeField] private CardOverlay cardOverlayPanel = null;
  [SerializeField] private CardPileOverlay cardPileOverlayPanel = null;
  [SerializeField] private DeckOverlay deckOverlay = null;
  [SerializeField] private ShopOverlay shopOverlay = null;
  [SerializeField] private SelectNewCardOverlay selectNewCardOverlay = null;
  [SerializeField] private SelectCardOverlay selectCardOverlay = null;

  void Awake() {
    softOverlayClickEvent = softOverlay.GetComponent<EventTrigger>();
    Hide();
  }

  private void DisplayHardOverlay() {
    hardOverlay.SetActive(true);
  }

  private void DisplaySoftOverlay(bool exitable = true) {
    if (!exitable) softOverlayClickEvent.enabled = false;
    else softOverlayClickEvent.enabled = true;
    softOverlay.SetActive(true);
  }

  public void Hide() {
    hardOverlay.SetActive(false);
    softOverlay.SetActive(false);
    gameOverLosePanel.Hide();
    gameOverWinPanel.Hide();
    cardOverlayPanel.Hide();
    cardPileOverlayPanel.Hide();
    deckOverlay.Hide();
    shopOverlay.Hide();
    selectNewCardOverlay.Hide();
    selectCardOverlay.Hide();
  }

  public void DisplayGameOverLose() {
    Hide();
    DisplayHardOverlay();
    gameOverLosePanel.Display();
  }

  public void DisplayGameOverWin() {
    Hide();
    DisplayHardOverlay();
    gameOverWinPanel.Display();
  }

  public void UpdateClick(CardData card) { DisplayCardOverlay(card); }
  void DisplayCardOverlay(CardData card) {
    Hide();
    DisplaySoftOverlay();
    cardOverlayPanel.CardData = card;
    cardOverlayPanel.Display();
  }

  public void UpdateClick(CardPile pile) { DisplayCardPileOverlay(pile); }
  void DisplayCardPileOverlay(CardPile pile) {
    if (pile.Count > 0) {
      Hide();
      DisplaySoftOverlay();
      cardPileOverlayPanel.Pile = pile;
      cardPileOverlayPanel.Display();
    }
  }

  public void UpdateClick(Deck deck) { DisplayDeckOverlay(deck); }
  void DisplayDeckOverlay(Deck deck) {
    Hide();
    DisplaySoftOverlay();
    deckOverlay.Deck = deck;
    deckOverlay.Display();
  }

  public void DisplayShop() {
    Hide();
    DisplaySoftOverlay();
    shopOverlay.Display();
  }

  public void DisplaySelectNewCard() {
    Hide();
    DisplaySoftOverlay(false);
    selectNewCardOverlay.Display();
  }

  public void DisplaySelectCardsOverlay(int[] cardIndexes, SelectCardEffect effect, string title, Deck deck, bool optional = false) {
    Hide();
    DisplaySoftOverlay(optional);
    if (optional)
      selectCardOverlay.DisplayCancelButton();
    selectCardOverlay.Deck = deck;
    selectCardOverlay.Title = title;
    selectCardOverlay.Effect = effect;
    selectCardOverlay.CardIndexes = cardIndexes;
    selectCardOverlay.Display();
  }
}
