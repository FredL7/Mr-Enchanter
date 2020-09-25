using UnityEngine;

public static class TextHelper {
  public static string Bold(string text) {
    return "<b>" + text + "</b>";
  }
  public static string Bold(int n) { return Bold(n.ToString()); }

  public static string Color(string text, Color color) {
    return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + text + "</color>";
  }

  public static string Warning(string text) { return Color(text, ColorHelper.WarningColor); }
  public static string Highlight(string text) { return Color(text, ColorHelper.HighlightColor); }

  public static string Mana() { return Color("Mana", ColorHelper.ManaColor); }
  public static string Mana(int n) { return Bold(n.ToString() + " " + Mana()); }

  public static string Power() { return Color("Power", ColorHelper.PowerColor); }
  public static string Power(int n) { return Bold(n.ToString()) + " " + Power(); }

  public static string Gold() { return Color("Gold", ColorHelper.GoldColor); }
  public static string Gold(int n) { return Bold(n.ToString()) + " " + Gold(); }

  public static string Food() { return Color("Food", ColorHelper.FoodColor); }
  public static string Food(int n) { return Bold(n.ToString()) + " " + Food(); }

  public static string Apprentices(bool many) { return Color("Apprentice" + (many ? "s" : ""), ColorHelper.ApprenticesColor); }
  public static string Apprentices(int n) { return Bold(n.ToString()) + " " + Apprentices(n > 1); }
}
