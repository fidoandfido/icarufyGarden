using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IcarufyGarden.Data;
using IcarufyGarden.ViewModels;
using Microsoft.AspNetCore.Identity;
using IcarufyGarden.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IcarufyGarden.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/GardenBeds")]
    public class GardenBedViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public GardenBedViewModelsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/GardenBeds
        [HttpGet]
        public IEnumerable<GardenBedViewModel> GetGardenBeds()
        {
            // Get the current user, then find all garden beds that have that user in their 'owners' list.
            // This is mapped by the GardenBedOwners table
            // Finally make sure when we retrieve the model, we populate all the fields.
            string userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = _context.appUsers.SingleOrDefault(u => u.UserName == userName);
            var gardenBeds = _context.GardenBeds.Include(gardenBed => gardenBed.Owners)
                                    .ThenInclude(gardenBedOwner => gardenBedOwner.Owner)
                                    .Where( gardenBed => gardenBed.Owners.Any(gardenBedOwner => gardenBedOwner.Owner == currentUser));

            // For each garden bed entity, make the view model - to be returned to the application
            foreach (var gardenBed in gardenBeds)
            {
                GardenBedViewModel viewModel = new GardenBedViewModel();
                viewModel.Id = gardenBed.Id;
                viewModel.Description = gardenBed.Description;
                List<GardenBedOwnerViewModel> ownerModelList = new List<GardenBedOwnerViewModel>();
                foreach (var owner in gardenBed.Owners)
                {
                    var ownerModel = new GardenBedOwnerViewModel();
                    ownerModel.firstName = owner.Owner.FirstName;
                    ownerModel.secondName= owner.Owner.LastName;
                    ownerModel.Id = owner.Owner.Id;
                    ownerModel.userName = owner.Owner.UserName;
                    ownerModelList.Add(ownerModel);
                }

                viewModel.Owners = ownerModelList;
                yield return viewModel;
            }
        }

        //// GET: GardenBenViewModels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: GardenBenViewModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Description")] GardenBedViewModel gardenBenViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(gardenBenViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel.SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// POST: GardenBenViewModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] GardenBedViewModel gardenBenViewModel)
        //{
        //    if (id != gardenBenViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(gardenBenViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GardenBenViewModelExists(gardenBenViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gardenBenViewModel);
        //}

        //// POST: GardenBenViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var gardenBenViewModel = await _context.GardenBenViewModel.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.GardenBenViewModel.Remove(gardenBenViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GardenBenViewModelExists(int id)
        //{
        //    return _context.GardenBenViewModel.Any(e => e.Id == id);
        //}
        //// GET: GardenBenViewModels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: GardenBenViewModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Description")] GardenBedViewModel gardenBenViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(gardenBenViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel.SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// POST: GardenBenViewModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] GardenBedViewModel gardenBenViewModel)
        //{
        //    if (id != gardenBenViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(gardenBenViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GardenBenViewModelExists(gardenBenViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gardenBenViewModel);
        //}

        //// GET: GardenBenViewModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gardenBenViewModel = await _context.GardenBenViewModel
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (gardenBenViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gardenBenViewModel);
        //}

        //// POST: GardenBenViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var gardenBenViewModel = await _context.GardenBenViewModel.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.GardenBenViewModel.Remove(gardenBenViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GardenBenViewModelExists(int id)
        //{
        //    return _context.GardenBenViewModel.Any(e => e.Id == id);
        //}
    }
}
