using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagementApp.Models;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AssetManagementApp.Controllers
{
    public class DnsRecordsController : Controller
    {
        private readonly DnsRecordDbContext _context;

        public DnsRecordsController(DnsRecordDbContext context)
        {
            _context = context;
        }

        // GET: DnsRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.DnsRecord.ToListAsync());
        }

        // GET: DnsRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecord = await _context.DnsRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnsRecord == null)
            {
                return NotFound();
            }

            return View(dnsRecord);
        }


        // GET: DnsRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnsRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Content")] DnsRecord dnsRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnsRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dnsRecord);
        }

        // GET: DnsRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecord = await _context.DnsRecord.FindAsync(id);
            if (dnsRecord == null)
            {
                return NotFound();
            }
            return View(dnsRecord);
        }

        // POST: DnsRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Content")] DnsRecord dnsRecord)
        {
            if (id != dnsRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnsRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnsRecordExists(dnsRecord.Id))
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
            return View(dnsRecord);
        }

        // GET: DnsRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecord = await _context.DnsRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnsRecord == null)
            {
                return NotFound();
            }

            return View(dnsRecord);
        }

        // POST: DnsRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dnsRecord = await _context.DnsRecord.FindAsync(id);
            _context.DnsRecord.Remove(dnsRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnsRecordExists(int id)
        {
            return _context.DnsRecord.Any(e => e.Id == id);
        }
    }
}
