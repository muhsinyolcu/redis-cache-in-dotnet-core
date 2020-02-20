using System;
using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;

namespace my.Redis.Controllers
{
    [Route("[controller]")]
    public class RedisController : ControllerBase
    {
        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;
        public RedisController(IEasyCachingProviderFactory easyCachingProviderFactory)
        {
            this.cachingProviderFactory = easyCachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis1");
        }
        [HttpGet("Set")]
        public IActionResult SetItemInQueue()
        {
            this.cachingProvider.Set("ThisIsTheKey", "Put some value here", TimeSpan.FromDays(365));
            return Ok();
        }

        [HttpGet("Get")]
        public IActionResult GetItemInQueue()
        {
            var item = this.cachingProvider.Get<string>("ThisIsTheKey");
            return Ok(item);
        }
    }
}
