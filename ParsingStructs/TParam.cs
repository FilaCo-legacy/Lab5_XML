using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Представляет собой возможные методы передачи параметров в <see cref="TMethod"/>
    /// </summary>
    public enum TypeParam { param_val, param_ref, param_out};
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
        /// <summary>
        /// Тип значения параметра
        /// </summary>
        public TypeValue TypeVal { get; set; }
        /// <summary>
        /// Метод передачи параметра
        /// </summary>
        public TypeParam TypeParam { get; set; }
        /// <summary>
        /// Определяет по строке тип значения идентификатора
        /// </summary>
        /// <param name="input"></param>
        private void DefineTypeValue(string input)
        {
            switch (input)
            {
                case "int":
                    TypeVal = TypeValue.int_type;
                    break;
                case "float":
                    TypeVal = TypeValue.float_type;
                    break;
                case "bool":
                    TypeVal = TypeValue.bool_type;
                    break;
                case "char":
                    TypeVal = TypeValue.char_type;
                    break;
                default:
                    TypeVal = TypeValue.class_type;
                    break;
            }
        }
        public TParam()
        {

        }
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
            if (!reg.IsMatch(source))
                throw new Exception("The argument string has wrong format.");
            string[] inp = source.Split(' ');
            switch (inp[0])
            {
                case "ref":
                    TypeParam = TypeParam.param_ref;
                    break;
                case "out":
                    TypeParam = TypeParam.param_out;
                    break;
                default:
                    TypeParam = TypeParam.param_val;
                    DefineTypeValue(inp[0]);
                    return;
            }
            DefineTypeValue(inp[1]);
        }
        /// <summary>
        /// Возвращает информацию о типе значения и методе передачи параметра
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"->|| {TypeVal} | {TypeParam} ||");
        }
    }
}
