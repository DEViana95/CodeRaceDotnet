using BaseApi.Infra.Data;

namespace BaseApi.Domain.Services.Base
{
    public interface IServiceBase
    {
        /// <summary>
        /// Persistência das alterações em banco.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        bool Commit(AppDbContext context);
    }

    public class ServiceBase : IServiceBase
    {
        /// <summary>
        /// Persistência das alterações em banco.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool Commit(AppDbContext context)
        {
            return context.SaveChanges() > 0;
        }
    }
}