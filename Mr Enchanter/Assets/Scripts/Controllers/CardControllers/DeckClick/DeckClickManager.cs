using UnityEngine;

public class DeckClickManager : MonoBehaviour {
  [SerializeField] private Overlay overlayObserver = null;
  private DeckClickObserver[] observers;

  public static DeckClickManager instance;

  private Deck deckClicked;
  public Deck DeckClicked {
    get { return instance.deckClicked; }
    set {
      instance.deckClicked = value;
      UpdateObservers();
    }
  }

  void Awake() {
    instance = this;

    instance.observers = new DeckClickObserver[] {
      overlayObserver
    };
  }

  void UpdateObservers() {
    foreach (DeckClickObserver o in instance.observers)
      o.UpdateClick(deckClicked);
  }
}
