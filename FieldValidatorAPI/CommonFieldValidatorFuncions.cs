using System;
using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFuncions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengValidDel _stringLengValidDel = null;
        private static DateValidDel _dataValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;


        public static RequiredValidDel RequireFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequireFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengValidDel StringFieldLengthValidDel
        {
            get
            {
                if (_stringLengValidDel == null)
                    _stringLengValidDel = new StringLengValidDel(StringFieldLengthValid);

                return _stringLengValidDel;
            }
        }

        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dataValidDel == null)
                    _dataValidDel = new DateValidDel(DateFieldValid);

                return _dataValidDel;
            }
        }

        public static PatternMatchValidDel FieldPatterValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatterValid);

                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel FieldComparisonValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }

        private static bool RequireFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
                return true;
            return false;

        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max) return true;
            return false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;
            return false;
        }

        private static bool FieldPatterValid(string fieldVal, string reqExpPattern)
        {
            Regex regex = new Regex(reqExpPattern);

            if (regex.IsMatch(fieldVal)) return true;
            return false;
        }


        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2)) return true;
            return false;
        }
    }
}
