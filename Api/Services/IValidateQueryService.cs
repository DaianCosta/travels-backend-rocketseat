namespace Api.Services
{
    public interface IValidateQueryService
    {    
        string Validate(string destiny, int? page, int? limit);
    }
}
