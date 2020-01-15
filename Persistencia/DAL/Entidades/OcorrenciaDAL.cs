using Modelo.Entidades;
using Persistencia.Context;
using System.Linq;

namespace Persistencia.DAL.Entidades
{
    public class OcorrenciaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Ocorrencia> ObterOcorrenciasClassificadasPorDataHora()
        {
            return context.ocorrencias.OrderBy(b => b.DataHoraAbertura);
        }

        public Ocorrencia ObterOcorrenciaPorId(long? id)
        {
            return context.ocorrencias.Where(p => p.OcorrenciaId == id).First();
        }

        public void GravarOcorrencia(Ocorrencia ocorrencia)
        {
            context.ocorrencias.Add(ocorrencia);
            context.SaveChanges();
        }

        public Ocorrencia ObterOcorrenciaPorNumero(long numeroOcorrencia)
        {
            return context.ocorrencias.FirstOrDefault(x => x.NumeroOcorrencia == numeroOcorrencia);
        }

        public int ObterQuantidadeOcorrenciaStatusAberto()
        {
            var query = context.ocorrencias.Where(p => p.StatusOcorrencia == true);

            int contagem = query.Count();

            return contagem;
        }
    }
}
