using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой тип идентификатора "класс"
    /// </summary>
    public class TClass : Id
    {
        private const string PATTERN_CLASS = @"(?<=^|\s)\s*class\s+\w+\s*;(?=$|\s)";
        private static Regex reg = new Regex(PATTERN_CLASS);
        /// <summary>
        /// Инициализирует объект класса <see cref="TClass"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TClass"/></param>
        public TClass(string source)
        {
            typeId = TypeIdent.CLASSES;
            typeVal = TypeValue.class_type;
            Parse(source);
        }
        protected override void Parse(string source)
        {
            if (!reg.IsMatch(source))
                throw new Exception("Входная строка имела неверный формат");
            source = source.Trim(' ', '\n', '\r', ';');
            Regex regRemoveSpaces = new Regex(@"\s+");
            string[] inp = regRemoveSpaces.Split(source);
            Name = inp[1];            
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
