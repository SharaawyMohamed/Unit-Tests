using EMR.Domain;
using EMR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR
{
    public class PatientRegistry : IPatientRegistry
    {
        private readonly ApplicationDbContext _context;

        public PatientRegistry(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPatient(Patient patient)
        {

        }
        public Patient? Findpatient(string identityNumber)
        {
        }
    }
}
