using UnityEngine;
using UnityEngine.UI;

public class SelectNewCardButton : MonoBehaviour {
  [SerializeField] private Text buttonText = null;
  private Button btn;

  void Awake() {
    btn = GetComponent<Button>();
  }

  private GameManager manager;
  public GameManager Manager {
    set {
      manager = value;
      btn.onClick.AddListener(SelectCard);
    }
  }

  private CardData card;
  public CardData Card {
    get { return card; }
    set {
      card = value;
      SetUI();
    }
  }

  void SetUI() {
    buttonText.text = "Select " + TextHelper.Bold(card.Title);
    CheckForConditions();
  }

  public void CheckForConditions() {
    bool validateConditions = true;

    if (card.Conditions != null && card.Conditions.Length != 0)
      foreach (CardCondition condition in card.Conditions)
        if (!condition.Validate(manager))
          validateConditions = false;

    btn.interactable = validateConditions;
  }

  void SelectCard() {
    manager.library.AddCard(card.Clone(), manager.memoriesPile);
    manager.overlay.Hide();
  }
}
