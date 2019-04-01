
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
        /// Инициализирует объект класса <see cref="TParam"/> с заданным именем, типом значения и методом передачи параметра
        /// </summary>
        /// <param name="valueName">Имя нового объекта класса <see cref="TParam"/></param>
        /// <param name="valueType">Тип значения нового объекта класса <see cref="TParam"/></param>
        /// <param name="valueParamType">Метод передачи параметра</param>
        public TParam(string valueName, TypeValue valueType, TypeParam valueParamType)
        {
            typeVal = valueType;
            typeParam = valueParamType;
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
