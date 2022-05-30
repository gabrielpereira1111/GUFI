using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface IPresencaRepository
    {
        void Inscrever(Presenca presenca, int idUsuario);
        void AtualizarPresencao(int idPresenca, string situacao);
    }
}
