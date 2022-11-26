using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    public class Volume : IValue
    {
        private double Value4 { get; set; }
        private string? From4 { get; set; }
        private string? To4 { get; set; }

        private string _valueName4 = "Объём";

        private List<string> _measureList4 = new List<string>()
    {
        "Миллилитр",
        "Микролитр",
        "Литр",
        "Гектолитр",
        "Кубометр"
    };

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue(double value, string from, string to)
        {
            Value4 = value;
            From4 = from;
            To4 = to;

            ToSi();
            ToRequired();
            return Value4;
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList()
        {
            return _measureList4;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            switch (To4)
            {
                case "Миллилитр":
                    break;
                case "Микролитр":
                    Value4 *= 1000;
                    break;
                case "Литр":
                    Value4 /= 1000;
                    break;
                case "Гектолитр":
                    Value4 /= 100000;
                    break;
                case "Кубометр":
                    Value4 /= 1000000;
                    break;
            }
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            switch (From4)
            {
                case "Миллилитр":
                    break;
                case "Микролитр":
                    Value4 /= 1000;
                    break;
                case "Литр":
                    Value4 *= 1000;
                    break;
                case "Гектолитр":
                    Value4 *= 1000000;
                    break;
                case "Кубометр":
                    Value4 *= 10000000;
                    break;
            }
        }

        public string GetValueName()
        {
            return _valueName4;
        }

        public Dictionary<string, double> ConvertationCoefficient()
        {
            throw new NotImplementedException();
        }
    }
}
