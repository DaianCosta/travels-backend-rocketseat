using System.Collections.Generic;

namespace Api.Services
{

    public class ValidateQueryService : IValidateQueryService
    {
        public string Validate(string destiny, int? page, int? limit)
        {
            List<string> erros = new List<string>();

            if (page.GetValueOrDefault() <= 0)
                erros.Add("The page must be greater than 0");

            if (limit.GetValueOrDefault() < 5 || limit.GetValueOrDefault() > 30)
                erros.Add("The limit must be filled with values between 5 and 30");

            if (!string.IsNullOrEmpty(destiny) && destiny.Length < 2)
                erros.Add("When filled in, the name field must have at least 2 characters");

            if (erros.Count <= 0)
                return null;

            return string.Join(", ", erros);
        }
    }
}