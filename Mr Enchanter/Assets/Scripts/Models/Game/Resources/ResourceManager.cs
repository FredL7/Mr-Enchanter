using UnityEngine;

public abstract class ResourceManager : MonoBehaviour {
  [SerializeField] private ResourceUI vue = null;
  [SerializeField] private SelectNewCardButtons selectNewCardButtonsObserver = null;
  private ResourceObserver[] observers;

  [SerializeField] private int startValue = 0;

  public abstract Color Color { get; }
  public abstract string Name { get; }

  private int value;
  public int Value { get { return value; } }
  public void AddResource(int n) {
    value += n;
    NotifyObservers();
  }

  void Awake() {
    value = startValue;
    observers = new ResourceObserver[] {
      vue, selectNewCardButtonsObserver
    };
  }

  public void Reset() {
    value = startValue;
    NotifyObservers();
  }

  void Start() {
    NotifyObservers();
  }

  void NotifyObservers() {
    foreach (ResourceObserver o in observers)
      o.UpdateResource(this);
  }
}
