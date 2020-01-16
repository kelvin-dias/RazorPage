using Modelo.Entidades;
using Persistencia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.Entidades
{
    public class OcorrenciaServico
    {
        private OcorrenciaDAL _ocorrenciaDAL = new OcorrenciaDAL();
        public OcorrenciaServico() { }
        public OcorrenciaServico(OcorrenciaDAL ocorrenciaDAL)
        {
            _ocorrenciaDAL = ocorrenciaDAL;
        }

        public IList<Ocorrencia> Ocorrencias { get; set; }

        public IQueryable<Ocorrencia> ObterOcorrenciasClassificadasPorDataHora()
        {
            return _ocorrenciaDAL.ObterOcorrenciasClassificadasPorDataHora();
        }

        public long GerarNumeroOcorrencia()
        {
            /*GERANDO NÚMERO DE OCORRENCIA E VALIDANDO NO BANCO DE DADOS */
            long numeroOcorrencia = 0;
            Random randNum = new Random();
            bool statusValidacao = false;
            do
            {
                long numero = randNum.Next(100000, 999999);
                if (_ocorrenciaDAL.ObterOcorrenciaPorNumero(numero) == null)

                {
                    numeroOcorrencia = numero;
                    statusValidacao = true;
                }

            } while (statusValidacao == false);

            return numeroOcorrencia;
        }
    }
}
