using UnityEngine;

public class ScoresUI : MonoBehaviour {
  [SerializeField] private GameObject rowPrefab = null;
  [SerializeField] private Transform parent = null;

  public void DisplayScores(Score[] scores) {
    foreach (Transform child in parent)
      Destroy(child.gameObject);

    for (int i = 0; i < scores.Length; i++) {
      if (scores[i].power != -1) {
        GameObject scoreRow = Instantiate(rowPrefab);
        ScoreRow script = scoreRow.GetComponent<ScoreRow>();
        script.SetText(scores[i].power, scores[i].time);
        scoreRow.transform.position = new Vector3(0f, i * -30f, 0f);
        scoreRow.transform.SetParent(parent, false);
      }
    }
  }
}
