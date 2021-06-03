using System;

namespace TimeSheets.Models.Dto.Requests
{
    /// <summary> Запрос на обновление Access токена </summary>
    public sealed class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
     }
}