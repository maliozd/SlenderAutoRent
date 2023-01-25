using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
