namespace TODOAPI.Model
{
  public class Valasz<T>
  {
    public Valasz()
    {
    }
    public Valasz(T adat)
    {
      Sikeres = true;
      Uzenet = string.Empty;
      Hibak = null;
      Adat = adat;
    }
    public Valasz(T adat, string uzenet = "", string[] hibak = null)
    {
      Sikeres = hibak == null;
      Uzenet = uzenet;
      Hibak = hibak;
      Adat = adat;
    }
    public T Adat { get; set; }
    public bool Sikeres { get; set; }
    public string[] Hibak { get; set; }
    public string Uzenet { get; set; }
  }
}
