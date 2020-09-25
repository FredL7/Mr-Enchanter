using UnityEngine;

public class CardClickManager : MonoBehaviour {
  [SerializeField] private Overlay overlayObserver = null;
  private CardClickObserver[] observers;

  public static CardClickManager instance;

  private GameObject cardBeingClicked;
  public GameObject CardBeingClicked {
    get { return instance.cardBeingClicked; }
    set {
      instance.cardBeingClicked = value;
      UpdateObservers();
    }
  }

  void Awake() {
    instance = this;

    instance.observers = new CardClickObserver[] {
      overlayObserver
    };
  }

  void UpdateObservers() {
    CardUI script = cardBeingClicked.GetComponent<CardUI>();
    CardData data = script.Data;
    foreach (CardClickObserver o in instance.observers)
      o.UpdateClick(data);
  }
}
