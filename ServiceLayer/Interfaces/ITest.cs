using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ITest
    {
        void AddTest(TestModel testModel);
        TestModel GetTest(TestModel testModel);
        void UpdateTest(TestModel testModel);
        void DeleteTest(TestModel testModel);
        List<TestModel> GetAllTests();
    }
}
