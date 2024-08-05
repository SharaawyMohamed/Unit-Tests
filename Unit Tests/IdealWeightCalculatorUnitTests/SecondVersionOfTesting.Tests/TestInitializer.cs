using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVersionOfTesting.Tests  
{
    [TestClass]
    public class TestInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitializer(TestContext context) 
        {
            context.WriteLine("In Assembly Initializer ");
        }
        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {

        }
    }
}
#region Attributes in Unit Tests
//Common Attributes
//[TestClass]: Marks a class that contains unit tests.
//[TestMethod]: Marks a method as a unit test.
//[TestInitialize]: Runs code before each test method.
//[TestCleanup]: Runs code after each test method.
//[ClassInitialize]: Runs code before any tests in the class are run(static method).
//[ClassCleanup]: Runs code after all tests in the class have run(static method).
//[DataTestMethod]: Marks a method as a data-driven test.
//[DataRow]: Specifies data for a data-driven test method.
#endregion