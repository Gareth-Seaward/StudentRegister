using MongoDB.Driver;
using StudentRegisterApi.Behaviours.Interfaces;
using StudentRegisterApi.Models;
using StudentRegisterApi.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegisterApi.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;
        public CourseService(ISchoolsDatabaseSettings settings, IMongoCollectionBehaviour<Course> mongoCollectionBehaviour)
        {
            _courses = mongoCollectionBehaviour.GetCollection(settings.CoursesCollectionName);
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _courses.Find(s => true).ToListAsync();
        }
        public async Task<Course> GetByIdAsync(string id)
        {
            return await _courses.Find<Course>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Course> CreateAsync(Course course)
        {
            await _courses.InsertOneAsync(course);
            return course;
        }
        public async Task UpdateAsync(string id, Course course)
        {
            await _courses.ReplaceOneAsync(c => c.Id == id, course);
        }
        public async Task DeleteAsync(string id)
        {
            await _courses.DeleteOneAsync(c => c.Id == id);
        }
    }
}
