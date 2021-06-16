using System.Linq;
using NUnit.Framework;
using Owl_Ops_Webserver.Model;

namespace OwlWebserverTest
{
    public class Tests
    {
        private OwlDatabaseContext _owlDatabaseContext;
        [SetUp]
        public void Setup()
        {
            _owlDatabaseContext = new OwlDatabaseContext();

        }

        [Test]
        public void Test1()
        {
            Assert.NotNull(_owlDatabaseContext.Users.ToList());
        }
    }
}