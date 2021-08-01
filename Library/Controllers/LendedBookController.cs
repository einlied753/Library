using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.DAL.Repositories;
using Library.DAL;
using Library.DAL.Models;

namespace Library.Controllers
{
    [Route("lendedBook")]
    public class LendedBookController : BaseController
    {
        private ILendedBookRepo _lendedBookRepo;

        public LendedBookController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _lendedBookRepo = UnitOfWork.GetLendedBookRepo();
        }

        [HttpGet]
        [Route("get/{lendedBookId:int}")]
        public async Task<IActionResult> GetLendedBookByIdAsync(int lendedBookId)
        {
            LendedBook lendedBook = await _lendedBookRepo.SelectByIdAsync(lendedBookId);
            return lendedBook == null ? NotFound() : (IActionResult)Ok(lendedBook);
        }

        [HttpGet]
        [Route("get_list")]
        public async Task<IActionResult> GetLendedBookListAsync()
        {
            IEnumerable<LendedBook> lendedBookList = await _lendedBookRepo.SelectListAsync();
            return lendedBookList.Count() == 0 ? NotFound() : (IActionResult)Ok(lendedBookList);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateLendedBookAsync([FromBody] LendedBook newLendedBook)
        {
            LendedBook lendedBook = await _lendedBookRepo.SelectByIdAsync(newLendedBook.Id);
            if (lendedBook != null)
            {
                return Conflict();
            }
            else
            {
                _lendedBookRepo.Insert(newLendedBook);
                await UnitOfWork.SaveAsync();
                IEnumerable<LendedBook> lendedBookList = await _lendedBookRepo.SelectListAsync();
                return lendedBookList.Count() == 0 ? NotFound() : (IActionResult)Ok(lendedBookList);
            }
        }

        [HttpPut]
        [Route("edit/{lendedBookId:int}")]
        public async Task<IActionResult> EditLendedBookAsync(int lendedBookId, [FromBody] LendedBook changedLendedBook)
        {
            LendedBook lendedBook = await _lendedBookRepo.SelectByIdAsync(lendedBookId);
            if (lendedBook == null)
            {
                return NotFound();
            }
            else
            {
                _lendedBookRepo.Update(changedLendedBook);
                await UnitOfWork.SaveAsync();
                IEnumerable<LendedBook> lendedBookList = await _lendedBookRepo.SelectListAsync();
                return lendedBookList.Count() == 0 ? NotFound() : (IActionResult)Ok(lendedBookList);
            }
        }

        [HttpDelete]
        [Route("delete/{lendedBookId:int}")]
        public async Task<IActionResult> DeleteLendedBookAsync(int lendedBookId)
        {
            LendedBook lendedBook = await _lendedBookRepo.SelectByIdAsync(lendedBookId);
            if (lendedBook == null)
            {
                return NotFound();
            }
            else
            {
                _lendedBookRepo.Delete(lendedBook);
                await UnitOfWork.SaveAsync();
                IEnumerable<LendedBook> lendedBookList = await _lendedBookRepo.SelectListAsync();
                return Ok(lendedBookList);
            }
        }

    }
}