using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    internal class CategoryDataGenerator : DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects) 
            : base (randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding categories");
            for (int i = 0; i < this.Count; i++)
            { 
                var category = new Category
                {
                    Name = Random.GetRandomStringWithRandomLength(5, 20)
                };

                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nCategories added");
        }
    }
}
