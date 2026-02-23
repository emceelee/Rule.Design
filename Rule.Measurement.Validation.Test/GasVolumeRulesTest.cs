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

        #region ValidEffectiveDateRule

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ValidEffectiveDateRule_NullParameter()
        {
            var rule = new ValidEffectiveDateRule();
            rule.Execute(null);
        }

        [TestMethod]
        public void ValidEffectiveDateRule_ValidDates()
        {
            var rule = new ValidEffectiveDateRule();
            var obj = new GasVolumeDO()
            {
                StartDateTime = DateTime.Parse("2026-02-23T10:00:00"),
                EndDateTime = DateTime.Parse("2026-02-23T11:00:00")
            };

            var result = rule.Execute(obj);
            Assert.AreEqual(ValidationLevel.None, result.Result, "ValidEffectiveDateRule should not result in a ValidationLevel");
            Assert.IsNull(result.Message, "ValidEffectiveDateRule should not result in a ValidationMessage");
        }

        [TestMethod]
        public void ValidEffectiveDateRule_InvalidDates()
        {
            var rule = new ValidEffectiveDateRule();
            var obj = new GasVolumeDO()
            {
                StartDateTime = DateTime.Parse("2026-02-23T12:00:00"),
                EndDateTime = DateTime.Parse("2026-02-23T11:00:00")
            };

            var result = rule.Execute(obj);
            Assert.AreEqual(rule.ValidationLevel, result.Result, "ValidEffectiveDateRule did not result in the right ValidationLevel");
            Assert.AreEqual(rule.ValidationMessage, result.Message, "ValidEffectiveDateRule did not result in the right ValidationMessage");
        }

        #endregion
    }
}
