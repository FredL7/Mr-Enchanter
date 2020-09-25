using UnityEngine;

public class WeeksManager : MonoBehaviour {
  [SerializeField] private WeeksUI vue = null;
  [SerializeField] private RentManager rentObserver = null;
  private WeeksObserver[] observers;

  private int weeks;
  public int Weeks { get { return weeks; } }

  public static int WEEK_IN_YEAR = 52;

  void Awake() {
    weeks = 1;
    observers = new WeeksObserver[] {
      vue, rentObserver
    };
  }

  void Start() {
    NotifyObservers();
  }

  public void Reset() {
    weeks = 1;
    NotifyObservers();
  }

  public void NotifyObservers() {
    foreach (WeeksObserver o in observers)
      o.UpdateWeeks(this);
  }

  public void NextTurn() {
    weeks++;
    NotifyObservers();
  }
}
