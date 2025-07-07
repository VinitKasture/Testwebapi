using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    public class A
    {
        private readonly IGuidService _guidService;

        public A(IGuidService guidService)
        {
            _guidService = guidService;
        }

        public string GetGuid() => _guidService.GetGuid();
    }

    public class B
    {
        private readonly IGuidService _guidService;

        public B(IGuidService guidService)
        {
            _guidService = guidService;
        }

        public string GetGuid() => _guidService.GetGuid();
    }

}
