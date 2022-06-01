using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Create(TipoEvento tipoEvento);
        List<TipoEvento> ReadAll();
        TipoEvento GetById(int id);
        void Update(TipoEvento tipoEvento, int id);
        void Delete(int id);
        void Delete(string nomeTipoEvento);
    }
}
