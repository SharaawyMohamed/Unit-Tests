using EMR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR
{
    public class AppointmentScheduler:IAppointmentScheduler 
    {
        private readonly IPatientRegistry _registrar;

        public AppointmentScheduler(IPatientRegistry registrar)
        {
            _registrar = registrar;
        }

        public int Schedule(string IdentityNumber,DateTime slot)
        {
            var patient = _registrar.Findpatient(IdentityNumber);
            if (patient == null)
            {
                throw new ArgumentException($"Patient With IdentityNumber : {IdentityNumber} Is Not Registered");
            }
            return Random.Shared.Next(1, 1000);
        }
    }
}
