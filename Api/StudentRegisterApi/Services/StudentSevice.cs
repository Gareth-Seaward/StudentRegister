using MongoDB.Driver;
using StudentRegisterApi.Behaviours.Interfaces;
using StudentRegisterApi.Models;
using StudentRegisterApi.Models.Interfaces;
using StudentRegisterApi.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegisterApi.Services
{
    public class StudentSevice
    {
        private readonly IMongoCollection<Student> _students;

        public StudentSevice(ISchoolsDatabaseSettings settings, IMongoCollectionBehaviour<Student> mongoCollectionBehaviour)
        {
            _students = mongoCollectionBehaviour.GetCollection(settings.StudentsCollectionName);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _students.Find(s => true).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _students.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }
        public async Task UpdateAsync(string id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }
        public async Task DeleteAsync(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
