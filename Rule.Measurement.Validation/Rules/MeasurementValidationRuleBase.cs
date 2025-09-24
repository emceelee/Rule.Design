using System;
using System.Collections.Generic;
using System.Text;

using Rule.Core;
using Rule.Core.Interface;

namespace Rule.Measurement.Validation.Rules
{
    public abstract class MeasurementValidationRuleBase<T> : IRule<T, ValidationLevel>
    {
        public IRuleResult<ValidationLevel> Execute(T obj)
        {
            if(obj == null)
            {
                throw new NullReferenceException();
            }

            var result = CreateRuleResult();

            if(!Validate(obj))
            {
                result.Result = ValidationLevel;
                result.Message = ValidationMessage;
            }

            return result;
        }

        //Return false to indicate validation fails
        public abstract bool Validate(T obj);

        //ValidationLevel to return if Validation fails
        public abstract ValidationLevel ValidationLevel { get; }

        //ValidationMessage to log if Validation fails
        public abstract string ValidationMessage { get; }

        private MeasurementValidationRuleResult CreateRuleResult()
        {
            return new MeasurementValidationRuleResult();
        }
    }

    public class MeasurementValidationRuleResult : RuleResult<ValidationLevel> { }
}
