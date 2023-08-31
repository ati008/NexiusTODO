namespace TODOAPI.Model
{
  public class LapozottValasz<T> : Valasz<T>
  {
    public int OldalSzama { get; set; }
    public int OldalMerete { get; set; }
    public Uri ElsoOldal { get; set; }
    public Uri UtaolsoOldal { get; set; }
    public int OsszesOldal { get; set; }
    public int OsszesElem { get; set; }
    public Uri KovetlezoOldal { get; set; }
    public Uri ElozoOldal { get; set; }
    public LapozottValasz(T adat, int oldalSzam, int oldalMeret)
    {
      this.OldalSzama = oldalSzam;
      this.OldalMerete = oldalMeret;
      this.Adat = adat;
      this.Uzenet = null;
      this.Sikeres = true;
      this.Hibak = null;
    }
  }
}
