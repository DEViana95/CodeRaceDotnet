using BaseApi.Domain.Entities.Base;

namespace BaseApi.Domain.Entities
{
    public class Parameters : EntityBase
    {
        /// <summary>
        /// Título
        /// </summary>
        /// <value></value>
        public virtual string Cellphone { get; set; }

        /// <summary>
        /// Telefone.
        /// </summary>
        /// <value></value>
        public virtual string Phone { get; set; }

        /// <summary>
        /// Telegram.
        /// </summary>
        /// <value></value>
        public virtual string Telegram { get; set; }
    }
}