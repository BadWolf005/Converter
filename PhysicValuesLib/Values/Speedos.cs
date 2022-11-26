namespace PhysicValuesLib.Values
{
    public class Speedos : IValue
    {
        private double Value2 { get; set; }
        private string? From2 { get; set; }
        private string? To2 { get; set; }

        private string _valueName2 = "Давление";

        private List<string> _measureList2 = new List<string>()
    {
        "Бар",
        "Мегапаскаль",
        "Паскаль",
        "Миллибар"
    };
        public double GetConvertedValue(double value, string from, string to)
        {
            Value2 = value;
            From2 = from;
            To2 = to;

            ToSi();
            ToRequired();
            return Value2;
        }

        public List<string> GetMeasureList()
        {
            return _measureList2;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            switch (To2)
            {
                case "Бар":
                    break;
                case "Миллибар":
                    Value2 *= 1000;
                    break;
                case "Паскаль":
                    Value2 *= 100000;
                    break;
                case "Мегапаскаль":
                    Value2 /= 10;
                    break;
            }
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            switch (From2)
            {
                case "Бар":
                    break;
                case "Миллибар":
                    Value2 /= 1000;
                    break;
                case "Паскаль":
                    Value2 /= 100000;
                    break;
                case "Мегапаскаль":
                    Value2 *= 10;
                    break;
            }
        }

        public string GetValueName()
        {
            return _valueName2;
        }

        public Dictionary<string, double> ConvertationCoefficient()
        {
            throw new NotImplementedException();
        }
    }
}