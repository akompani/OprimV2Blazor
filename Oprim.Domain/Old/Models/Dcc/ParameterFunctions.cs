using System.ComponentModel.DataAnnotations;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;

namespace Oprim.Domain.Old.Models.Dcc
{
    public enum ParameterTypes : byte
    {
        String = 0,
        Number = 1,
        Boolean = 2
    }

    public enum RangeTypes : byte
    {
        NON = 0,
        [Display(Name = "Equal")]
        YEQ = 1,
        [Display(Name = "Not Equal")]
        NEQ = 2,
        [Display(Name = "Range")]
        RNG = 3,
        [Display(Name = "Less than")]
        MAX = 4,
        [Display(Name = "Greather than")]
        MIN = 5
    }

    public static class ParameterGeneralFunctions
    {

        public static Dictionary<DocumentBaseParameter, object> ConvertParamValueDicToBaseParameterDictionary(
            this List<DocumentBaseParameter> baseParameters, Dictionary<string, string> parameterValues)
        {
            var result = new Dictionary<DocumentBaseParameter, object>();

            if (baseParameters.Count == 0) return result;

            baseParameters = baseParameters.OrderBy(b => b.Code).ToList();

            foreach (var bp in baseParameters)
            {
                result.Add(bp, bp.ParameterType.ConvertByParameterType(""));
            }

            if (parameterValues.Count == 0) return result;

            
            foreach (var paramValue in parameterValues)
            {
                var entity = result.Keys.SingleOrDefault(e => e.Code.ToUpper() == paramValue.Key.ToUpper());

                if(entity!=null) result[entity] =  entity.ParameterType.ConvertByParameterType(paramValue.Value);
            }

            return result;
        }

        public static Dictionary<DocumentBaseParameter, object> ConvertStringToBaseParameterDictionary(this List<DocumentBaseParameter> baseParameters, string parameterValues)
        {
            var paramDic = new Dictionary<string, string>();

            var paramList = string.IsNullOrEmpty(parameterValues) ? new string[] { } : parameterValues.Split(",").ToArray();

            foreach (var pl in paramList)
            {
                if(pl.Length ==0) continue;

                var pv = pl.Split(";").ToArray();

                paramDic.Add(pv[0], pv[1] ?? "");
            }

            return ConvertParamValueDicToBaseParameterDictionary(baseParameters, paramDic);
        }

        public static object ConvertByParameterType(this ParameterTypes type, string val)
        {
            return type switch
            {
                ParameterTypes.Number => !string.IsNullOrEmpty(val) ? Convert.ToDecimal(val) : 0,
                ParameterTypes.Boolean => !string.IsNullOrEmpty(val) ? (val.ToUpper() == "TRUE" ? true : false) : false,
                _ => val
            };
        }

        public static bool IsValid(this DocumentBaseParameter parameterEntity, object value)
        {
            return IsValid(parameterEntity.ParameterType, parameterEntity.RangeType, parameterEntity.RangeValues, value);
        }

        public static bool IsValid(ParameterTypes parameterType, RangeTypes rangeType, string rangeValues, object value)
        {
            if (rangeType == RangeTypes.NON | string.IsNullOrEmpty(rangeValues)) return true;

            var rangeValueList = rangeValues.Split("|").ToList();

            int rangeIndex = 0;

            do
            {
                if (rangeValueList[rangeIndex].Length == 0)
                {
                    rangeValueList.RemoveAt(rangeIndex);
                }
                else
                {
                    rangeIndex++;
                }

            } while (rangeIndex < rangeValueList.Count);

            //check errors
            if (rangeType == RangeTypes.YEQ | rangeType == RangeTypes.NEQ)
            {
                if (rangeType == RangeTypes.YEQ)
                {
                    return rangeValueList.Any(r => r.Equals(value));
                }
                else
                {
                    return rangeValueList.Any(r => r.Equals(value));
                }
            }
            else
            {
                if ((parameterType == ParameterTypes.String | parameterType == ParameterTypes.Boolean)) throw new Exception("ErrorInRangeValidateType");
                if (rangeType == RangeTypes.RNG & rangeValueList.Count != 2) throw new Exception("ErrorInRangeValidateValues");
                if ((rangeType == RangeTypes.MIN | rangeType == RangeTypes.MAX) & rangeValueList.Count != 1)
                    throw new Exception("ErrorInRangeValidateValues");

                var val = Convert.ToDecimal(value);

                return rangeType switch
                {
                    RangeTypes.RNG => val >= Convert.ToDecimal(rangeValueList[0]) &
                                      val <= Convert.ToDecimal(rangeValueList[1]),
                    RangeTypes.MIN => val >= Convert.ToDecimal(rangeValueList[0]),
                    RangeTypes.MAX => val <= Convert.ToDecimal(rangeValueList[0]),
                };
            }
        }
    }
}
