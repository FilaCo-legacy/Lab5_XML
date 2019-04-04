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
        /// <summary>
        /// Инициализирует объект класса <see cref="TVar"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TVar"/></param>
        public TVar(string source)
        {
            typeId = TypeIdent.VARS;
            Parse(source);
        }
        protected override void Parse(string source)
        {
            source = source.Trim(';', ' ');
        }
    }
}
