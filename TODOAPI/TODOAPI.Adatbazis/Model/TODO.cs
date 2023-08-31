namespace TODOAPI.Adatbazis.Model
{
  public class TODO
  {

    public TODO(string leiras, bool statusz)
    {
      id = Guid.NewGuid();
      Leiras = leiras;
      Statusz = statusz;
    }

    public Guid id { get; set; }
    public string partitionKey { get; set; } = "TODO";
    public string Leiras { get; set; }
    public bool Statusz { get; set; }
  }
}
