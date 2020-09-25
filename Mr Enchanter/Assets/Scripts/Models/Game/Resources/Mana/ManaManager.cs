using UnityEngine;

public class ManaManager : MonoBehaviour {
  [SerializeField] private ManaUI observer = null;
  private ManaObserver manaObserver;

  public int manaPerTurn = 3;

  private int mana;
  public int Mana { get { return mana; } }

  public void RemoveMana(int n) {
    mana -= n;
    NotifyObservers();
  }

  public void AddMana(int n) {
    mana += n;
    NotifyObservers();
  }

  public void NextTurn() {
    mana = manaPerTurn;
    NotifyObservers();
  }

  void Awake() {
    manaObserver = observer;
    mana = manaPerTurn;
  }

  public void Reset() {
    mana = manaPerTurn;
    NotifyObservers();
  }

  void Start() {
    NotifyObservers();
  }

  void NotifyObservers() {
    manaObserver.UpdateMana(mana);
  }
}
