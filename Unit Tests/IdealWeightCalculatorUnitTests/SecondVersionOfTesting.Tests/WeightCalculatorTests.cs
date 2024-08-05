using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SecondVersionOfTesting.Data;
using SecondVersionOfTesting.Tests.Models;
using System.Reflection;

namespace SecondVersionOfTesting.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {
        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void AssemblyInitializer(TestContext context)
        {
            context.WriteLine("In Class Initializer ");
        }
        [ClassCleanup]
        public static void AssemblyCleanUp()
        {

        }
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In Test Initialize");
        }
        [TestCleanup]
        public void TestCleanUp()
        {

        }
        [TestMethod]
        public void GetIdealweight_gender_M_Height_170_return_65()
        {
            // Arrange
            var get = new WeightCalculator()
            {
                Gender = 'M',
                Height = 170
            };

            // Act
            double actual = get.test();
            double expected = 65;

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [ExpectedException(typeof(ArgumentException))]// this attribute used if you expect that your code may be return exeption 
        [Description("This Unit test using simple cases")]
        [Priority(10)]
        [Owner("Sharawy")]
        [TestCategory("Assert Category")]
        [Timeout(30000)]
        [Ignore]
        [TestMethod]
        public void GetIdealweight_gender_X_Height_170_return_Throw_Exception()
        {
            // Arrange
            var get = new WeightCalculator()
            {
                Gender = 'X',
                Height = 170
            };

            // Act
            double actual = get.test();
            double expected = 65;

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Assert_Methods()
        {
            // Assert Methods
            Assert.AreEqual(10, 8 + 2);
            //Assert.AreNotEqual(10, 8);
            //var get = new WeightCalculator()
            //{
            //    Gender='M',
            //    Height=180
            //};
            //var get1 = new WeightCalculator();
            //Assert.IsInstanceOfType(get, typeof(WeightCalculator));
            //Assert.AreSame(get, get1);
            //Assert.AreNotSame(get, get1);
            //Assert.IsTrue(2>1);
            //Assert.IsFalse(2>4);
            //get1 = null;
            //Assert.IsNull(get1);
            //Assert.IsNotNull(get);
        }
        [TestMethod]
        public void StringAssert_Tests()
        {
            string ali = "AliEdElnassr";
            //StringAssert.Contains(ali, "EdE");
            //StringAssert.EndsWith(ali, "nassr");
            StringAssert.StartsWith(ali, "Ali");
        }
        [TestMethod]
        public void Collection_Test()
        {
            List<string> coll = new List<string> { "Ali", "Mohamed", "Sharawy", "Ziad", "Yousef"};
            List<string> subcoll = new List<string> { "Ali", "Mohamed", "Sharawy"};
            // CollectionAssert.AllItemsAreNotNull(coll);
            //CollectionAssert.Contains(coll, "Ziad");
            //CollectionAssert.AllItemsAreInstancesOfType(coll, typeof(string));
            //CollectionAssert.IsSubsetOf(subcoll, coll);
        }
        [TestMethod]
        public void FluentAssertsions_test()
        {
            List<string> coll = new List<string> { "Ali", "Mohamed", "Sharawy", "Ziad", "Yousef" };
            List<string> subcoll = new List<string> { "Ali", "Mohamed", "Sharawy" };
            //coll.Should().Contain("Ziad");
            //coll.Should().AllBeOfType(typeof(string));
            // subcoll.Should().BeSubsetOf(coll);
            int number = 10;
            //number.Should().BeGreaterThan(9);
            // number.Should().BeLessThan(11);
            // coll.Should().StartWith("Ali").And.EndWith("Yousef");
            coll.Should().HaveCount(5);

        }
        [TestMethod]
        public void TestCollectionOfIdealWeidth()
        {
            var obj = new WeightCalculator(new FakeWeightRepository());
            var Actual = obj.IdealWeights();
            var Expected = new List<double>();
            foreach(var i in Actual)
            {
                Expected.Add(i);
            }
            CollectionAssert.AreEqual(Expected, Actual);

        }
        [TestMethod]
        public void GetIdealWeightUsingDataSource_MOQ()
        {
            List<WeightCalculator> Weights = new List<WeightCalculator>()
            {
                new WeightCalculator{Height=175,Gender='F'},//62.5
                new WeightCalculator{Height=167,Gender='M'},//62.75
                new WeightCalculator{Height=182,Gender='M'},//74
            };
            Mock<IDataRepository> repo=new Mock<IDataRepository>();
            repo.Setup(w => w.GetWeightsToCalculate()).Returns(Weights);

            WeightCalculator obj=new WeightCalculator(repo.Object);

            var Actual=obj.IdealWeights();
            var expected = new List<double> { 62.5, 62.75, 74 };
            Actual.Should().BeEquivalentTo(expected);
        } 
        [TestMethod]
        public void GetIdealWeightUsingDataSource_FakeItEasy()
        {
            List<WeightCalculator> Weights = new List<WeightCalculator>()
            {
                new WeightCalculator{Height=175,Gender='F'},//62.5
                new WeightCalculator{Height=167,Gender='M'},//62.75
                new WeightCalculator{Height=182,Gender='M'},//74
            };
            var repo=A.Fake <IDataRepository>();
           // repo.Setup(w => w.GetWeightsToCalculate()).Returns(Weights);
            A.CallTo(() => repo.GetWeightsToCalculate()).Returns(Weights);

            WeightCalculator obj=new WeightCalculator(repo);

            var Actual=obj.IdealWeights();
            var expected = new List<double> { 62.5, 62.75, 74 };
            Actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(175, 'F', 62.5)]
        [DataRow(167, 'm', 62.75)]
        [DataRow(182, 'm', 74)]
        public void Work_With_Data_Drevin_Test(double height,char gender,double expected)
        {
            var obj = new WeightCalculator() 
            {
                Height=height,
                Gender=gender
            };

            var actual = obj.test();
            actual.Should().Be(expected);
        }

        public static List<object[]> TestCases()
        {
            return new List<object[]>
            {
                new object[]{ 175, 'F', 62.5 },
                new object[]{167,'m',62.75},
                new object[]{182,'m',74},
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(TestCases),DynamicDataSourceType.Method)]
        public void Driven_Test_With_Dynamic(double height,char gender,double expected)
        {
            var obj = new WeightCalculator()
            {
                Height = height,
                Gender = gender
            };

            var actual = obj.test();
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void Validate_With_UnCorrect_Gender_Return_False()
        {
            var obj = new WeightCalculator()
            {
                Gender = 'R'
            };

            bool actual = obj.ValidateGender();
            actual.Should().Be(false);
        }

        [TestMethod]
        public void AddUser_Good_Should_Saved()
        {
            // Arrange
            var user = new User()
            {
                Name = "Ali",
                BirthDate = DateTime.Now,
                Email = "Ali123@gmail.com",
                Password = "Pa$$w0rd"
            };
            DataAccessLayer obj = new DataAccessLayer(new UserDbContext());

            // Act
            obj.AddUser(user);
            User Expected = obj.GetUserByName(user.Name);

            // Assert
            user.Should().BeEquivalentTo(Expected);
        }
    }
}