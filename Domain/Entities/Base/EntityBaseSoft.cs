namespace BaseApi.Domain.Entities.Base
{
    public class EntityBaseSoft : EntityBase
    {
        /// <summary>
        /// Id público.
        /// </summary>
        /// <value></value>
        public virtual Guid PublicId { get; set; }

        /// <summary>
        /// Criado em ...
        /// </summary>
        /// <value></value>
        public virtual DateTime Created { get; set; }

        /// <summary>
        /// Criado por ...
        /// </summary>
        /// <value></value>
        public virtual long CreatedBy { get; set; }

        /// <summary>
        /// Modificado em ...
        /// </summary>
        /// <value></value>
        public virtual DateTime? Modified { get; set; }

        /// <summary>
        /// Modificado por ...
        /// </summary>
        /// <value></value>
        public virtual long? ModifiedBy { get; set; }

        /// <summary>
        /// Deletado.
        /// </summary>
        /// <value></value>
        public virtual bool Deleted { get; set; }
    }
}