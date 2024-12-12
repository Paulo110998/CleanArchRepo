using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

[Authorize]
public class CategoriesController : Controller
{
    // Injetando a interface do serviço
    private readonly ICategoryService _categoryService;

    // Construtor
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;        
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // Busca as categorias através da interface
        var categories = await _categoryService.GetCategories();
        
        // retorna na view
        return View(categories);
    }

    ////////// CREATE /////////////////////
    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO category)
    {
        // Verifica se o modelo é válido
        if (ModelState.IsValid)
        {
            await _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    //////////// EDIT  /////////////
    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var categoryDto = await _categoryService.GetCategoryById(id);

        if (categoryDto == null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.Update(categoryDto);
            }
            catch(Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(categoryDto);
    }


    ///////////  DELETE //////////////
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var categoryDto = await _categoryService.GetCategoryById(id);

        if (categoryDto == null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    ///////  DETAILS ////////////
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var categoryDto = await _categoryService.GetCategoryById(id);

        if (categoryDto == null) return NotFound();

        return View(categoryDto);
    }

}
