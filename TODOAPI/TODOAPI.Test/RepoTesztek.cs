using TODOAPI.Adatbazis.Kontextus;
using TODOAPI.Adatbazis.Model;
using TODOAPI.Model;
using TODOAPI.Service;

namespace TODOAPI.Test
{
  public class RepoTesztek
  {
    [Fact]
    public async void HozzaadasMukodik()
    {
      var repo = new TODOService(new TODOKontextus(true));
      await repo.Add(new TODO("Hozzadas teszt", false));
      var lista = await repo.GetAll(new Szures() { Leiras = "Hozzadas teszt" });
      Assert.NotEmpty(lista);
    }

    [Fact]
    public async void LeirasModositas()
    {
      var repo = new TODOService(new TODOKontextus(true));
      var todo = new TODO("M�dos�tand� le�r�s", false);
      await repo.Add(todo);
      await repo.UpdateLeiras(todo.id, "M�dos�tott le�r�s");
      var lekerdezett = await repo.Get(todo.id);
      Assert.Equal("M�dos�tott le�r�s", lekerdezett.Leiras);
    }

    [Fact]
    public async void GetAllSzures()
    {
      var repo = new TODOService(new TODOKontextus(true));
      await repo.Add(new TODO("teszt le�r�s", false));
      await repo.Add(new TODO("teszt le�r�s2", false));
      await repo.Add(new TODO("teszt le�r�s3", false));
      await repo.Add(new TODO("teszt le�r�s4", true));
      await repo.Add(new TODO("teszt le�r�s5", false));
      await repo.Add(new TODO("teszt le�r�s6", false));
      var lista = await repo.GetAll(new Szures() { Statusz = true });
      Assert.Single(lista);
    }


    [Fact]
    public async void Delete()
    {
      var repo = new TODOService(new TODOKontextus(true));
      var torlendo = new TODO("Torles le�r�s", false);
      await repo.Add(torlendo);
      await repo.Delete(torlendo.id);
      var lista = await repo.GetAll(new Szures() { Statusz = true });
      Assert.DoesNotContain(torlendo,lista);
    }


    [Fact]
    public async void InvalidDelete()
    {
      var repo = new TODOService(new TODOKontextus(true));
      var torlendo = new TODO("Torles le�r�s", false);
      await repo.Add(torlendo);
      await Assert.ThrowsAsync<ArgumentException>(async () => await repo.Delete(Guid.NewGuid()));
    }

  }
}