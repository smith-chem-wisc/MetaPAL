using MetaPAL.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class TestOrganisms
    {
        [Test]
        public void TestOrganismFileLoading()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Organism.tsv");
            var file = new OrganismFile(path);
            file.LoadResults();

            var organisms = file.Results;
            Assert.That(organisms.Count(), Is.EqualTo(25));

            var first = organisms.First();
            Assert.That(first.ProteomeId, Is.EqualTo("UP000000625"));
            Assert.That(first.Name, Is.EqualTo("Escherichia coli (strain K12)"));
            Assert.That(first.OrganismId, Is.EqualTo(83333));

            var last = organisms.Last();
            Assert.That(last.ProteomeId, Is.EqualTo("UP000000515"));
            Assert.That(last.Name, Is.EqualTo("Drosophila x virus (isolate Chung/1996) (DXV)"));
            Assert.That(last.OrganismId, Is.EqualTo(654931));

        }

        [Test]
        public void TestAddOrganismsToDatabase()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Organism.tsv");
            var file = new OrganismFile(path);
            file.LoadResults();

            var organisms = file.Results;
            using var Context = new TestingDbContext();

            if (Context.Database.EnsureCreated())
            {
                Context.Organisms.AddRange(organisms);
                Context.SaveChanges();

            }

            organisms = Context.Organisms.ToList();
            Assert.That(organisms.Count(), Is.EqualTo(25));
            CollectionAssert.AreEquivalent(file.Results, organisms);
        }
    }
}
