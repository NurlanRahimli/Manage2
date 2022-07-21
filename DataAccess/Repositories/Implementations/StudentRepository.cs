using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student entity)
        {
            DbContext.Students.Add(entity);
        }

        public void Delete(Student entity)
        {
            DbContext.Students.Remove(entity);
        }
        public void Update(Student entity)
        {
            var student = DbContext.Students.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
            }
        }

        public Student Get(Predicate<Group> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find((Predicate<Student>)filter);
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students;
            }
            else
            {
                return DbContext.Students.FindAll(filter);
            }
        }

        public Student Get(Predicate<Student> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
