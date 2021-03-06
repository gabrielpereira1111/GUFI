using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface IPresencaRepository
    {
        List<Presenca> ListarMinhas(int idUsuario);
        void Inscrever(Presenca presenca);
        void AtualizarPresencas(int idPresenca, string situacao);
    }
}
