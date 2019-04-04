using System;

namespace ParsingStructs
{
    /// <summary>
    /// Представляет собой возможные типы <see cref="Id"/>
    /// </summary>
    public enum TypeIdent { CLASSES, CONSTS, VARS, METHODS, eCOUNT };
    /// <summary>
    /// Представляет собой возможные типы значения
    /// </summary>
    public enum TypeValue { int_type, float_type, bool_type, char_type, string_type, class_type, eCOUNT };
    public delegate Id CheckSource(string source);
    [Serializable]
    /// <summary>
    /// Класс, представляющий собой идентификатор в дереве
    /// </summary>
    public abstract class Id
    {
        private static CheckSource[]dispatcher = {TClass.CreateFromSource, TConst.CreateFromSource,
            TVar.CreateFromSource, TMethod.CreateFromSource};
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
        public static CheckSource[] Dispatcher => dispatcher;
        /// <summary>
        /// Выделение информации об объекте класса из строки ввода
        /// </summary>
        /// <param name="source"></param>
        protected abstract void Parse(string source);
        /// <summary>
        /// Определяет по строке тип значения идентификатора
        /// </summary>
        /// <param name="input"></param>
        protected virtual void DefineTypeValue(string input)
        {
            switch (input)
            {
                case "int":
                    typeVal = TypeValue.int_type;
                    break;
                case "float":
                    typeVal = TypeValue.float_type;
                    break;
                case "bool":
                    typeVal = TypeValue.bool_type;
                    break;
                case "char":
                    typeVal = TypeValue.char_type;
                    break;
                default:
                    typeVal = TypeValue.class_type;
                    break;
            }
        }
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
        public static bool operator <(Id ident1, Id ident2) => ident1.GetHashCode() < ident2.GetHashCode();
        public static bool operator >(Id ident1, Id ident2) => ident1.GetHashCode() > ident2.GetHashCode();
        public static bool operator ==(Id ident1, Id ident2) => ident1.GetHashCode() == ident2.GetHashCode();
        public static bool operator !=(Id ident1, Id ident2) => ident1.GetHashCode() != ident2.GetHashCode();
        public static Id CreateIdFromSource(string source)
        {
            Id curId = null;
            for (int i = 0; i < (int)TypeIdent.eCOUNT; ++i)
            {
                curId = dispatcher[i].Invoke(source);
                if (curId != null)                
                    return curId;                
            }
            throw new Exception("The input string has wrong format.");
        }
    }
}
