using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой тип идентификатора "класс"
    /// </summary>
    public class TClass : Id
    {
        private const string PATTERN_CLASS = @"^class\s+(?!(ref|out|int|char|bool|string|float)\s*;)[^\d\s]\w*\s*;$";
        private static Regex reg = new Regex(PATTERN_CLASS);
        public TClass()
        {

        }
        /// <summary>
        /// Инициализирует объект класса <see cref="TClass"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TClass"/></param>
        public TClass(string source)
        {
            TypeId = TypeIdent.CLASSES;
            TypeVal = TypeValue.class_type;
            Parse(source);
        }
        protected override void Parse(string source)
        {
            if (!reg.IsMatch(source))
                throw new Exception("Input string has wrong format.");
            source = source.TrimEnd(' ', ';');
            string[] inp = source.Split(' ');
            Name = inp[1];            
        }
        /// <summary>
        /// Инициализирует (если возможно) объект класса <see cref="TClass"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TClass"/></param>
        public static TClass CreateFromSource(string source)
        {
            if (reg.IsMatch(source))
                return new TClass(source);
            return null;
        }
    }
}
