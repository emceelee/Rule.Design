using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rule.Core;
using Rule.Core.Interface;
using Rule.Core.Test.Rules;

namespace Rule.Core.Test
{
    public static class RuleNames
    {
        public const string R001 = "R001";
        public const string R002 = "R002";
        public const string R003 = "R003";
        public const string R004 = "R004";
        public const string R005 = "R005";
        public const string R006 = "R006";
        public const string R007 = "R007";
        public const string R008 = "R008";
        public const string R009 = "R009";
    }

    public class TestObject
    {
        public int IntegerProperty { get; set; }
    }

    [TestClass]
    public static class TestSetup
    {
        public static RuleRegistry<TestObject, bool> BoolRegistrySimple = new RuleRegistry<TestObject, bool>();
        public static RuleRegistry<TestObject, bool> BoolRegistryObject = new RuleRegistry<TestObject, bool>();

        [AssemblyInitialize]
        public static void SetupRegistry(TestContext context)
        {
            BoolRegistrySimple.RegisterRule(RuleNames.R001, new Rule<TestObject, bool>((obj) =>
            {
                RuleResult<bool> result = new RuleResult<bool>()
                {
                    Result = true,
                    Message = "Success"
                };
                return result;
            }));
            BoolRegistrySimple.RegisterRule(RuleNames.R002, new Rule<TestObject, bool>((obj) =>
            {
                RuleResult<bool> result = new RuleResult<bool>()
                {
                    Result = false,
                    Message = "Failure"
                };
                return result;
            }));
            //Use Coded rules here, single instance and not
            BoolRegistrySimple.RegisterRule(RuleNames.R003, typeof(TrueRule));
            BoolRegistrySimple.RegisterRule(RuleNames.R004, typeof(FalseRule));
            BoolRegistrySimple.RegisterRule(RuleNames.R005, typeof(TrueRule), true);
            BoolRegistrySimple.RegisterRule(RuleNames.R006, typeof(FalseRule), true);

            BoolRegistryObject.RegisterRule(RuleNames.R001, new Rule<TestObject, bool>((obj) =>
            {
                //Negative integer rule
                RuleResult<bool> result = new RuleResult<bool>();
                result.Result = obj.IntegerProperty < 0;
                result.Message = $"Negative? {result.Result}";
                return result;
            }));
            BoolRegistryObject.RegisterRule(RuleNames.R002, new Rule<TestObject, bool>((obj) =>
            {
                //Even integer
                RuleResult<bool> result = new RuleResult<bool>();
                result.Result = obj.IntegerProperty % 2 == 0;
                result.Message = $"Even? {result.Result}";
                return result;
            }));
            //Use Coded rules here
            BoolRegistryObject.RegisterRule(RuleNames.R003, typeof(TestObjectNegativeRule));
            BoolRegistryObject.RegisterRule(RuleNames.R004, typeof(TestObjectNonNegativeRule));
            BoolRegistryObject.RegisterRule(RuleNames.R005, typeof(TestObjectEvenRule));
            BoolRegistryObject.RegisterRule(RuleNames.R006, typeof(TestObjectOddRule));
        }
    }
}
