using Innofactor.EfCoreJsonValueConverter;
using Mailroom_API.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Mailroom_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Models.Parcel> Parcels { get; set; }
        public DbSet<Models.LetterBag> LetterBags { get; set; }
        public DbSet<Models.ParcelBag> ParcelBags { get; set; } 
        public DbSet<Models.Shipment> Shipments { get; set; }

        
        //Override the model builder to convert BagList in Shipment model to a string of JSON objects, and deserialize the list when referencing.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the value converter for the BagList
            modelBuilder.Entity<Shipment>()
                .Property(x => x.BagList)
                .HasConversion(new ValueConverter<List<string>, string>(
                    a => JsonConvert.SerializeObject(a), // Convert to string for persistence
                    a => JsonConvert.DeserializeObject<List<string>>(a))); // Convert to List<String> for use

            modelBuilder.Entity<ParcelBag>()
                .Property(y => y.ParcelNos)
                .HasConversion(new ValueConverter<ICollection<string>, string>(
                    b => JsonConvert.SerializeObject(b),
                    b => JsonConvert.DeserializeObject<ICollection<string>>(b)));

            modelBuilder.Entity<LetterBag>()
                .Property(z => z.ParcelList)
                .HasConversion(new ValueConverter<ICollection<string>, string>(
                    c => JsonConvert.SerializeObject(c),
                    c => JsonConvert.DeserializeObject<ICollection<string>>(c)));
        }
    }
}