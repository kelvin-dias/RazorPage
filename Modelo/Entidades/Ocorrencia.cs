using Modelo.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Entidades
{
    [Table("OCORRENCIAS")]
    public class Ocorrencia
    {
        [DisplayName("ID")]
        public long? OcorrenciaId { get; set; }

        [DisplayName("Número")]
        public long? NumeroOcorrencia { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "Informe o Título da Ocorrência")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a Descrição da Ocorrência")]
        public string Descricao { get; set; }

        [DisplayName("Data e Hora")]
        public DateTime DataHoraAbertura { get; set; }

        [DisplayName("Data e Hora Ocorrência")]
        [Required(ErrorMessage = "Informe a Data e Hora da Ocorrência")]
        public DateTime DataHoraOcorrencia { get; set; }

        [DisplayName("Status")]
        public bool StatusOcorrencia { get; set; }

        [DisplayName("Criticidade")]
        [Required(ErrorMessage = "Informe a Criticidade da Ocorrência")]
        public Criticidade CriticidadeOcorrencia { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe a Categoria da Ocorrência")]
        public Categoria CategoriaOcorrencia { get; set; }

        [DisplayName("Solução")]
        public string Solucao { get; set; }

        public ICollection<IteracaoOcorrencia> Iteracoes { get; set; }
    }
}
