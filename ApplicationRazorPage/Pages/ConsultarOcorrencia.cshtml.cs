using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelo.Entidades;
using Persistencia.Context;
using Servicos.Entidades;

namespace ApplicationRazorPage
{
    public class ConsultarOcorrenciaModel : PageModel
    {
        //private readonly EFContext _context;

        private OcorrenciaServico _ocorrenciaServico = new OcorrenciaServico();

        //public ConsultarOcorrenciaModel(EFContext context)
        //{
        //    _context = context;
        //}

        public IList<Ocorrencia> Ocorrencias { get; set; }

        [BindProperty]
        public Ocorrencia Ocorrencia { get; set; }

        public void OnGet()
        {
            Ocorrencias =  _ocorrenciaServico.ObterOcorrenciasClassificadasPorDataHora().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Ocorrencia.NumeroOcorrencia = _ocorrenciaServico.GerarNumeroOcorrencia();
            //_context.ocorrencias.Add(Ocorrencia);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./ConsultarOcorrencia");
        }


    }
}
