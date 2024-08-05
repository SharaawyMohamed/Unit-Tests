using EMR.Domain;
using EMR.Services;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Tests
{
    public class AppointmentSchedulerTests
    {
        [Fact]
        public void Schedule_when_PatientIsNotRegistered_ArgumentExceptionShouldBeThrow()
        {
            // Arrange
            var registyPatient = A.Fake<IPatientRegistry>();
            A.CallTo(() => registyPatient.Findpatient(A<string>.Ignored)).Returns(null);// bo be method return null in all caces
            var sut = new AppointmentScheduler(registyPatient);

            // Act/ Assert (be in one line in case (throw Exception))
            Assert.Throws<ArgumentException>(() => sut.Schedule("123466", DateTime.Now.AddDays(2)));
        }
        
        [Fact]
        public void Schedule_when_PatientIsRegistered_AppointmentShouldBeCreate()
        {
            // Arrange
            var registyPatient = A.Fake<IPatientRegistry>();
            A.CallTo(() => registyPatient.Findpatient(A<string>.Ignored)).Returns(new Patient());// bo be method return null in all caces
            var sut = new AppointmentScheduler(registyPatient);

            // Act
            var actual= sut.Schedule("123466", DateTime.Now.AddDays(2));
            // Assert
            Assert.True(actual > 0);
        }
    }
}
