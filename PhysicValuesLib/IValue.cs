namespace PhysicValuesLib;

/// <summary>
/// Интерфейс физической величины
/// </summary>
public interface IValue
{
    /// <summary>
    /// Словарь коэффициентов перевода величин
    /// </summary>
    /// <returns></returns>
    Dictionary<string, double> ConvertationCoefficient();

    string GetValueName();
    /// <summary>
    /// Метод возвращает список единиц измерения
    /// </summary>
    /// <returns></returns>
    List<string> GetMeasureList();

    /// <summary>
    /// Метод возвращает конвертированное значение
    /// </summary>
    /// <returns></returns>
    double GetConvertedValue(double value, string from, string to);

    /// <summary>
    /// Метод переводит в систему СИ
    /// </summary>
    void ToSi();

    /// <summary>
    /// Метод конвертирует в нужные единицы измерения
    /// </summary>
    void ToRequired();
}
