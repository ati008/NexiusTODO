namespace TODOAPI.Model
{
  public class Szures
  {
    public bool? Statusz { get; set; }
    public string? Leiras { get; set; }
    public int OldalSzam { get; set; }
    public int OldalMeret { get; set; }
    public Szures()
    {
      this.OldalSzam = 1;
      this.OldalMeret = 25;
    }
    public Szures(int oldalSzam, int oldalMeret)
    {
      this.OldalSzam = oldalSzam < 1 ? 1 : oldalSzam;
      this.OldalMeret = oldalMeret > 25 ? 25 : oldalMeret;
    }
  }
}
