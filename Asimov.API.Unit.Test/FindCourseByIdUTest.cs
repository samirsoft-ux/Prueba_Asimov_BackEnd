using Asimov.API.Competences.Domain.Repositories;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Courses.Domain.Services.Communication;
using Asimov.API.Courses.Services;
using Asimov.API.Shared.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace Asimov.API.Unit.Test;

public class FindCourseByIdUTest
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
        var CourseId = 12;
        mockCourseRepository.Setup(r => r.FindByIdAsync(CourseId))
            .Returns(Task.FromResult<Course>(null!));
        var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            
        var service = new CourseService(mockCourseRepository.Object, mockUnitOfWork.Object);
            
        //Act
        CourseResponse result = await service.FindById(CourseId);

        //Assert
        Assert.That(result.Message, Is.EqualTo("Course not found."));
    }
}