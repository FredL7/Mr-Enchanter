using UnityEngine;

public class Power : ResourceManager {
  override public Color Color { get { return ColorHelper.PowerColor; } }
  override public string Name { get { return "Power"; } }
}
