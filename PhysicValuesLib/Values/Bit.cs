namespace PhysicValuesLib.Values
{

    public class Bit : IValue
    {
        private double Value1 { get; set; }
        private string? From1 { get; set; }
        private string? To1 { get; set; }

        private string _valueName1 = "Единицы измерения информации";

        private List<string> _measureList1 = new List<string>()
    {
        "Байт",
        "Килобайт",
        "Мегабайт",
        "Гигабайт"
    };

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue(double value, string from, string to)
        {
            Value1 = value;
            From1 = from;
            To1 = to;

            ToSi();
            ToRequired();
            return Value1;
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList()
        {
            return _measureList1;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            switch (To1)
            {
                case "Байт":
                    break;
                case "Килобайт":
                    Value1 /= 1024;
                    break;
                case "Мегабайт":
                    Value1 /= Math.Pow(1024,2);
                    break;
                case "Гигабайт":
                    Value1 /= Math.Pow(1024, 3);
                    break;
            }
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            switch (From1)
            {
                case "Байт":
                    break;
                case "Килобайт":
                    Value1 *= 1024;
                    break;
                case "Мегабайт":
                    Value1 *= Math.Pow(1024, 2);
                    break;
                case "Гигабайт":
                    Value1 *= Math.Pow(1024, 3);
                    break;
            }
        }

        public string GetValueName()
        {
            return _valueName1;
        }

        public Dictionary<string, double> ConvertationCoefficient()
        {
            throw new NotImplementedException();
        }
    }

}