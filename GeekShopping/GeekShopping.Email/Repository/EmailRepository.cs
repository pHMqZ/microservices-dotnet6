using GeekShopping.Email.Messages;
using GeekShopping.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<MySQLContext> _context;

        public EmailRepository(DbContextOptions<MySQLContext> context)
        {
            _context = context;
        }

        public Task LogEmail(UpdatePaymentResultMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
