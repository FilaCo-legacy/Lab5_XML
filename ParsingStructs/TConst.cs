using System;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор "константу"
    /// </summary>
    public class TConst:Id
    {
        private object value;
        /// <summary>
        /// Значение, записанное в константе
        /// </summary>
        public object Value => value;
        /// <summary>
        /// Инициализирует объект класса константа с заданным именем, типом значения и значением.
        /// Проверяет корректность ввода типа значения и значения
        /// </summary>
        /// <param name="valueName">Имя нового идентификатора <see cref="TConst"/></param>
        /// <param name="valueTypeVal">Тип значения нового идентификатора <see cref="TConst"/></param>
        /// <param name="valueVal">Значение нового идентификатора <see cref="TConst"/></param>
        public TConst(string valueName, TypeValue valueTypeVal, object valueVal) : base(valueName)
        {
            typeId = TypeIdent.CONST;
            typeVal = valueTypeVal;
            switch (TypeVal)
            {
                case TypeValue.INT:                    
                    if (!(valueVal is int))
                        throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.INT}");
                    value = (int)valueVal;
                    break;
                case TypeValue.FLOAT:
                    if (!(valueVal is float))
                        throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.FLOAT}");
                    value = (float)valueVal;
                    break;
                case TypeValue.BOOL:
                    if (!(valueVal is bool))
                        throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.BOOL}");
                    value = (bool)valueVal;
                    break;
                case TypeValue.CHAR:
                    if (!(valueVal is char))
                        throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.CHAR}");
                    value = (char)valueVal;
                    break;
            }
        }
        /// <summary>
        /// Возвращает информацию о значении, записанном в константе, а также вывод базового класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($" | {value}");
        }
    }
}
