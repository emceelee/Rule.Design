using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rule.Measurement.Validation.Rules.GasVolume;
using Rule.Measurement.DataObject;
using System;

namespace Rule.Measurement.Validation.Test
{
    [TestClass]
    public class GasVolumeRulesTest
    {
        #region ValidMeterRule

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ValidMeterRule_NullParameter()
        {
            var rule = new ValidMeterRule();
            rule.Execute(null);
        }

        [TestMethod]
        public void ValidMeterRule_Valid()
        {
            var rule = new ValidMeterRule();
            var obj = new GasVolumeDO()
            {
                Meter = "Meter"
            };

            var result = rule.Execute(obj);

            Assert.AreEqual(ValidationLevel.None, result.Result, "ValidMeterRule should not result in a ValidationLevel");
            Assert.IsNull(result.Message, "ValidMeterRule should not result in a ValidationMessage");
        }

        [TestMethod]
        public void ValidMeterRule_Null()
        {
            var rule = new ValidMeterRule();
            var obj = new GasVolumeDO();

            var result = rule.Execute(obj);

            Assert.AreEqual(rule.ValidationLevel, result.Result, $"ValidMeterRule did not result in the right ValidationLevel");
        }

        [TestMethod]
        public void ValidMeterRule_Empty()
        {
            var rule = new ValidMeterRule();
            var obj = new GasVolumeDO()
            {
                Meter = ""
            };

            var result = rule.Execute(obj);

            Assert.AreEqual(rule.ValidationLevel, result.Result, $"ValidMeterRule did not result in the right ValidationLevel");

        }
        #endregion
    }
}
