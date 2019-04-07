using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Globalization;

namespace XPathWork
{
    class Program
    {
        private static XmlElement Bfs(XmlElement root, string value)
        {
            var q = new Queue<XmlElement>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                foreach (var to in cur.ChildNodes)
                {
                    var xTo = to as XmlElement;
                    if (xTo == null)
                        continue;
                    if (xTo.Name == value)
                        return xTo;
                    q.Enqueue(xTo);
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            //ZipFile.ExtractToDirectory("Current.zip", "CurrentUnpackaged");
            foreach (var fileName in Directory.GetFiles("CurrentUnpackaged", @"*.xml"))
            {                
                var curDoc = new XmlDocument();
                curDoc.Load(fileName);
                var customerInfoNode = Bfs(curDoc.DocumentElement, "customerInfo");
                var nsmgr = new XmlNamespaceManager(curDoc.NameTable);
                nsmgr.AddNamespace("custInfoNs", customerInfoNode.NamespaceURI);
                Console.WriteLine($"Название компании: {customerInfoNode.SelectSingleNode("custInfoNs:fullName", nsmgr).InnerText}");
                Console.WriteLine($"ИНН: {customerInfoNode.SelectSingleNode("custInfoNs:INN", nsmgr).InnerText}");
                Console.WriteLine($"КПП: {customerInfoNode.SelectSingleNode("custInfoNs:KPP", nsmgr).InnerText}");
                var positionsNode = Bfs(curDoc.DocumentElement, "positions");
                if (positionsNode != null)
                {
                    nsmgr.AddNamespace("posNs", positionsNode.NamespaceURI);
                    Console.WriteLine($"Кол-во позиций: {positionsNode.SelectNodes("posNs:position", nsmgr).Count}");
                    var reqPosTotals = positionsNode.SelectNodes("posNs:position[starts-with(descendant::posNs:OKPD2/posNs:code," +
                        " '63')]/posNs:commonInfo/posNs:financeInfo/posNs:planPayments/posNs:total", nsmgr);
                    if (reqPosTotals.Count > 0)
                    {
                        var sum = 0.0;
                        foreach (XmlNode cur in reqPosTotals)
                            sum += double.Parse(cur.InnerText, new CultureInfo("en-US"));
                        Console.WriteLine($"Среднее арифметическое всех сумм позиций ПГ с ОКПД 63 и дочерних: {sum / reqPosTotals.Count}");
                    }
                    else
                        Console.WriteLine("Позиций с ОКПД 63 и дочерних не найдено");
                }
                else
                    Console.WriteLine("Позиции не найдены");
                Console.WriteLine();
            }
        }
    }
}
