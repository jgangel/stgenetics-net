using Stgen.Domain.Enums;
using Stgen.Domain.Repository;

namespace Stgen.Domain.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? NormalizedUserName { get; set; }

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string? PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }


        /// <summary>
        /// Gets the user cart, defined as their single active purchase.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns>The user cart</returns>

        public async Task<Purchase> GetOrCreateCart(IUnitOfWork unitOfWork)
        {
            var purchase = await unitOfWork.Purchases.GetActive(Id);
            if (purchase == null)
            {
                purchase = new()
                {
                    UserId = Id,
                    Discount = 0,
                    Total = 0,
                    Freight = 1000,
                    Status = PurchaseStatus.Active,
                };
                await unitOfWork.Purchases.Create(purchase);
                // This could be done in one query, returning Id
                purchase = await unitOfWork.Purchases.GetActive(Id);
            }
            return purchase!;
        }
    }
}
