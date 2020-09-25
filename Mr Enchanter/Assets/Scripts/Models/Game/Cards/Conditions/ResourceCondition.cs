public class ResourceCondition : CardCondition {
  private int value;
  private EResources resource;

  public ResourceCondition(EResources resource, int n) {
    this.resource = resource;
    value = n;
  }

  public bool Validate(GameManager mngr) {
    return mngr.resources.GetValue(resource) >= value;
  }
}
