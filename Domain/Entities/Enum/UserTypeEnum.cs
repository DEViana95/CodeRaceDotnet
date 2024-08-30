using System.ComponentModel;

namespace BaseApi.Domain.Entities.Enum
{
    public enum UserTypeEnum
    {
        /// <summary>
        /// Administrador.
        /// </summary>
        [Description("Administrador")]
        Administrator = 1,

        /// <summary>
        /// Básico.
        /// </summary>
        [Description("Básico")]
        Normal = 2,
    }
}