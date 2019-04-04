using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор типа "переменная"
    /// </summary>
    public class TVar : Id
    {
        private const string PATTERN_VAR = @"^\w+\s+(?!(ref|out|int|char|bool|string|float)\s*;)[^\d\s]\w*\s*;$";
        private static Regex reg = new Regex(PATTERN_VAR);
        public TVar()
        {

        }
        /// <summary>
        /// Инициализирует объект класса <see cref="TVar"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TVar"/></param>
        public TVar(string source)
        {
            TypeId = TypeIdent.VARS;
            Parse(source);
        }
        protected override void Parse(string source)
        {
            if (!reg.IsMatch(source))
                throw new Exception("Input string has wrong format.");
            source = source.TrimEnd(';', ' ');
            string[] inp = source.Split(' ');
            // Определение типа значения переменной
            DefineTypeValue(inp[0]);
            Name = inp[1];
        }
        /// <summary>
        /// Инициализирует (если возможно) объект класса <see cref="TVar"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TVar"/></param>
        public static TVar CreateFromSource(string source)
        {
            if (reg.IsMatch(source))
                return new TVar(source);
            return null;
        }
    }
}
