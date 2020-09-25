public class CardConditionFactory {
  public static CardCondition nilCondition = new NilCondition(),

                              renownCondition_red1 = new RenownCondition(Factions.RED, 1),
                              renownCondition_red5 = new RenownCondition(Factions.RED, 5),
                              renownCondition_blue1 = new RenownCondition(Factions.BLUE, 1),
                              renownCondition_blue5 = new RenownCondition(Factions.BLUE, 5),
                              renownCondition_green1 = new RenownCondition(Factions.GREEN, 1),
                              renownCondition_green5 = new RenownCondition(Factions.GREEN, 5),
                              renownCondition_yellow1 = new RenownCondition(Factions.YELLOW, 1),
                              renownCondition_yellow5 = new RenownCondition(Factions.YELLOW, 5),

                              resourceCondition_power3 = new ResourceCondition(EResources.POWER, 3);
}
