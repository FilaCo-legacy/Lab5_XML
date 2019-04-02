using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор "константу"
    /// </summary>
    public class TConst:Id
    {
        private const string PATTERN_CONST = @"(?<=^|\s)\s*const\s+\w+\s+\w+\s+=\s+[\w\d,""'-]+;(?=$|\s)";
        private static Regex reg = new Regex(PATTERN_CONST);
        private object value;
        /// <summary>
        /// Значение, записанное в константе
        /// </summary>
        public object Value => value;
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
            source = source.Trim(' ', '\n', '\r', ';');
            source = source.Replace('=', ' ');
            Regex regRemoveSpaces = new Regex(@"\s+");
            string[] inp = regRemoveSpaces.Split(source);            
            switch (inp[1])
            {
                case "int":
                    {
                        int tmp;
                        if (!int.TryParse(inp[3], out tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.int_type}.");
                        value = tmp;
                        break;
                    }
                case "float":
                    {
                        float tmp;
                        if (!float.TryParse(inp[3], out tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.float_type}.");
                        value = tmp;
                        break;
                    }
                case "bool":
                    {
                        bool tmp;
                        if (!bool.TryParse(inp[3], out tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.bool_type}.");
                        value = tmp;
                        break;
                    }
                case "char":
                    {
                        char tmp;
                        if (!char.TryParse(inp[3], out tmp))
                            throw new Exception($"Corrupted input: input object can't be converted to the {TypeValue.char_type}.");
                        value = tmp;
                        break;
                    }
                default:
                    throw new Exception("Undefined value type.");
            }
            Name = inp[2];
        }  
        /// <summary>
        /// Проверяет, является ли поданная на вход строка корректной для данного типа идентификатора
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>  
        public static bool IsCorrectSourceString(string source)
        {
            return reg.IsMatch(source);
        }
    }
    
}
