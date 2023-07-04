namespace Stgen.Sql.Queries
{
    public class PurchaseQueries
    {
        public static string FilterByStatusAndUserId => "SELECT Id, UserId, Total, Discount, Freight, Status FROM Purchase WHERE Status=@Status AND UserId=@UserId";
        public static string CountAnimals => "SELECT COUNT(1) FROM AnimalPurchase WHERE PurchaseId=@Id";
        public static string GetAnimals => "SELECT PurchaseId, AnimalId, Price, Discount FROM AnimalPurchase WHERE PurchaseId=@Id";
        public static string AddAnimal => "INSERT INTO AnimalPurchase(AnimalId,PurchaseId,Price,Discount) VALUES(@AnimalId,@PurchaseId,@Price,@Discount)";
        public static string Create => "INSERT INTO Purchase(UserId,Total,Discount,Freight,Status) VALUES(@UserId,@Total,@Discount,@Freight,@Status)";
        public static string Update =>
            @"UPDATE Purchase
        SET Total = @Total, 
            Discount = @Discount, 
            Freight = @Freight, 
            Status = @Status
        WHERE Id = @Id";
    }
}
