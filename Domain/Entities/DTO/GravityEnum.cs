using System.ComponentModel;

namespace BaseApi.Domain.Entities.DTO
{
    public enum GravityEnum
    {
        [Description("Baixa")]
        Small = 1,
        [Description("Média")]
        Average = 2,
        [Description("Alta")]
        High = 3,
    }
}