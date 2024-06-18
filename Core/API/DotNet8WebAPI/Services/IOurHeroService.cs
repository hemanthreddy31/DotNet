using DotNet8WebAPI.Model;
namespace DotNet8WebAPI.Services
{
    public interface IOurHeroService
    {
        List<OurHero> GetAllHeros(bool? isActive);
        OurHero? GetHeroById(int id);
        OurHero? AddOurHero(AddUpdateOurHero obj);
        OurHero? UpdateOurHero(int id, AddUpdateOurHero obj);
        bool DeleteHerosById(int id);

    }
}
