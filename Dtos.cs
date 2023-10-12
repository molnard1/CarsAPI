namespace Cars
{
    public record CarDto(Guid Id, string Name, string Description, DateTime CreatedTime);

    public record CreateCarDto(string Name, string Description);
    public record UpdateCarDto(Guid Id, string Name, string Description);
}
