using Microsoft.EntityFrameworkCore;

namespace EfCoreNullBug
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString)
        {
            this.Database.SetConnectionString(connectionString);
        }
        
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public int? Age { get; set; }
    }

    public enum HouseType : int
    {
        Apartment = 0,
        Condominium = 1,
        Landed = 2,
    }

    [Owned]
    public class Address : ValueObject
    {
        public string StreetName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public HouseType HouseType { get; set; }
        public bool IsMobile { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetName;
            yield return City;
            yield return PostalCode;
            yield return Country;
            yield return HouseType;
            yield return IsMobile;
        }
    }

    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
        // Other utility methods
    }
}
