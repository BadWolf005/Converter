using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    public class Dlin : IValue
    {
        private double Value3 { get; set; }
        private string? From3 { get; set; }
        private string? To3 { get; set; }

        private string _valueName3 = "Длина";

        private List<string> _measureList3 = new List<string>()
    {
        "Миллиметр",
        "Сантиметр",
        "Дециметр",
        "Метр",
        "Километр"
    };

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue(double value, string from, string to)
        {
            Value3 = value;
            From3 = from;
            To3 = to;

            ToSi();
            ToRequired();
            return Value3;
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList()
        {
            return _measureList3;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            switch (To3)
            {
                case "Миллиметр":
                    break;
                case "Сантиметр":
                    Value3 /= 10;
                    break;
                case "Дециметр":
                    Value3 /= 100;
                    break;
                case "Метр":
                    Value3 /= 1000;
                    break;
                case "Километр":
                    Value3 /= 10000000;
                    break;
            }
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            switch (From3)
            {
                case "Миллиметр":
                    break;
                case "Сантиметр":
                    Value3 *= 1;
                    break;
                case "Дециметр":
                    Value3 *= 100;
                    break;
                case "Метр":
                    Value3 *= 1000;
                    break;
                case "Километр":
                    Value3 *= 1000000;
                    break;
            }
        }

        public string GetValueName()
        {
            return _valueName3;
        }

        public Dictionary<string, double> ConvertationCoefficient()
        {
            throw new NotImplementedException();
        }
    }
}
