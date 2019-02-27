using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using HJR.FinanceControl.WebApp.Data;
using HJR.FinanceControl.WebApp.Models;
using HJR.FinanceControl.WebApp.ViewModels;

namespace HJR.FinanceControl.WebApp.Controllers
{
    public class ContaAPagarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper              _mapper;

        public ContaAPagarController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        // GET: ContaAPagar
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ContaAPagarViewModel>>(await _context.ContasAPagar.ToListAsync()));
        }

        // GET: ContaAPagar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAPagarViewModel = _mapper.Map<ContaAPagarViewModel>(await _context.ContasAPagar.FirstOrDefaultAsync(m => m.Id == id));

            if (contaAPagarViewModel == null)
                return NotFound();

            return View(contaAPagarViewModel);
        }

        // GET: ContaAPagar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaAPagar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fornecedor,Id,Documento,DescricaoDocumento,DataVencimento,ValorTotal,Situacao")] ContaAPagarViewModel contaAPagarViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<ContaAPagar>(contaAPagarViewModel));

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(contaAPagarViewModel);
        }

        // GET: ContaAPagar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAPagarViewModel = _mapper.Map<ContaAPagarViewModel>(await _context.ContasAPagar.FindAsync(id));

            if (contaAPagarViewModel == null)
                return NotFound();

            return View(contaAPagarViewModel);
        }

        // POST: ContaAPagar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fornecedor,Id,Documento,DescricaoDocumento,DataVencimento,ValorTotal,Situacao")] ContaAPagarViewModel contaAPagarViewModel)
        {
            if (id != contaAPagarViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<ContaAPagar>(contaAPagarViewModel));

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaAPagarExists(contaAPagarViewModel.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contaAPagarViewModel);
        }

        // GET: ContaAPagar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAPagarViewModel = _mapper.Map<ContaAPagarViewModel>(await _context.ContasAPagar.FirstOrDefaultAsync(m => m.Id == id));

            if (contaAPagarViewModel == null)
                return NotFound();

            return View(contaAPagarViewModel);
        }

        // POST: ContaAPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaAPagar = await _context.ContasAPagar.FindAsync(id);

            _context.ContasAPagar.Remove(contaAPagar);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ContaAPagarExists(int id)
        {
            return _context.ContasAPagar.Any(e => e.Id == id);
        }
    }
}