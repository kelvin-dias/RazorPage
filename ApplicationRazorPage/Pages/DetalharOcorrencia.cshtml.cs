using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;

namespace ApplicationRazorPage
{
    public class DetalharOcorrenciaModel : PageModel
    {
        private readonly Persistencia.Context.EFContext _context;

        public DetalharOcorrenciaModel(Persistencia.Context.EFContext context)
        {
            _context = context;
        }

        public Ocorrencia Ocorrencia { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ocorrencia = await _context.ocorrencias.FirstOrDefaultAsync(m => m.OcorrenciaId == id);

            if (Ocorrencia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
