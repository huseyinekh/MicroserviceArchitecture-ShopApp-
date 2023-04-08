using FreeCourse.Discount.Models;
using FreeCourse.Discount.Services;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : CustomBaseController
    {
        private readonly ISharedIdentityService _identityService;
        private readonly IDiscountService _discountService;

        public DiscountController
            (ISharedIdentityService sharedIdentityService, IDiscountService discountService)
        {
            _identityService = sharedIdentityService;
            _discountService = discountService;
        }

        //[Route("api/[controller]/[action]/{userId}")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _discountService.GetAll();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _discountService.GetById(id);
            return CreateActionResultInstance(res);
        }

        [Route("/api/[controller]/[action]/{code}")]

        [HttpGet]

        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _identityService.GetUserId;
            var res = await _discountService.GetByUserIdAndCode
                        (userId, code);
            return CreateActionResultInstance(res);
        }
        [HttpPost]
        public async Task<IActionResult> Save(DiscountModel discountModel)
        {
            var discount = await _discountService.Save(discountModel);
            return CreateActionResultInstance(discount);
        }
        [HttpPut]
        public async Task<IActionResult> Update(DiscountModel discountModel)
        {
            var discount = await _discountService.Update(discountModel);
            return CreateActionResultInstance(discount);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _discountService.Delete(id);
            return CreateActionResultInstance(res);

        }


    }
}
