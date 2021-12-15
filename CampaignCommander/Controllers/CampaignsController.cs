using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampaignCommander.Data;
using CampaignCommander.Data.ViewModels;

namespace CampaignCommander.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampaignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Campaigns.Include(c => c.Game).Include(c => c.GameMaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .Include(c => c.Game)
                .Include(c => c.GameMaster)
                .FirstOrDefaultAsync(m => m.CampaignID == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameID", "GameID");
            ViewData["GameMasterId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampaignID,CampaignName,CampaignDescription,GameMasterId,GameId,Invitations")] CampaignViewModel campaign)
        {
            if (ModelState.IsValid)
            {
                Campaign newCampaign = new Campaign();

                newCampaign.CampaignName = campaign.CampaignName;
                newCampaign.CampaignDescription = campaign.CampaignDescription;
                newCampaign.GameMasterId = campaign.GameMasterId;
                newCampaign.GameId = campaign.GameId;

                _context.Add(newCampaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameID", "GameID", campaign.GameId);
            ViewData["GameMasterId"] = new SelectList(_context.Users, "Id", "Id", campaign.GameMasterId);
            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameID", "GameID", campaign.GameId);
            ViewData["GameMasterId"] = new SelectList(_context.Users, "Id", "Id", campaign.GameMasterId);
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampaignID,CampaignName,CampaignDescription,GameMasterId,GameId")] Campaign campaign)
        {
            if (id != campaign.CampaignID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.CampaignID))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameID", "GameID", campaign.GameId);
            ViewData["GameMasterId"] = new SelectList(_context.Users, "Id", "Id", campaign.GameMasterId);
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .Include(c => c.Game)
                .Include(c => c.GameMaster)
                .FirstOrDefaultAsync(m => m.CampaignID == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(e => e.CampaignID == id);
        }
    }
}
