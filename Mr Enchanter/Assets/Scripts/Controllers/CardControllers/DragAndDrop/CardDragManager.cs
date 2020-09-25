using UnityEngine;

public class CardDragManager : MonoBehaviour {
  [SerializeField] private ManaUI manaUIObserver = null;
  [SerializeField] private ResourceUI powerUIObserver = null;
  [SerializeField] private ResourceUI goldUIObserver = null;
  [SerializeField] private ResourceUI foodUIObserver = null;
  [SerializeField] private ResourceUI apprenticesUIObserver = null;
  [SerializeField] private FactionUI redFactionUIObserver = null;
  [SerializeField] private FactionUI blueFactionUIObserver = null;
  [SerializeField] private FactionUI greenFactionUIObserver = null;
  [SerializeField] private FactionUI yellowFactionUIObserver = null;
  private CardDragObserver[] observers;

  public static CardDragManager instance;

  private GameObject cardBeingDragged;
  public GameObject CardBeingDragged {
    get { return instance.cardBeingDragged; }
    set {
      instance.cardBeingDragged = value;
      UpdateObservers();
    }
  }

  void Awake() {
    instance = this;

    instance.observers = new CardDragObserver[] {
      manaUIObserver, powerUIObserver, goldUIObserver, foodUIObserver, apprenticesUIObserver,
      redFactionUIObserver, blueFactionUIObserver, greenFactionUIObserver, yellowFactionUIObserver
    };

    UpdateObservers();
  }

  private void UpdateObservers() {
    if (cardBeingDragged == null) {
      foreach (CardDragObserver o in instance.observers)
        o.UpdateDrag(null);
    } else {
      CardUI script = cardBeingDragged.GetComponent<CardUI>();
      CardData data = script.Data;
      foreach (CardDragObserver o in instance.observers)
        o.UpdateDrag(data);
    }
  }
}
