using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Courses.Services;
using Asimov.API.Shared.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace Asimov.API.Unit.Test;

public class AddCourseUTest
{
    private static Mock<ICourseRepository> GetDefaultICourseRepositoryInstance()
    {
        return new Mock<ICourseRepository>();
    }
    private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
    {
        return new Mock<IUnitOfWork>();
    }
    [Test]
    public async Task AddCoursesToThings()
    { 
        //Arrange
        var mockCourseRepository = GetDefaultICourseRepositoryInstance();
        mockCourseRepository.Setup(service => service.ListAsync()).ReturnsAsync(new List<Course>());
        var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
        var service = new CourseService(mockCourseRepository.Object, mockUnitOfWork.Object);
        
        //Act
        var result = (List<Course>)await service.ListAsync();
        var activityCount = result.Count;
        //Assert
        Assert.That(activityCount, Is.EqualTo(0));
    }
}