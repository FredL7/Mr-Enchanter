using UnityEngine;
using System.IO;

public struct Score {
  public int power, time;

  public Score(int p, int t) {
    power = p; time = t;
  }
}

public class HighScoresManager : MonoBehaviour {
  [SerializeField] private ScoresUI vue = null;
  private int nbScoresToSave = 10;

  private Score[] scores;

  void Awake() {
    scores = new Score[nbScoresToSave];
    for (int i = 0; i < nbScoresToSave; i++)
      scores[i] = new Score(-1, -1);

    Load();
  }

  public void DisplayScores() {
    vue.DisplayScores(scores);
  }

  public void AddScore(int power, int time) {
    if (power != 0) {
      int index = nbScoresToSave - 1;

      while (
        index > 0 && (
          scores[index - 1].power == -1 ||
          scores[index - 1].power < power ||
          (scores[index - 1].power == power && scores[index - 1].time > time)
        )
      ) { index--; }

      if (index < nbScoresToSave) {
        for (int i = nbScoresToSave - 1; i > index; i--)
          scores[i] = scores[i - 1];
        scores[index] = new Score(power, time);
        Save();
      }
    }
  }

  void Save() {
    string path = Path.Combine(Application.persistentDataPath, "high.scores");
    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create))) {
      writer.Write(0); // Header version
      foreach (Score score in scores) {
        writer.Write(score.power);
        writer.Write(score.time);
      }
    }
  }

  void Load() {
    string path = Path.Combine(Application.persistentDataPath, "high.scores");
    if (File.Exists(path)) {
      using (BinaryReader reader = new BinaryReader(File.OpenRead(path))) {
        int header = reader.ReadInt32();
        if (header == 0) {
          for (int i = 0; i < nbScoresToSave; i++) {
            int power = reader.ReadInt32();
            int time = reader.ReadInt32();
            scores[i] = new Score(power, time);
          }
          System.Array.Sort(scores, (x, y) => x.power == y.power ? x.time.CompareTo(y.time) : -x.power.CompareTo(y.power));
        } else {
          Debug.LogWarning("Unknown save format " + header);
        }
      }
    }
  }

}
