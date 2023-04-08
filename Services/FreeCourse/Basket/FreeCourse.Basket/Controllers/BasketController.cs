using FreeCourse.Basket.Dtos;
using FreeCourse.Basket.Services;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpPut]
        public async Task<IActionResult> Update(BasketDto basket)
        {
            basket.UserId = _sharedIdentityService.GetUserId;
            return CreateActionResultInstance
                (await _basketService.SaveOrUpdate(basket));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(BasketDto basket)
        {
            basket.UserId = _sharedIdentityService.GetUserId;
            return CreateActionResultInstance
                (await _basketService.SaveOrUpdate(basket));
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResultInstance
                (await _basketService.Get(_sharedIdentityService.GetUserId));

        }




        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance
                    (await _basketService.Delete(_sharedIdentityService.GetUserId));
        }

    }
}
