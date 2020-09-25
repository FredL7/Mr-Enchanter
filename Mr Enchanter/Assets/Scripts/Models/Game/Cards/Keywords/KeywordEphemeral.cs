public class KeywordEphemeral : CardKeyword {
  public string Title() { return "Ephemeral"; }
  public string Description() { return "This card is sent to " + TextHelper.Highlight("Oblivion") + " after it is played."; }
}