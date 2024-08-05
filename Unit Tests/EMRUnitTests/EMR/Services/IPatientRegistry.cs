using EMR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services
{
    public interface IPatientRegistry
    {
        Patient? Findpatient(string identityNumber);

    }
}
