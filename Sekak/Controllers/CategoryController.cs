using AppCore.Business.Models.Results.Enums;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Sekak.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.Query().ToList();
            return View(categories);
        }

        public IActionResult Details(string guId)
        {
            if (guId == null)
                return RedirectToAction(nameof(Index));
            var category = _categoryService.Query(c => c.GuId == guId).SingleOrDefault();
            if (category == null)
                return View("NotFound");
            return View(category);
        }

        public IActionResult Create()
        {
            var category = new CategoryModel();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryResult = _categoryService.Add(model);
                if (categoryResult.Status == ResultStatus.Exception)
                    throw new Exception(categoryResult.Message);
                if (categoryResult.Status == ResultStatus.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", categoryResult.Message);
            }
            return View(model);
        }

        public IActionResult Edit(string guId)
        {
            if (guId == null)
                return View("NotFound");
            var categoryResult = _categoryService.Query(c => c.GuId == guId.Trim()).SingleOrDefault();
            if (categoryResult == null)
                return View("NotFound");
            return View(categoryResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryResult = _categoryService.Update(model);
                if (categoryResult.Status == ResultStatus.Exception)
                    throw new Exception(categoryResult.Message);
                if (categoryResult.Status == ResultStatus.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", categoryResult.Message);
            }
            return View(model);
        }

        public IActionResult Delete(string guId)
        {
            if (guId == null)
                return View("NotFound");
            var categoryResult = _categoryService.Delete(guId);
            if (categoryResult.Status == ResultStatus.Exception)
                throw new Exception(categoryResult.Message);
            if (categoryResult.Status == ResultStatus.Success)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", categoryResult.Message);
            return View(guId);
        }
    }
}
