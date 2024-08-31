using System.ComponentModel;

namespace BaseApi.Domain.Entities.DTO
{
    public enum StatusEnum
    {
        [Description("Registro recebido")]
        ReceivedRegister = 1,

        [Description("Em atendimento")]
        InAttendance = 2,

        [Description("Concluído")]
        Concluded = 3,

        [Description("Cancelado")]
        Cancelled = 4,
    }
}