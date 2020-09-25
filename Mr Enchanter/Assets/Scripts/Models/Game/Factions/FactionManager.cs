using UnityEngine;

public abstract class FactionManager : MonoBehaviour {
  [SerializeField] private FactionUI vue = null;
  [SerializeField] private SelectNewCardButtons selectNewCardButtonsObserver = null;
  private FactionObserver[] observers;

  [SerializeField] private int startRenown = 0;

  public abstract string Name { get; }

  private int renown;
  public int Renown { get { return renown; } }
  public void AddRenown(int n) {
    renown += n;
    NotifyObservers();
  }

  void Awake() {
    renown = startRenown;
    observers = new FactionObserver[] {
      vue, selectNewCardButtonsObserver
    };
  }


  public void Reset() {
    renown = startRenown;
    NotifyObservers();
  }

  void Start() {
    NotifyObservers();
  }

  void NotifyObservers() {
    foreach (FactionObserver o in observers)
      o.UpdateFaction(this);
  }
}
