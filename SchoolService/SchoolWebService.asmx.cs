using System;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace SchoolService
{
    /// <summary>
    /// Summary description for SchoolWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SchoolWebService : WebService
    {
        private SchoolDb _schoolDb;

        public SchoolWebService()
        {
            _schoolDb = new SchoolDb();
        }

        [WebMethod]
        public string Add(String name)
        {
            if (_schoolDb.AddStudent(name))
            {
                return "Successfully added!";
            }
            return "Something went wrong(..";
        }

        [WebMethod]
        public string ReadAll()
        {
            //Serialization
            JavaScriptSerializer dataContract = new JavaScriptSerializer();
            string serializedDataInStringFormat = dataContract.Serialize(_schoolDb.GetListOfStudents());
            return serializedDataInStringFormat;
        }
    }
}
