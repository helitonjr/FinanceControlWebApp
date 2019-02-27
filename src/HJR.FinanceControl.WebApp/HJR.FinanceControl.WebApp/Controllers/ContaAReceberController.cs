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
    public class ContaAReceberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContaAReceberController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        // GET: ContaAReceber
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ContaAReceberViewModel>>(await _context.ContasAReceber.ToListAsync()));
        }

        // GET: ContaAReceber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAReceberViewModel = _mapper.Map<ContaAReceberViewModel>(await _context.ContasAReceber.FirstOrDefaultAsync(m => m.Id == id));

            if (contaAReceberViewModel == null)
                return NotFound();

            return View(contaAReceberViewModel);
        }

        // GET: ContaAReceber/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaAReceber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,Id,Documento,DescricaoDocumento,DataVencimento,ValorTotal,Situacao")] ContaAReceberViewModel contaAReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<ContaAReceber>(contaAReceberViewModel));

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(contaAReceberViewModel);
        }

        // GET: ContaAReceber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAReceberViewModel = _mapper.Map<ContaAReceberViewModel>(await _context.ContasAReceber.FindAsync(id));

            if (contaAReceberViewModel == null)
                return NotFound();

            return View(contaAReceberViewModel);
        }

        // POST: ContaAReceber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cliente,Id,Documento,DescricaoDocumento,DataVencimento,ValorTotal,Situacao")] ContaAReceberViewModel contaAReceberViewModel)
        {
            if (id != contaAReceberViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<ContaAReceber>(contaAReceberViewModel));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaAReceberExists(contaAReceberViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contaAReceberViewModel);
        }

        // GET: ContaAReceber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var contaAReceberViewModel = _mapper.Map<ContaAReceberViewModel>(await _context.ContasAReceber.FirstOrDefaultAsync(m => m.Id == id));

            if (contaAReceberViewModel == null)
                return NotFound();

            return View(contaAReceberViewModel);
        }

        // POST: ContaAReceber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaAReceber = await _context.ContasAReceber.FindAsync(id);

            _context.ContasAReceber.Remove(contaAReceber);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ContaAReceberExists(int id)
        {
            return _context.ContasAReceber.Any(e => e.Id == id);
        }
    }
}