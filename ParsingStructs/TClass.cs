

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой тип идентификатора "класс"
    /// </summary>
    public class TClass : Id
    {
        /// <summary>
        /// Инициализирует объект класса <see cref="TClass"/> с заданным именем
        /// </summary>
        /// <param name="valueName">Имя нового объекта класса <see cref="TClass"/></param>
        public TClass(string valueName) : base(valueName)
        {
            typeId = TypeIdent.CLASS;
            typeVal = TypeValue.CLASS;
        }
    }
}
