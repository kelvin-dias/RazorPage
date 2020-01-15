using Persistencia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.Entidades
{
    public class OcorrenciaServico
    {
        private readonly OcorrenciaDAL ocorrenciaDAL = new OcorrenciaDAL();


        public long GerarNumeroOcorrencia()
        {
            /*GERANDO NÚMERO DE OCORRENCIA E VALIDANDO NO BANCO DE DADOS */
            long numeroOcorrencia = 0;
            Random randNum = new Random();
            bool statusValidacao = false;
            do
            {
                long numero = randNum.Next(100000, 999999);
                if (ocorrenciaDAL.ObterOcorrenciaPorNumero(numero) == null)

                {
                    numeroOcorrencia = numero;
                    statusValidacao = true;
                }

            } while (statusValidacao == false);

            return numeroOcorrencia;
        }
    }
}
