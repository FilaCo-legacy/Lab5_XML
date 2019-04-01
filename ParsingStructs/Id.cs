namespace ParsingStructs
{
    /// <summary>
    /// Представляет собой возможные типы <see cref="Id"/>
    /// </summary>
    public enum TypeIdent { CLASS, CONST, VAR, METHOD };
    /// <summary>
    /// Представляет собой возможные типы значения
    /// </summary>
    public enum TypeValue { INT, FLOAT, BOOL, CHAR, STRING, CLASS };
    /// <summary>
    /// Класс, представляющий собой идентификатор в дереве
    /// </summary>
    public abstract class Id
    {
        protected TypeIdent typeId;        
        protected TypeValue typeVal;
        /// <summary>
        /// Значение хэш-функции от имени идентификатора
        /// </summary>
        protected int hashVal;
        /// <summary>
        /// Тип идентификатора
        /// </summary>
        public TypeIdent TypeId => typeId;
        /// <summary>
        /// Тип значения в идентификаторе
        /// </summary>
        public TypeValue TypeVal => typeVal;
        /// <summary>
        /// Имя идентификатора
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Инициализирует объект класса <see cref="Id"/>
        /// </summary>
        /// <param name="valueName">Имя нового идентификатора</param>
        public Id(string valueName)
        {
            Name = valueName;
            hashVal = Name.GetHashCode();
        }
        /// <summary>
        /// Возвращает строку, в которой указаны имя объекта класса <see cref="Id"/>, значение хэша, тип идентификатора 
        /// и тип значения, записанный в нём
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name} | {hashVal} | {typeId} | {typeVal}");
        }
        /// <summary>
        /// Возвращает значение хэш-функции от имени идентификатора (полиномиальное хэширование)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            const int P = 53;
            int pPow = 1, hash = 0;
            for (int i = 0; i < Name.Length; ++i)
            {
                hash += (Name[i] - '0' + 1) * pPow;
                pPow *= P;
            }
            return hash;
        }
    }
}
