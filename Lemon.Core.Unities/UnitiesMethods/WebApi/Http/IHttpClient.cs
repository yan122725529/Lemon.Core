using ZilLion.Core.Infrastructure.Unities.WebApi.Entity;

namespace ZilLion.Core.Infrastructure.Unities.WebApi.Http
{
    /// <summary>
    /// http 请求接口
    /// </summary>
    public interface IHttpClient
    {
        T HttpGet<T>(string url, RequestIdentity requestIdentity);

        T HttpPost<P, T>(P param, string url, RequestIdentity requestIdentity);
    }
}
