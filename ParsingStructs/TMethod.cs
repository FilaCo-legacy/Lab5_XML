using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, представляющий собой идентификатор типа "метод"
    /// </summary>
    public class TMethod : Id
    {
        private ListParams listParams;
        /// <summary>
        /// Список параметров метода
        /// </summary>
        public ListParams Params => listParams;
        /// <summary>
        /// Инициализирует новый объект класса <see cref="TMethod"/> с заданным именем, типом возвращаемого значения и 
        /// списком параметров
        /// </summary>
        /// <param name="valueName">Имя нового объекта класса <see cref="TMethod"/></param>
        /// <param name="valueTypeVal">Тип возвращаемого значения нового объекта класса <see cref="TMethod"/></param>
        /// <param name="parametres">Список значений нового объекта класса <see cref="TMethod"/></param>
        public TMethod(string valueName, TypeValue valueTypeVal, params TParam[] parametres):base(valueName)
        {
            typeId = TypeIdent.METHOD;
            typeVal = valueTypeVal;
            listParams = new ListParams(parametres);
        }
        /// <summary>
        /// Возвращает строку с информацией об идентификаторе и о списке его параметров
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + Params;
        }
    }
}
