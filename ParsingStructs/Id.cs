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
    [Serializable]
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
    }
}
