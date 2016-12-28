using Lemon.Core.Unities.UnitiesMethods.WebApi.Entity;

namespace Lemon.Core.Unities.UnitiesMethods.WebApi.Http
{
    /// <summary>
    /// http 请求接口
    /// </summary>
    public interface IHttpClient
    {
        T HttpGet<T>(string url, RequestIdentity requestIdentity);

        T HttpPost<TP, T>(TP param, string url, RequestIdentity requestIdentity);
    }
}
