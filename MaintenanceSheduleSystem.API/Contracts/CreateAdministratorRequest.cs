namespace MaintenanceSheduleSystem.API.Contracts
{
    public record CreateAdministratorRequest(string surname, string firstName, string lastName, string email, string password);
    
}
