using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo.Entidades;
using Persistencia.Context;
using Persistencia.DAL.Entidades;

namespace ApplicationRazorPage
{
    public class AdicionarOcorrenciaModel : PageModel
    {
        private readonly OcorrenciaDAL ocorrenciaDAL = new OcorrenciaDAL();
        private readonly EFContext _context;

        public AdicionarOcorrenciaModel(EFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ocorrencia Ocorrencia { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ocorrencia.NumeroOcorrencia = GerarNumeroOcorrencia();
            _context.ocorrencias.Add(Ocorrencia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
