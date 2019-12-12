using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using DocumentsCirculation.Models;
using DocumentsCirculation.DAO;

namespace DocumentsCirculation
{
    [TestFixture]
    public class TestInsertSelectClass
    {
        /*Тест для класса DocInsideDAO, который осуществляет доступ к бд
         В тесте вызываются и прверяются операции добавления, выборки и удаления объекта внутреннего документа */
        [Test]
        public void TestDocInsideDAO()
        {
            DocumentInside docInside = new DocumentInside();
            DocInsideDAO dao = new DocInsideDAO();
            AdministrationDAO admindao = new AdministrationDAO();

            docInside.name = "Штраф за опоздание";
            docInside.creationdate = Convert.ToDateTime("2019-12-12");
            docInside.authorID = 1;
            docInside.shelflife = Convert.ToDateTime("2022-12-12");
            docInside.signerID = 1;
            docInside.moneydifference = -1000;
            docInside.targetID = 2;

            dao.AddInside(docInside);

            List<DocumentInside> diList = dao.GetAllInsides();
            int pos = diList.Count()-1;

            Assert.AreEqual(docInside.toString(),diList[pos].toString());

            admindao.SendForDrop(diList[pos].documentID);
            admindao.DropDoc(diList[pos].documentID);

            diList = dao.GetAllInsides();
            pos = diList.Count() - 1;

            Assert.AreNotEqual(docInside.toString(), diList[pos].toString());
        }
    }
}