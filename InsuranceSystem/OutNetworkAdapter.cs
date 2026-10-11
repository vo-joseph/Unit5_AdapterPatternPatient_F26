using System;
using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem;

public class OutNetworkAdapter : InsuranceInterface
{
    OutNetworkPatient outNetworkPatient;

    public OutNetworkAdapter(string patientName, int policyNumber)
    {
        outNetworkPatient = new OutNetworkPatient(patientName, policyNumber);
    }

    public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
    {
        decimal percent = outNetworkPatient.CoveragePercent(ProcedureCost);

        return percent * ProcedureCost;
    }

    public string getPatientName()
    {
        return outNetworkPatient.Name;
    }

    public string getPolicyNumber()
    {
        return outNetworkPatient.PolicyNumber.ToString();
    }

    public bool IsCovered(string patientName, string policyNumber)
    {
        return outNetworkPatient.IsCovered(getPatientName(), outNetworkPatient.PolicyNumber) == "yes";
    }
}
