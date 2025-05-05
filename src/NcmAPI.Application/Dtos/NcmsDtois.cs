using System.Collections.Generic;

namespace NcmAPI.Application.DTOs
{
    /// <summary>
    /// DTO que representa um NCM novo.
    /// </summary>
   
    public record NewNcmDto(int Id, string Code);

    /// <summary>
    /// DTO que representa a estrutura de retorno para um NCM antigo e seus NCMs novos associados.
    /// </summary>
    public record OldNcmDto(string OldCode, IEnumerable<NewNcmDto> NewNcms);
}
