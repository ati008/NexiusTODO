using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TODOAPI.Adatbazis.Kontextus;
using TODOAPI.Adatbazis.Model;
using TODOAPI.Model;

namespace TODOAPI.Service
{
  public class TODOService : ITODOService
  {
    private TODOKontextus Kontextus { get; set; }

    public TODOService(ITODOKontextus kontextus)
    {
      if (kontextus is TODOKontextus todoKontextus)
        Kontextus = todoKontextus;
      else
        throw new ArgumentException("Nem megfelelő kontextus");
      Kontextus.Database.EnsureCreated();
    }

    public async Task Delete(Guid id)
    {
      Kontextus.Remove(IDAlapuLekerdezes(id));
      await Kontextus.SaveChangesAsync();
    }

    public async Task<TODO> Get(Guid id)
    {
      return IDAlapuLekerdezes(id);
    }

    public async Task<IEnumerable<TODO>> GetAll(Szures szures)
    {
      return Kontextus.TODOS
        .Where(t => (!szures.Statusz.HasValue || t.Statusz == szures.Statusz) && (string.IsNullOrWhiteSpace(szures.Leiras) || t.Leiras == szures.Leiras))
        .Skip((szures.OldalSzam - 1) * szures.OldalMeret)
        .Take(szures.OldalMeret);
    }

    public async Task Add(TODO todo)
    {
      Kontextus.TODOS.Add(todo);
      await Kontextus.SaveChangesAsync();
    }

    public async Task UpdateLeiras(Guid id, string leiras)
    {
      IDAlapuLekerdezes(id).Leiras = leiras;
      await Kontextus.SaveChangesAsync();
    }

    public async Task UpdateStatusz(Guid id, bool statusz)
    {
      IDAlapuLekerdezes(id).Statusz = statusz;
      await Kontextus.SaveChangesAsync();
    }


    private TODO IDAlapuLekerdezes(Guid id)
    {
      TODO todo = Kontextus.TODOS.FirstOrDefault(t => t.id == id);
      if (todo == null)
      {
        throw new ArgumentException("Nem található elem ilyen azonosítóval");
      }
      return todo;
    }
  }
}
