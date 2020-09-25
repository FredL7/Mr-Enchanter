using UnityEngine;

public class CardPileClickManager : MonoBehaviour {
  [SerializeField] private Overlay overlayObserver = null;
  private CardPileClickObserver[] observers;

  public static CardPileClickManager instance;

  private GameObject pileClicked;
  public GameObject PileClicked {
    get { return instance.pileClicked; }
    set {
      instance.pileClicked = value;
      UpdateObservers();
    }
  }

  void Awake() {
    instance = this;

    instance.observers = new CardPileClickObserver[] {
      overlayObserver
    };
  }

  void UpdateObservers() {
    CardPile pile = pileClicked.GetComponent<CardPile>();
    foreach (CardPileClickObserver o in instance.observers)
      o.UpdateClick(pile);
  }
}
