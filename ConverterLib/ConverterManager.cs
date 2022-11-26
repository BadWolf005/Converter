using PhysicValuesLib.Values;
using System.Reflection;

namespace PhysicValuesLib;

public class ConverterManager
{
    public ConverterManager()
    {
        SetValuesList();
    }

    private static List<IValue> _physicValuesList = new List<IValue>();

    /// <summary>
    /// Метод погружает список величин из библиотеки классов
    /// </summary>
    private static void SetValuesList()
    {
        Assembly asm = Assembly.LoadFrom("PhysicValuesLib.dll");        // создание сборки из библиотеки классов
        Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
        foreach (Type type in types)                                    // перебираем классы и интерфейсы
        {
            if ((type.IsInterface == false)
                && (type.IsAbstract == false)
                && (type.GetInterface("IValue") != null))               // не добавляем абстрактные классы и интерфейсы
            {
                IValue value = (IValue)Activator.CreateInstance(type);
                _physicValuesList.Add(value);                           // подгружаем этот класс в список уроков                        
            }
        }
    }

    private IValue _myValue;

    private void SetIValue(string valueName)
    {
        foreach(var value in _physicValuesList)
        {
            if (value.GetValueName() == valueName)
            {
                _myValue = value;
            }
            else
            {
                throw new Exception("Ошибка! В библиотеке нет такой величины");
            }
        }
    }

    public List<string> GetPhysicValuesList()
    {      
        List<string> physicValuesList = new List<string>();
        foreach (IValue value in _physicValuesList)
        {
            physicValuesList.Add(value.GetValueName());
        }
        return physicValuesList;
    }

    public List<string> GetMeasureList(string physicValue)
    {
        SetIValue(physicValue);
        return _myValue.GetMeasureList();
    }    

    public double GetConvertedValue(
        string physicValue,
        double value,
        string from,
        string to)
    {
        SetIValue(physicValue);
        return _myValue.GetConvertedValue(value, from, to);
    }

    // ДОМА - на лабораторных!
    // дописать приложение
    // реализовать интерфейс WinFroms / WPF
    // реализовать 5 классов величин
    
}
