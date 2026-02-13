using System.Net.Http.Headers;

namespace CompanyEmployee.MVC.Infrastucture.Handler
{
    public class JwtHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtHandler(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor
                .HttpContext?
                .Session
                .GetString("JWToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }

}
