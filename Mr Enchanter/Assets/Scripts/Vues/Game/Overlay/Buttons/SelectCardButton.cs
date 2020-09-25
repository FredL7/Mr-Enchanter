using UnityEngine;
using UnityEngine.UI;

public class SelectCardButton : MonoBehaviour {
  [SerializeField] private Text buttonText = null;
  private Button btn;

  void Awake() {
    btn = GetComponent<Button>();
  }

  private SelectCardEffect effect;
  public SelectCardEffect Effect {
    set {
      effect = value;
      btn.onClick.AddListener(SelectCard);
    }
  }

  private int cardIndex;
  public int CardIndex { set { cardIndex = value; } }

  public string CardTitle {
    set { buttonText.text = "Select " + TextHelper.Bold(value); }
  }

  void SelectCard() {
    effect.SelectCard(cardIndex);
  }
}
