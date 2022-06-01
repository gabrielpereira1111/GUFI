using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface IEventoRepository
    {
        void Create(Evento evento);
        List<Evento> ReadAll();
        Evento GetById(int id);
        void Delete(int id);
    }
}
