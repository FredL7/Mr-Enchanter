using UnityEngine;
using UnityEngine.UI;

public class KeywordUI : MonoBehaviour {
  [SerializeField] private Text title = null;
  [SerializeField] private Text description = null;

  public void SetText(CardKeyword keyword) {
    title.text = keyword.Title();
    description.text = keyword.Description();
  }
}
