using UnityEngine;

public class Gold : ResourceManager {
  override public Color Color { get { return ColorHelper.GoldColor; } }
  override public string Name { get { return "Gold"; } }
}
