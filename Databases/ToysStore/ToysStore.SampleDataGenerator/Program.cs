using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    class Program
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToysStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            int categoriesCount = 100;
            int manufacturersCount = 50;
            int ageRangesCount = 100;
            int toyCount = 20000;

            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryDataGenerator(random, db, categoriesCount),
                new ManufacturerDataGenerator(random, db, manufacturersCount),
                new AgeRangeDataGenerator(random, db, ageRangesCount),
                new ToyDataGenerator(random, db, toyCount)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
