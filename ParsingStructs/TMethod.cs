using System;
using System.Text.RegularExpressions;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор типа "метод"
    /// </summary>
    public class TMethod : Id
    {
        /// <summary>
        /// Регулярное выражение для проверки, описывает ли строка какой-то метод
        /// </summary>
        private static string PATTERN_METHOD = @"^\w+\s+(?!(ref|out|int|char|bool|string|float)\s*\()[^\d\s]\w*\s*\(.*\)\s*;$";
        private static Regex reg = new Regex(PATTERN_METHOD);
        public TListParams ListParams { get; set; }
        public TMethod()
        {

        }
        /// <summary>
        /// Инициализирует объект класса <see cref="TMethod"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TMethod"/></param>
        public TMethod(string source)
        {
            TypeId = TypeIdent.METHODS;            
            Parse(source);
        }
        /// <summary>
        /// Функция, которая делит строку, содержащую информацию о методе на 2 части: общая информация о методе 
        /// и информация об аргументе
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mainPart"></param>
        /// <param name="argumentsPart"></param>
        private void SeparateString(string source, out string mainPart, out string argumentsPart)
        {
            mainPart = argumentsPart = "";
            for (int i = 0; i < source.Length; ++i)
            {
                if(source[i] == '(')
                {
                    argumentsPart = source.Substring(i);
                    break;
                }
                mainPart += source[i];
            }
        }
        /// <summary>
        /// Возвращает строку с информацией об идентификаторе и о списке его параметров
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + ListParams;
        }
        protected override void Parse(string source)
        {
            if (!reg.IsMatch(source))
                throw new Exception("Input string has wrong format.");
            source = source.TrimEnd(';', ' ');
            SeparateString(source, out string mainPart, out string argsPart);
            string[] inp = mainPart.Split(' ');
            // Определение типа значения метода
            DefineTypeValue(inp[0]);
            Name = inp[1];
            ListParams = new TListParams(argsPart);
        }
        /// <summary>
        /// Инициализирует (если возможно) объект класса <see cref="TMethod"/> на основе информации из переданной строки
        /// </summary>
        /// <param name="source">Строка с информацией о новом объекте класса <see cref="TMethod"/></param>
        public static TMethod CreateFromSource(string source)
        {
            if (reg.IsMatch(source))
                return new TMethod(source);
            return null;
        }
    }
}
