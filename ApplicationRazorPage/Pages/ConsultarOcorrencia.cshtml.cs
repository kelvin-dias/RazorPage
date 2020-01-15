using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;
using Servicos.Entidades;

namespace ApplicationRazorPage
{
    public class ConsultarOcorrenciaModel : PageModel
    {
        private readonly EFContext _context;

        private readonly OcorrenciaServico _ocorrenciaServico = new OcorrenciaServico();

        public ConsultarOcorrenciaModel(EFContext context)
        {
            _context = context;
        }

        public ConsultarOcorrenciaModel(OcorrenciaServico ocorrenciaServico)
        {
            _ocorrenciaServico = ocorrenciaServico;
        }

        public IList<Ocorrencia> Ocorrencias { get;set; }

        [BindProperty]
        public Ocorrencia Ocorrencia { get; set; }

        public async Task OnGetAsync()
        {
            Ocorrencias = await _context.ocorrencias.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ocorrencia.NumeroOcorrencia = _ocorrenciaServico.GerarNumeroOcorrencia();
            _context.ocorrencias.Add(Ocorrencia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        
    }
}
