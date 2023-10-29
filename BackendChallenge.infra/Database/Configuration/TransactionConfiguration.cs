using BackendChallenge.core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.infra.Database.Configuration
{
    internal class TransactionConfiguration : BaseEntityConfiguration<Transaction>
    {
        private TransactionConfiguration()
        {
        }
        public static void Config(EntityTypeBuilder<Transaction> builder) => new TransactionConfiguration().Configure(builder);


        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.ToTable("Transactions");

            builder.Ignore(x => x.UpdatedAt);

            builder.HasKey(x => x.Id);

            builder.Property(b => b.SenderId)
                .IsRequired();

            builder.Property(b => b.ResiverId)
                .IsRequired();

            builder.Property(x => x.Amount);

            builder.Property(b => b.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(x => x.Sender).WithMany(x => x.Sent);
            builder.HasOne(x => x.Resiver).WithMany(x => x.Received);



        }
    }
}
