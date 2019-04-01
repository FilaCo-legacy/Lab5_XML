using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор типа "переменная"
    /// </summary>
    public class TVar:Id
    {
        /// <summary>
        /// Инициализирует новый объект класса <see cref="TVar"/> с заданным именем и типом значения
        /// </summary>
        /// <param name="valueName">Имя нового идентификатора</param>
        /// <param name="valueTypeVal">Тип значения нового идентификатора</param>
        public TVar(string valueName, TypeValue valueTypeVal) : base(valueName)
        {
            typeId = TypeIdent.VAR;
            typeVal = valueTypeVal;
        }
    }
}
