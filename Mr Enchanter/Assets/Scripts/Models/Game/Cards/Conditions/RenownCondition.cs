public class RenownCondition : CardCondition {
  private int value;
  private Factions faction;

  public RenownCondition(Factions faction, int n) {
    this.faction = faction;
    value = n;
  }

  public bool Validate(GameManager mngr) {
    return mngr.factions.GetRenown(faction) >= value;
  }
}
