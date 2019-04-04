using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Представляет собой возможные методы передачи параметров в <see cref="TMethod"/>
    /// </summary>
    public enum TypeParam { VALUE, REFERENCE, OUT};
    /// <summary>
    /// Класс, представляющий собой параметр в идентификаторе <see cref="TMethod"/>
    /// </summary>
    public class TParam 
    {
        /// <summary>
        /// Регулярное выражение для проверки, описывает ли строка какой-то аргумент функции
        /// </summary>
        private const string PATTERN_PARAM =
            @"^(ref\s+|out\s+)?(?!(ref|out)\s)[^\d\s]\w*\s+(?!(ref|out|int|char|bool|string|float)$)[^\d\s]\w*$";
        private static Regex reg = new Regex(PATTERN_PARAM);
        private TypeValue typeVal;
        private TypeParam typeParam;
        /// <summary>
        /// Тип значения параметра
        /// </summary>
        public TypeValue TypeVal => typeVal;
        /// <summary>
        /// Метод передачи параметра
        /// </summary>
        public TypeParam TypePar => typeParam;
        /// <summary>
        /// Инициализирует объект класса <see cref="TParam"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TParam"/></param>
        public TParam(string source)
        {
            Parse(source);
        }
        /// <summary>
        /// Выделение информации об объекте класса из строки ввода
        /// </summary>
        /// <param name="source"></param>
        private void Parse(string source)
        {
            source = source.Trim(' ');
        }
        /// <summary>
        /// Возвращает информацию о типе значения и методе передачи параметра
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"->|| {TypeVal} | {TypePar} ||");
        }
    }
}
