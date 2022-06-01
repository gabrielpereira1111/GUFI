using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;

namespace gufi_webApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Create(Instituicao instituicao)
        {
            ctx.Instituicaos.Add(instituicao);
            ctx.SaveChanges();
        }
    }
}
