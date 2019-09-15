using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

[SetUpFixture]
public class AssemblySetup
{
    [SetUp]
    public void Setup()
    {
        FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetBusinessOperationList());
    }
}