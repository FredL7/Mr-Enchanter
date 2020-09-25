using UnityEngine;

public class Apprentices : ResourceManager {
  override public Color Color { get { return ColorHelper.ApprenticesColor; } }
  override public string Name { get { return "Apprentices"; } }
}
