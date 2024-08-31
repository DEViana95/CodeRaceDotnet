using BaseApi.Domain.Entities.Base;

namespace BaseApi.Domain.Entities
{
    public class IncidentTypes : EntityBase
    {
        /// <summary>
        /// Título
        /// </summary>
        /// <value></value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Registro Ativo
        /// </summary>
        /// <value></value>
        public virtual Boolean Active { get; set; }
    }
}