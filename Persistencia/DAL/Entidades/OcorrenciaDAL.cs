using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DAL.Entidades
{
    public class OcorrenciaDAL
    {
        private EFContext _context = new EFContext();

        public IQueryable<Ocorrencia> ObterOcorrenciasClassificadasPorDataHora()
        {
            return _context.ocorrencias.OrderBy(b => b.DataHoraAbertura);
        }

        public Ocorrencia ObterOcorrenciaPorId(long? id)
        {
            return _context.ocorrencias.Where(p => p.OcorrenciaId == id).First();
        }

        public void GravarOcorrencia(Ocorrencia ocorrencia)
        {
            _context.ocorrencias.Add(ocorrencia);
            _context.SaveChanges();
        }

        public Ocorrencia ObterOcorrenciaPorNumero(long numeroOcorrencia)
        {
            return _context.ocorrencias.FirstOrDefault(x => x.NumeroOcorrencia == numeroOcorrencia);
        }

        public int ObterQuantidadeOcorrenciaStatusAberto()
        {
            var query = _context.ocorrencias.Where(p => p.StatusOcorrencia == true);

            int contagem = query.Count();

            return contagem;
        }
    }
}
