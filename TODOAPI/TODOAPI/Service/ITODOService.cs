using TODOAPI.Adatbazis.Model;
using TODOAPI.Model;

namespace TODOAPI.Service
{
  public interface ITODOService
  {
    Task<IEnumerable<TODO>> GetAll(Szures szures);
    Task<TODO> Get(Guid id);
    Task Add(TODO todo);
    Task UpdateLeiras(Guid id, string leiras);
    Task UpdateStatusz(Guid id, bool statusz);
    Task Delete(Guid id);
  }
}
