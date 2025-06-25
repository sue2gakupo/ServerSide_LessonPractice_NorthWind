using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWind.Models;

namespace NorthwindStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoryProductViewModel
            {
                Categories = await _context.Categories.ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };
            return View(viewModel);
            //return View(await _context.Categories.ToListAsync());
        }

        public async Task<IActionResult> GetPicture(int id)
        {
            //取得某個商品分類的圖片
            var cate = await _context.Categories.FindAsync(id);

            if (cate == null || cate.Picture == null || cate.Picture.Length == 0)
            {
                return NotFound(); // 如果找不到圖片，返回404 Not Found
            }

            var picBytes = cate.Picture.Skip(78).ToArray(); //Picture是二進位資料，通常儲存為 OLE 封裝的影像資料。直接在 Razor View 用
                                                            //<img src="..." /> 顯示時，必須將其轉為 base64 字串，並去除 OLE header。
                                                            //跳過前78個byte，取得圖片的實際內容，轉成byte[]陣列
                                                            //前78個byte是圖片的格式資訊


            return File(picBytes, "image/bmp ");
        }



        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Description,Picture")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,Description,Picture")] Categories categories)
        {
            if (id != categories.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryID))
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
            return View(categories);
        }


        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
