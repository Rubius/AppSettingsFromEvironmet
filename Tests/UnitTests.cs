using Common.Utils;
using System;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            Settings settings = new Settings();
            settings.A = new Level1();

            Environment.SetEnvironmentVariable("ServiceName_B_D", "BD");
            Environment.SetEnvironmentVariable("ServiceName_C_E", "CE");

            Environment2Settings.SetProperies(settings.A, "ServiceName");

            Assert.Equal("BD", settings.A.B.D);
            Assert.Equal("CE", settings.A.C.E);

            Assert.Null(settings.A.B.E);
            Assert.Null(settings.A.C.D);
        }


        [Fact]
        public void Test2()
        {
            Settings settings = new Settings();

            Assert.Throws<NullReferenceException>(() => 
            {
                Environment2Settings.SetProperies(settings.A, "ServiceName");
            });
        }
    }
}
