using UnityEngine;

public class Food : ResourceManager {
  override public Color Color { get { return ColorHelper.FoodColor; } }
  override public string Name { get { return "Food"; } }
}
