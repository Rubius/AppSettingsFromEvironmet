using Common.Utils;
using System;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void TestReading()
        {
            Settings settings = new Settings();
            settings.A = new Level1();

            Environment.SetEnvironmentVariable("ServiceName_B_D", "BD");
            Environment.SetEnvironmentVariable("ServiceName_C_E", "CE");

            EnvironmentVariableReader.SetProperies(settings.A, "ServiceName");

            Assert.Equal("BD", settings.A.B.D);
            Assert.Equal("CE", settings.A.C.E);

            Assert.Null(settings.A.B.E);
            Assert.Null(settings.A.C.D);
        }


        [Fact]
        public void TestExceptions()
        {
            Settings settings = new Settings();

            Assert.Throws<NullReferenceException>(() => 
            {
                EnvironmentVariableReader.SetProperies(settings.A, "ServiceName");
            });
        }
    }
}
