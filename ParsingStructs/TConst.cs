using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор "константу"
    /// </summary>
    public class TConst:Id
    {
        /// <summary>
        /// Регулярное выражение для проверки, описывает ли строка какую-то константу
        /// </summary>
        private const string PATTERN_CONST =
            @"^const\s+\w+\s+(?!(ref|out|int|char|bool|string|float)\s*=)[^\d\s]\w*\s*=\s*[\w\d,""'-]+\s*;$";
        private static Regex reg = new Regex(PATTERN_CONST);
        private object value;
        /// <summary>
        /// Значение, записанное в константе
        /// </summary>
        public object Value => value;
        public TConst()
        {

        }
        /// <summary>
        /// Инициализирует объект класса <see cref="TConst"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TConst"/></param>
        public TConst(string source)
        {
            typeId = TypeIdent.CONSTS;
            Parse(source);
        }
        /// <summary>
        /// Возвращает информацию о значении, записанном в константе, а также вывод базового класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($" | {value}");
        }
        protected override void Parse(string source)
        {
            if (!reg.IsMatch(source))
                throw new Exception("Input string has wrong format.");
            source = source.TrimEnd(';', ' ');
            source = source.Replace('=', ' ');
            Regex regRemoveSpaces = new Regex(@"\s+");
            string[] inp = regRemoveSpaces.Split(source);
            // Определение типа значения константы и проверка корректности
            switch (inp[1])
            {
                case "int":
                    {                        
                        if (!int.TryParse(inp[3], out int tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.int_type}.");
                        typeVal = TypeValue.int_type;
                        value = tmp;
                        break;
                    }
                case "float":
                    {
                        if (!float.TryParse(inp[3], out float tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.float_type}.");
                        typeVal = TypeValue.float_type;
                        value = tmp;
                        break;
                    }
                case "bool":
                    {
                        if (!bool.TryParse(inp[3], out bool tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.bool_type}.");
                        typeVal = TypeValue.bool_type;
                        value = tmp;
                        break;
                    }
                case "char":
                    {
                        if (!char.TryParse(inp[3], out char tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.char_type}.");
                        typeVal = TypeValue.char_type;
                        value = tmp;
                        break;
                    }
                default:
                    throw new Exception("Undefined value type.");
            }
            Name = inp[2];
        }
        /// <summary>
        /// Инициализирует (если возможно) объект класса <see cref="TConst"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TConst"/></param>
        public static TConst CreateFromSource(string source)
        {
            if (reg.IsMatch(source))
                return new TConst(source);
            return null;
        }
    }
    
}
