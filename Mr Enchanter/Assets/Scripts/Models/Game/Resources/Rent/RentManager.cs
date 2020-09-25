using UnityEngine;

public class RentManager : Deck, WeeksObserver {
  [SerializeField] private RentUI vue = null;

  public int RentCard { get { return 0; } }
  public int OverdueRentCard { get { return 1; } }

  public bool RentDue { get; private set; }
  public bool RentOverdue { get; private set; }

  void Start() {
    AddCard(CardRentFactory.Rent);
    AddCard(CardRentFactory.OverdueRent);
  }

  new public void AddCard(CardData card) {
    cardList.Add(card);
  }

  public void UpdateWeeks(WeeksManager weeks) {
    if (!RentDue) {
      switch (weeks.Weeks % 4) {
        case 0: SetRentDue(); break;
        case 1: vue.SetText(3); break;
        case 2: vue.SetText(2); break;
        case 3: vue.SetText(1); break;
      }
    } else {
      SetRentOverdue();
    }
  }

  new public void Reset() {
    vue.Clear();
    RentDue = false;
    RentOverdue = false;
  }

  public void RemoveCard() {
    vue.Clear();
    if (RentDue)
      RentDue = false;
    if (RentOverdue)
      RentOverdue = false;
  }

  void SetRentDue() {
    RentDue = true;
    RentOverdue = false;
    vue.AddRentCard(cardList[RentCard]);
  }

  void SetRentOverdue() {
    RentDue = false;
    RentOverdue = true;
    vue.AddOverdueRentCard(cardList[OverdueRentCard]);
  }

}
