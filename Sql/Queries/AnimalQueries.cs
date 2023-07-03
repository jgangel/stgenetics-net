namespace Stgen.Sql.Queries
{
    public class AnimalQueries
    {
        public static string GetAll => "SELECT AnimalId, Name, Breed, BirthDate, Sex, Price, Status FROM Animal";

        public static string GetById => "SELECT AnimalId, Name, Breed, BirthDate, Sex, Price, Status FROM Animal WHERE AnimalId = @AnimalId";

        public static string Add =>
            @"INSERT INTO Animal (Name, Breed, BirthDate, Sex, Price, Status)
            VALUES (@Name, @Breed, @BirthDate, @Sex, @Price, @Status)";

        public static string Update =>
            @"UPDATE Animal
        SET Name = @Name, 
            Breed = @Breed, 
            BirthDate = @BirthDate, 
            Sex = @Sex, 
            Price = @Price, 
            Status = @Status,
        WHERE AnimalId = @AnimalId";

        public static string Delete => "DELETE FROM Animal WHERE AnimalId = @AnimalId";
        public static string Filter => "SELECT AnimalId, Name, Breed, BirthDate, Sex, Price, Status FROM Animal /**where**/";

    }
}
