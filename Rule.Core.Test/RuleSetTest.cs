using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rule.Core;
using Rule.Core.Interface;
using Rule.Core.Test.Rules;
using System.Collections.Generic;

namespace Rule.Core.Test
{
    [TestClass]
    public class RuleSetTest
    {
        [TestMethod]
        public void RuleSet_Simple()
        {
            RuleSet<TestObject, bool> rs = new RuleSet<TestObject, bool>(TestSetup.BoolRegistrySimple);
            rs.AddRule(RuleNames.R001); //True
            rs.AddRule(RuleNames.R002); //False
            rs.AddRule(RuleNames.R003); //True
            rs.AddRule(RuleNames.R004); //False
            rs.AddRule(RuleNames.R005); //True
            rs.AddRule(RuleNames.R006); //False

            var results = rs.Execute(new TestObject());

            IRuleResult<bool> result;
            result = results[RuleNames.R001];
            Assert.IsTrue(result.Result);

            result = results[RuleNames.R002];
            Assert.IsFalse(result.Result);

            result = results[RuleNames.R003];
            Assert.IsTrue(result.Result);

            result = results[RuleNames.R004];
            Assert.IsFalse(result.Result);

            result = results[RuleNames.R005];
            Assert.IsTrue(result.Result);

            result = results[RuleNames.R006];
            Assert.IsFalse(result.Result);
        }

        [TestMethod]
        public void RuleSet_Object()
        {
            RuleSet<TestObject, bool> rs = new RuleSet<TestObject, bool>(TestSetup.BoolRegistryObject);
            rs.AddRule(RuleNames.R001); //Negative Rule
            rs.AddRule(RuleNames.R002); //Even Rule
            rs.AddRule(RuleNames.R003); //Negative Rule
            rs.AddRule(RuleNames.R004); //NonNegative Rule
            rs.AddRule(RuleNames.R005); //Even Rule
            rs.AddRule(RuleNames.R006); //Odd Rule
            rs.AddRule(RuleNames.R007); //True Rule

            List<TestObject> validationList = new List<TestObject>();

            TestObject obj1 = new TestObject()
            {
                IntegerProperty = -1 //Negative, Odd
            };
            TestObject obj2 = new TestObject()
            {
                IntegerProperty = 2 //NonNegative, Even
            };
            validationList.Add(obj1);
            validationList.Add(obj2);

            var validationMap = new Dictionary<TestObject, Dictionary<string, IRuleResult<bool>>>();
            validationList.ForEach((obj) =>
            {
                var results = rs.Execute(obj);

                validationMap.Add(obj, results);
            });

            IRuleResult<bool> result;

            //obj1
            result = validationMap[obj1][RuleNames.R001];
            Assert.IsTrue(result.Result);

            result = validationMap[obj1][RuleNames.R002];
            Assert.IsFalse(result.Result);

            result = validationMap[obj1][RuleNames.R003];
            Assert.IsTrue(result.Result);

            result = validationMap[obj1][RuleNames.R004];
            Assert.IsFalse(result.Result);

            result = validationMap[obj1][RuleNames.R005];
            Assert.IsFalse(result.Result);

            result = validationMap[obj1][RuleNames.R006];
            Assert.IsTrue(result.Result);
            
            result = validationMap[obj1][RuleNames.R007];
            Assert.IsTrue(result.Result);

            //obj2
            result = validationMap[obj2][RuleNames.R001];
            Assert.IsFalse(result.Result);

            result = validationMap[obj2][RuleNames.R002];
            Assert.IsTrue(result.Result);

            result = validationMap[obj2][RuleNames.R003];
            Assert.IsFalse(result.Result);

            result = validationMap[obj2][RuleNames.R004];
            Assert.IsTrue(result.Result);

            result = validationMap[obj2][RuleNames.R005];
            Assert.IsTrue(result.Result);

            result = validationMap[obj2][RuleNames.R006];
            Assert.IsFalse(result.Result);

            result = validationMap[obj2][RuleNames.R007];
            Assert.IsTrue(result.Result);
        }
    }
}
