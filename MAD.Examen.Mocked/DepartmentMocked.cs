using AutoFixture;
using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using MAD.Examen.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAD.Examen.Mocked
{
    public class DepartmentMocked
    {



        private List<Department> _departments;

        public DepartmentMocked()
        {
            _departments = Departments();
        }

        private List<Department> Departments()
        {
            var fixture = new Fixture();
            var departments = fixture.CreateMany<Department>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                departments[i].DepartmentID = i + 1;
            }

            return departments;
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Departments).Returns(DepartmentRepositoryMocked());
            return mocked.Object;

        }

        private IDepartmentRepository DepartmentRepositoryMocked()
        {
            var departmentMocked = new Mock<IDepartmentRepository>();
            departmentMocked.Setup(c => c.GetList()).Returns(_departments);
            departmentMocked.Setup(c => c.Insert(It.IsAny<Department>())).Callback<Department>((c) =>
               _departments.Add(c)).Returns<Department>(c => c.DepartmentID);

            departmentMocked.Setup(c => c.Update(It.IsAny<Department>())).Callback<Department>((c) =>
            {
                _departments.RemoveAll(cour => cour.DepartmentID== c.DepartmentID);
                _departments.Add(c);
            }).Returns(true);

            departmentMocked.Setup(c => c.Delete(It.IsAny<Department>())).Callback<Department>((c) => _departments.RemoveAll(cour => cour.DepartmentID == c.DepartmentID)).Returns(true);
            departmentMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _departments.FirstOrDefault(cour => cour.DepartmentID == id));

            return departmentMocked.Object;
        }









    }
}
